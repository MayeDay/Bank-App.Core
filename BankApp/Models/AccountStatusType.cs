using System;
using System.Collections.Generic;

namespace BankApp.Models;

public partial class AccountStatusType
{
    public int Id { get; set; }

    public string? AccountStatusDescription { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
