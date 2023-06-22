using Data.Repository.Base;
using Domain.Entities;
using Domain.Interfaces;
using MongoDB.Entities;

namespace Data.Repository;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public async Task<bool> CheckDataExistence(string firstname, string lastname, DateTimeOffset? dateOfBirth)
    {
        return await DB.Find<Customer>()
            .Match(c => c.Firstname == firstname &&
                         c.Lastname == lastname &&
                         c.DateOfBirth == dateOfBirth)
            .ExecuteAnyAsync();
    }

    public async Task<bool> IsDuplicateCustomer(Customer customer)
    {
        return await DB.Find<Customer>()
            .Match(c => c.Firstname == customer.Firstname &&
                         c.Lastname == customer.Lastname &&
                         c.Email == customer.Email &&
                         c.ID != customer.ID)
            .ExecuteAnyAsync();

    }

    public async Task<bool> IsExistEmail(string email)
    {
        return await DB.Find<Customer>()
             .Match(c => c.Email == email)
             .ExecuteAnyAsync();
    }
}
