using System;
using System.Collections.Generic;
using System.Text;

namespace Сartridges_storage.Model
{
    public class Transaction
    {
        private int transactionId;
        private string cartridgeName;
        private int quantity;
        private int orderId;
        private int operationId;
        private DateTime transactionDate;

        public int TransactionId
        {
            get { return transactionId; }
            set { transactionId = value; }
        }
        public string CartridgeName
        {
            get { return cartridgeName; }
            set { cartridgeName = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public int OperationId
        {
            get { return operationId; }
            set { operationId = value; }
        }
        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }
    }
}
