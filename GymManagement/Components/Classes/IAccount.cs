using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Components.Classes
{
	public interface IAccount
	{
		void CreateAccountList(string AccountType);

		List<Account> ReadAccounts(string AccountType);

		void AddAccount(Account account, string AccountType);

	}
}
