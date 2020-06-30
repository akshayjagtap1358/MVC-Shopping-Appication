using OnlineShoppingStore.Domain.Entities;
using OnlineShoppingStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete_database
{
    public class EmailOrderProcesser : IOrderProcesser
    {
        private EmailSettings emailSettings;

        public EmailOrderProcesser(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                        emailSettings.Password);

                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");
                foreach (var line in cart.CartLines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})\n",
                        line.Quantity,
                        line.Product.Name,
                        subtotal);
                }
                body.AppendFormat("Total order value: {0:c}",
                    cart.CalculateTotalSum())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? "")
                    .AppendLine(shippingDetails.Line3 ?? "")
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.State ?? "")
                    .AppendLine(shippingDetails.Country)
                    .AppendLine(shippingDetails.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}",
                        shippingDetails.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(new MailAddress(emailSettings.MailFromAddress).Address,
                    new MailAddress(emailSettings.MailToAddress).Address,
                    "New order submitted!",
                    body.ToString());

                smtpClient.Send(mailMessage);
            }
        }
    }
}
