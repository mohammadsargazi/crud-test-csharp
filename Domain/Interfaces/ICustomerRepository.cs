﻿using Domain.Interfaces.Base;

namespace Domain.Interfaces;
public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<bool> CheckDataExistence(string firstname, string lastname, DateTimeOffset? dateOfBirth);
    Task<bool> IsDuplicateCustomer(Customer customer);
    Task<bool> IsExistEmail(string email);
}
