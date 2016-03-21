using System;
using System.Collections;

[Serializable]
public class Order {
    #region GetsSets
    private uint id;
    public uint Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    private OrderState state;
    public OrderState State
    {
        get
        {
            return this.state;
        }
        set
        {
            this.state = value;
        }
    }

    private String description;
    public String Description
    {
        get
        {
            return this.description;
        }
        set
        {
            this.description = value;
        }
    }

    private uint quantity;
    public uint Quantity
    {
        get
        {
            return this.quantity;
        }
        set
        {
            this.quantity = value;
        }
    }

    private uint tableId;
    public uint TableId
    {
        get
        {
            return this.tableId;
        }
        set
        {
            this.tableId = value;
        }
    }

    private Local local;
    public Local Local
    {
        get
        {
            return this.local;
        }
        set
        {
            this.local = value;
        }
    }

    private uint price;
    public uint Price
    {
        get
        {
            return this.price;
        }
        set
        {
            this.price = value;
        }
    }
    #endregion

    public Order() : this(0, OrderState.NaoAtendido, "", 0, 0, Local.Kitchen, 0)
    {

    }

    //Dummy constructor
    public Order(uint id, String description)
    {
        this.id = id;
        this.description = description;
        this.state = OrderState.NaoAtendido;
    }

    public Order(uint id, OrderState state, String description, uint quantity, uint tableId, Local local, uint price)
    {
        this.id = id;
        this.price = price;
        this.state = state;
        this.description = description;
        this.quantity = quantity;
        this.tableId = tableId;
        this.local = local;
        this.price = price;
    }

    public String getStateString()
    {
        string orderStateS = null;
        switch (this.State)
        {
            case OrderState.NaoAtendido:
                orderStateS = "Request not met";
                break;
            case OrderState.EmPreparacao:
                orderStateS = "In preparation";
                break;
            case OrderState.Pronto:
                orderStateS = "Ready";
                break;
        }

        return orderStateS;
    }
}


public enum Local { Bar, Kitchen };

public enum OrderState { NaoAtendido, EmPreparacao, Pronto }

public enum Operation { New, Change };

public delegate void AlterDelegate(Operation op, Order item);

public interface OrderInterface {
  event AlterDelegate alterEvent;

  ArrayList GetList();
  uint GetNewID();
  void AddItem(Order item);
  bool ChangeState(uint id);
}

public class AlterEventRepeater : MarshalByRefObject {
  public event AlterDelegate alterEvent;

  public override object InitializeLifetimeService() {
    return null;
  }

  public void Repeater(Operation op, Order item) {
    if (alterEvent != null)
      alterEvent(op, item);
  }
}