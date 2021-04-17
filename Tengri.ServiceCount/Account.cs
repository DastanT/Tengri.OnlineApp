using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengri.ServiceCount
{
    public class Account
    {
        ///Шаблон счета
        ///

        public int Id { get; set; }
        public int userId { get; set; }
        public string Iban { get; set; }
        public DateTime CreateDate{ get; set; }

        public decimal Balance { get; set; }

        public int Status { get; set; }

        public string GetStatusName 
        { 
            get
            {
                switch (Status)
                {
                    case 1:
                        return "Активный";
                    case 2:
                        return "Закрытый";
                    default:
                        return "Неопределенный статус";
                }
            }
        }

    }
}
