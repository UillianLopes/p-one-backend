﻿using POne.Core.Entities;
using POne.Core.Enums;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Entities
{
    public class Entry : Entity
    {
        protected Entry() : base()
        {
            Payments = new HashSet<Payment>();
            Children = new HashSet<Entry>();
        }

        private Entry(
            DateTime? dueDate,
            decimal value,
            EntryOperation operation,
            string barCode, string currency,
            string description, string title,
            Category category,
            SubCategory subCategory,
            Entry parent,
            Guid? accountId,
            Guid? userId,
            EntryRecurrence? recurrence,
            DateTime? recurrenceBegin,
            DateTime? recurrenceEnd,
            DayOfWeek? recurrenceDayOfWeek,
            int? recurrenceDayOfMonth,
            Guid? installmentId,
            int? installments,
            int? index
        ) : this()
        {
            DueDate = dueDate;
            Value = value;
            Operation = operation;
            BarCode = barCode;
            Currency = currency;
            Description = description;
            Title = title;
            Category = category;
            SubCategory = subCategory;
            Parent = parent;
            AccountId = accountId;
            UserId = userId;

            Recurrence = recurrence;
            RecurrenceBegin = recurrenceBegin;
            RecurrenceEnd = recurrenceEnd;
            RecurrenceDayOfWeek = recurrenceDayOfWeek;
            RecurrenceDayOfMonth = recurrenceDayOfMonth;

            InstallmentId = installmentId;
            Index = index;
            Installments = installments;
        }

        public static Entry Standard(
            Guid? accountId,
            Guid? userId,
            DateTime dueDate,
            decimal value,
            EntryOperation operation,
            string barCode,
            string currency,
            string description,
            string title,
            Category category,
            SubCategory subCategory,
            Entry parent
        )
        {
            return new Entry(
                dueDate,
                value,
                operation,
                barCode,
                currency,
                description,
                title,
                category,
                subCategory,
                parent,
                accountId,
                userId,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );
        }

        public static Entry Recurrent(
                Guid? accountId,
                Guid? userId,
                decimal value,
                EntryOperation operation,
                string barCode,
                string currency,
                string description,
                string title,
                Category category,
                SubCategory subCategory,
                Entry parent,
                EntryRecurrence recurrence,
                DateTime recurrenceBegin,
                DateTime? recurrenceEnd,
                DayOfWeek? recurrenceDayOfWeek,
                int? recurrenceDayOfMonth
            )
        {
            return new Entry(
                null,
                value,
                operation,
                barCode,
                currency,
                description,
                title,
                category,
                subCategory,
                parent,
                accountId,
                userId,
                recurrence,
                recurrenceBegin,
                recurrenceEnd,
                recurrenceDayOfWeek,
                recurrenceDayOfMonth,
                null,
                null,
                null
            );
        }

        public static Entry Installment(
               Guid? accountId,
               Guid? userId,
               DateTime dueDate,
               decimal value,
               EntryOperation operation,
               string barCode,
               string currency,
               string description,
               string title,
               Category category,
               SubCategory subCategory,
               Entry parent,
               Guid installmentId,
               int installments,
               int index
           )
        {
            return new Entry(
                dueDate,
                value,
                operation,
                barCode,
                currency,
                description,
                title,
                category,
                subCategory,
                parent,
                accountId,
                userId,
                null,
                null,
                null,
                null,
                null,
                installmentId,
                installments,
                index
            );
        }

        public DateTime? DueDate { get; private set; }
        public DateTime? RecurrenceBegin { get; private set; }
        public DateTime? RecurrenceEnd { get; private set; }
        public decimal Value { get; private set; }
        public EntryOperation Operation { get; private set; }
        public EntryRecurrence? Recurrence { get; private set; }
        public Guid? AccountId { get; private set; }
        public Guid? InstallmentId { get; private set; }
        public Guid? UserId { get; private set; }
        public int? Index { get; private set; }
        public int? Installments { get; private set; }
        public int? RecurrenceDayOfMonth { get; private set; }
        public DayOfWeek? RecurrenceDayOfWeek { get; private set; }
        public string BarCode { get; private set; }
        public string Currency { get; private set; }
        public string Description { get; private set; }
        public string Title { get; private set; }
        public virtual Category Category { get; private set; }
        public virtual Entry Parent { get; private set; }
        public virtual SubCategory SubCategory { get; private set; }
        public virtual ISet<Entry> Children { get; private set; }
        public virtual ISet<Payment> Payments { get; private set; }

        public void Update(
            string title,
            string description,
            string barCode,
            string currency,
            decimal value,
            DateTime dueDate,
            Category category,
            SubCategory subCategory
        )
        {
            DueDate = dueDate;
            Title = title;
            Description = description;
            BarCode = barCode;
            Currency = currency;
            Value = value;
            Category = category;
            SubCategory = subCategory;
        }

        public Entry GenerateChildEntry(DateTime dueDate) => Standard(AccountId, UserId, dueDate, Value, Operation, null, Currency, Description, Title, Category, SubCategory, this);

        public void Pay(Wallet wallet, decimal value, decimal fees = 0.00m, decimal fine = 0.00m)
        {
            var payment = new Payment(value, fees, fine, this, wallet);

            Payments.Add(payment);

            if (Operation == EntryOperation.Credit)
                wallet.Add(value);
            else
                wallet.Subtract(value);
        }

        public void RevertPayments()
        {
            foreach (var payment in Payments)
                payment.Revert();
        }
    }
}
