﻿using POne.Core.CQRS;
using POne.Core.ValueObjects;
using POne.Domain.Entities;
using System;

namespace POne.Identity.Business.Commands.Inputs.Users
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public int CountryCode { get; set; }
        public string Password { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ReferencePoint { get; set; }
        public string Complement { get; set; }
        public Guid? AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountEmail { get; set; }

        public static implicit operator User(CreateUserCommand command)
        {
            return new User(
                command.Name,
                command.Email,
                command.BirthDate,
                new Address(
                    command.Street,
                    command.District,
                    command.Number,
                    command.City,
                    command.State,
                    command.Complement,
                    command.ZipCode
                ),
                new PhoneNumber(55, command.MobilePhone),
                new Password(command.Password)
            );
        }

        public static implicit operator Account(CreateUserCommand command)
        {
            return new Account(command.AccountName, command.AccountEmail);
        }
    }
}
