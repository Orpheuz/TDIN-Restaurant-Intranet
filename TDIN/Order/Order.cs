using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Order : MarshalByRefObject
    {

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

        private String state;
        public String State
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

        private bool type;
        public bool Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
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
    }
}
