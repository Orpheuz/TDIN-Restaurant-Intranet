using System;
using System.Collections;
using System.Threading;

public class OrderSingleton : MarshalByRefObject, OrderInterface
{
    ArrayList orderList;
    public event AlterDelegate alterEvent;
    uint id = 2;

    public OrderSingleton()
    {
        Console.WriteLine("Constructor called.");
        orderList = new ArrayList();
        Order order = new Order(1, "Massa à bolonhesa");
        Console.WriteLine("Default rrder created");
        orderList.Add(order);
    }

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public ArrayList GetList()
    {
        Console.WriteLine("GetList() called.");
        return orderList;
    }

    public uint GetNewID()
    {
        return id++;
    }

    public void AddItem(Order order)
    {
        orderList.Add(order);
        NotifyClients(Operation.New, order);
    }

    public bool ChangeState(uint id)
    {
        Order order = null;

        foreach (Order ord in orderList)
        {
            if (ord.Id == id)
            {
                if (ord.State != OrderState.Pronto)
                    ord.State++;
                else return false;
                order = ord;
                break;
            }
        }
        NotifyClients(Operation.Change, order);
        return true;
    }

    void NotifyClients(Operation op, Order order)
    {
        if (alterEvent != null)
        {
            Delegate[] invkList = alterEvent.GetInvocationList();

            foreach (AlterDelegate handler in invkList)
            {
                new Thread(() =>
                {
                    try
                    {
                        handler(op, order);
                        Console.WriteLine("Invoking event handler");
                    }
                    catch (Exception)
                    {
                        alterEvent -= handler;
                        Console.WriteLine("Exception: Removed an event handler");
                    }
                }).Start();
            }
        }
    }
}