using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models
{
    public class Online
    {
        public string Id { get; set; }
        public string Shoppingid { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Dishname { get; set; }
        public string Price { get; set; }
        public string SumPrice { get; set; }
        public string Remarks { get; set; }
        public string Time { get; set; }
        public string Number { get; set; }
        public string Windows { get; set; }
        public string ImageSrc { get; set; }
        public string Guige1 { get; set; }
        public string Ladu { get; set; }
        public string IsSubmit { get; set; }
        public string IsConfirm { get; set; }
        public string IsComplete { get; set; }
        public string IsEvaluate { get; set; }
    }

    public class IdList {
        public string OrderId { get; set; }
    }
}
