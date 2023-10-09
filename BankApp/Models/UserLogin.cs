using System;
using System.Collections.Generic;

namespace BankApp.Models;

public partial class UserLogin
{
    public int Id { get; set; }

    public string? UserLogin1 { get; set; }

    public byte[]? Password { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<LoginAccount> LoginAccounts { get; set; } = new List<LoginAccount>();

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
