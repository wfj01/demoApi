using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models.DemoEntities.Business
{
    public class BusinessLogin
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Shopname { get; set; }
        public string Shopaddress { get; set; }
        public string Phonenumber { get; set; }
        public string Selfintroduction { get; set; }
        public DateTime ?Createddate { get; set; } = new DateTime();
        public DateTime ?Updatedate { get; set; } = new DateTime();
        public string License { get; set; }
    }
}
