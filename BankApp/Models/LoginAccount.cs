using System;
using System.Collections.Generic;

namespace BankApp.Models;

public partial class LoginAccount
{
    public int Id { get; set; }

    public int? UserLoginId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual UserLogin? UserLogin { get; set; }
}
