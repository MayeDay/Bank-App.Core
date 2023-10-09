using System;
using System.Collections.Generic;

namespace BankApp.Models;

public partial class TransactionType
{
    public int Id { get; set; }

    public string TransactionTypeName { get; set; } = null!;

    public string? TransactionTypeDescription { get; set; }

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
