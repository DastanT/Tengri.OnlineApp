using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengri.ServiceUsers
{
    public class User
    {
        /// <summary>
        /// пароль 
        /// </summary>
        public int Id { get; set; }

        public string password { get; set; }

        public string login { get; set; }
        public string fullname { get; set; }
        public DateTime createdate { get; set; }
        public int status { get; set; }
        public int wrongpasswordcount { get; set; }
    }
}
