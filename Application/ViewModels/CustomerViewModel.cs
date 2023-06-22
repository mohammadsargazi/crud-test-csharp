﻿namespace Application.ViewModels;

public class CustomerViewModel
{
    public string Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get;  set; }
    public DateTimeOffset? DateOfBirth { get;  set; }
    public string PhoneNumber { get;  set; }
    public string Email { get;  set; }
    public string BankAccountNumber { get;  set; }
}
