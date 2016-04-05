using System;
using System.Collections;
using System.Threading;

public class OrderSingleton : MarshalByRefObject, OrderInterface
{
    ArrayList orderList;
    ArrayList tableList;
    public event AlterDelegate alterEvent;
    uint id = 1;
    uint serviceID = 1;

    public OrderSingleton()
    {
        Console.WriteLine("Constructor called.");
        orderList = new ArrayList();
        tableList = new ArrayList();
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

    public uint GetNewServiceID()
    {
        return serviceID++;
    }

    public void AddOrder(Order order)
    {
        orderList.Add(order);

        NotifyClients(Operation.New, order);
    }

    public bool ChangeState(bool fromRoom, uint id)
    {
        Order order = null;

        foreach (Order ord in orderList)
        {
            if (ord.Id == id)
            {
                if (fromRoom)
                {
                    if (ord.State == OrderState.Delivered)
                    {
                        return false;
                    }
                    else if (ord.State == OrderState.Ready)
                    {
                        ord.State++;
                    }
                    else return false;
                }
                else
                {
                    if (ord.State != OrderState.Ready && ord.State != OrderState.Delivered)
                        ord.State++;
                    else return false;
                }
                order = ord;
                break;
            }
        }
        NotifyClients(Operation.Change, order);
        return true;
    }

    public ArrayList ConsultTable(uint tableID, bool notify)
    {
        Order tempOrder = null;
        ArrayList orders = new ArrayList();

        foreach(Order order in orderList)
        {
            if (order.TableId == tableID && !order.PaymentDone)
            {
                orders.Add(order);
                tempOrder = order;
            }
        }

        foreach (Table tab in tableList)
        {
            if (tab.Id == tableID)
            {
                tab.Availability = false;
            }
        }

        if (notify && orders.Count != 0)
            NotifyClients(Operation.Print, tempOrder);

        return orders;
    }

    public void ProcessPayment(uint tableID)
    {
        foreach (Order order in orderList)
        {
            if (order.TableId == tableID)
            {
                order.PaymentDone = true;
            }
        }

        foreach (Table tab in tableList)
        {
            if (tab.Id == tableID)
            {
                tab.Availability = true;
            }
        }       
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