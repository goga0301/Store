using RabbitMQ.Domains.Core.Events;
using Store.Domain.Entities;
using Store.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models.Domain
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public TransactionStatusEnum Status { get; set; }
        public RecordStatusEnum RecordStatus { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string CreateUserId { get; set; }
    }

    public class CreateTransactionModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CardId { get; set; }
        public decimal Amount { get; set; }
    }

    public class UpdateTransactionModel
    {
        public int Id { get; set; }
        public TransactionStatusEnum Status { get; set; }
    }

    public class CreateTransactionEvent : Event
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public CardModelForTransaction Card { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }


}
