using System;
using System.Collections.Generic;

namespace BankApp.Models;

public partial class Account
{
    public int Id { get; set; }

    public decimal CurrentBalance { get; set; }

    public decimal AvailableBalance { get; set; }

    public string AccountNumber { get; set; } = null!;

    public DateTime? MadeOn { get; set; }

    public DateTime? LastModified { get; set; }

    public int? AccountTypeId { get; set; }

    public int? AccountStatusTypeId { get; set; }

    public virtual AccountStatusType? AccountStatusType { get; set; }

    public virtual AccountType? AccountType { get; set; }

    public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();

    public virtual ICollection<LoginAccount> LoginAccounts { get; set; } = new List<LoginAccount>();

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
