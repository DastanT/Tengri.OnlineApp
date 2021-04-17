using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengri.ServiceUsers
{
    public class ServicesUser
    {
        private DAL.LiteDbEntity db = null;

        public ServicesUser(string connectionString)
        {
            db = new DAL.LiteDbEntity(connectionString);
        }

        //регистрация
        public bool Registration(User user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                string message = "";
                if (db.Create<User>(user, out message))
                {
                    throw new Exception(message);
                }
                else
                    return true;
            }
                //return db.Create<User>(user, out message);
        }

        //наличие пользователя
        public User IsExist(string login)
        {
            List<User> users = db.GetCollection<User>();
            return users
                .Where(w => w.login == login)
                .FirstOrDefault();
        }
        //авторизация
        //восстановление пароля
        //изменение пароля
        //блокировка учетной записи

        //public bool IsExistUser(string login)
        //{
        //    List<User> users = db.GetCollection<User>();
        //      return users.Where(w => w.login == login && password == password)
        //        .FirstOrDefault();
        //}

        public bool IsExist(int userId)
        {
            List<User> users = db.GetCollection<User>();
            return users
                .Where(w => w.Id == userId)
                .Any();
        }

        public User GetUser(string login, string password)
        {
            string message = "";
            User user = IsExist(login);
            if (user!=null)
            {
                if(user.password != password)
                {
                    if (user.wrongpasswordcount == 3)
                        user.status = 2;//заблокирован
                    user.wrongpasswordcount = user.wrongpasswordcount + 1;
                    db.Update<User>(user, out message);
                }
                else if (user.password == password)
                {
                    
                }
            }
            return user;
              

        }



    }
}
