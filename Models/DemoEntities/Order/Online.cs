using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Models
{
    public class Online
    {
        public string Id { get; set; }
        public string Dishname { get; set; }
        public string Prices { get; set; }
        public string Remarks { get; set; }
        public string Number { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public string StudentPhone { get; set; }
        public bool IsConfirm { get; set; } = false;
        public bool IsComplete { get; set; } = false;
    }
}
