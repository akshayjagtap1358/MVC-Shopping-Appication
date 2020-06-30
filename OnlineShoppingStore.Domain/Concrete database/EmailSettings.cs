using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete_database
{
    public class EmailSettings
    {
        public string MailToAddress = "jagtapakshay1358@gmail.com";
        public string MailFromAddress = "jagtapakshay1358@gmail.com";
        public bool UseSsl = true;
        public string Username = "jagtapakshay1358@gmail.com";
        public string Password = "sakshays"; // Create your own google app password, In the video I have shown you how to create app password.
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
