using System;
using System.Collections.Generic;

namespace BankApp.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Suffix { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string Email { get; set; } = null!;

    public string? HomePhone { get; set; }

    public string? MobilePhone { get; set; }

    public string? Ssn { get; set; }

    public string? ProfileImg { get; set; }

    public int? UserLoginId { get; set; }

    public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();

    public virtual UserLogin? UserLogin { get; set; }
}
