﻿using System;
using System.Collections.Generic;

namespace BankApp.Models;

public partial class AccountType
{
    public int Id { get; set; }

    public string? AccountTypeDescription { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
