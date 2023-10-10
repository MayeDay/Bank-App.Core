using System;
using System.Collections.Generic;

namespace BankApp.Models;

public partial class TransactionHistory
{
    public int Id { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal? TransactionAmount { get; set; }

    public decimal? NewBalance { get; set; }

    public int? TransactionTypeId { get; set; }

    public int? AccountId { get; set; }

    public int? CustomerId { get; set; }

    public int? UserLoginId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual TransactionType? TransactionType { get; set; }

    public virtual UserLogin? UserLogin { get; set; }
}
