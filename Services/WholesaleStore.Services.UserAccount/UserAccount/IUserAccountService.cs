using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleStore.Services.UserAccount.UserAccount.Models;

namespace WholesaleStore.Services.UserAccount.UserAccount;

public interface IUserAccountService
{
    Task<UserAccountModel> Create(RegisterUserAccountModel model);
    Task<bool> IsEmpty();
}
