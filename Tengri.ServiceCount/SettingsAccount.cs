using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tengri.ServiceUsers;


namespace Tengri.ServiceCount
{
    public class SettingsAccount
    {
        ///создать счет
        ///

        private Tengri.DAL.LiteDbEntity db = null;
        public ServiceUsers.ServicesUser servicesUser = null;
        public SettingsAccount(string connectionString)
        {
            db = new DAL.LiteDbEntity(connectionString);
            servicesUser = new ServiceUsers.ServicesUser(connectionString);
        }
        /// <summary>
        /// Метод который возвращает список счетов пользователя
        /// </summary>
        /// <param name="userId">ID пользователя в системе</param>
        /// <returns>Коллекцию счетов типа List</returns>
        public List<Account> GetUserAccounts(int userId)
        {
            List<Account> accounts = new List<Account>();
            accounts = db.GetCollection<Account>();
            return accounts.Where(w => w.userId == userId).ToList();
        }

        public bool CreateAccount(int userId, out Account account)
        {
            Random rnd = new Random();
            string message = "";
            account = new Account();

            if (userId == 0 || userId < 0)
            
               throw new Exception("Пользователя не существует");
            else if (servicesUser.IsExist(userId))
            {
                
                account.userId = userId;
                account.Iban = "KZ" + rnd.Next(1, 100);
                if (db.Create<Account>(account, out message))
                {
                    return true;
                }
                else
                {
                    throw new Exception(message);
                }
            }
            else
            {
                return false;
            }
        }

        //public int AddMoney(Account account)
        //{

        //}

    }
}
