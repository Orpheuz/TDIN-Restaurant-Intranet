using System;
using System.Collections;
using System.Threading;

public class OrderSingleton : MarshalByRefObject, OrderInterface
{
    ArrayList orderList;
    ArrayList tableList;
    public event AlterDelegate alterEvent;
    uint id = 2;

    public OrderSingleton()
    {
        Console.WriteLine("Constructor called.");
        orderList = new ArrayList();
        tableList = new ArrayList();
        Order order = new Order(1, "Massa à bolonhesa", 2, 1, Local.Bar, 10);
        Console.WriteLine("Default order created");
        orderList.Add(order);

        for (uint i = 0; i < 10; i++)
        {
            Table table = new Table(i);
            tableList.Add(table);
        }
    }

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public ArrayList GetListOfOrders()
    {
        Console.WriteLine("GetListOfOrders() called.");
        return orderList;
    }

    public ArrayList GetListOfTables()
    {
        Console.WriteLine("GetListOfTables() called.");
        return tableList;
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
        if (order.State == OrderState.Pronto)
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