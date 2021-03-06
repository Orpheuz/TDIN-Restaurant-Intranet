﻿using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

public class OrderSingleton : MarshalByRefObject, OrderInterface
{
    ArrayList orderList;
    ArrayList tableList;
    public event AlterDelegate alterEvent;
    uint id = 1;
    uint serviceID = 1;

    public OrderSingleton()
    {
        orderList = new ArrayList();
        tableList = new ArrayList();
        for (uint i = 0; i < 10; i++)
        {
            Table table = new Table(i + 1);
            tableList.Add(table);
        }
    }

    public override object InitializeLifetimeService()
    {
        return null;
    }

    public ArrayList GetListOfOrders()
    {
        return orderList;
    }

    public ArrayList GetListOfTables()
    {
        return tableList;
    }

    public uint GetNewID()
    {
        return id++;
    }

    public void UpdateOrderID()
    {
        uint max = 0;

        if (orderList.Count == 0)
            return;

        foreach (Order ord in orderList)
        {
            if (ord.Id > max)
                max = ord.Id;
        }
        id = max + 1;
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

        foreach (Order order in orderList)
        {
            if (order.TableId == tableID && !order.PaymentDone)
            {
                orders.Add(order);
                tempOrder = order;
            }
        }
        if (orders.Count == 0)
            return orders;

        if (notify)
        {
            foreach (Table tab in tableList)
            {
                if (tab.Id == tableID)
                {
                    tab.Availability = false;
                }
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

    public void SerializeOrdersAndTables()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("orders.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        formatter.Serialize(stream, orderList);
        stream = new FileStream("tables.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        formatter.Serialize(stream, tableList);
        stream.Close();
    }

    public void DeserializeOrdersAndTables()
    {
        IFormatter formatter = new BinaryFormatter();
        if (File.Exists("orders.bin"))
        {
            Stream stream = new FileStream("orders.bin", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            ArrayList obj = (ArrayList)formatter.Deserialize(stream);
            stream.Close();

            orderList = obj;
        }
        if (File.Exists("tables.bin"))
        {
            Stream stream = new FileStream("tables.bin", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            ArrayList obj = (ArrayList)formatter.Deserialize(stream);
            stream.Close();

            tableList = obj;
        }
    }

    public ArrayList GetListFromDate(DateTime date)
    {
        ArrayList temp = new ArrayList();

        foreach (Order ord in orderList)
        {
            if (ord.Date.Day == date.Day && ord.Date.Month == date.Month && ord.Date.Year == date.Year)
                temp.Add(ord);
        }

        return temp;
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
                    }
                    catch (Exception)
                    {
                        alterEvent -= handler;
                    }
                }).Start();
            }
        }
    }
}