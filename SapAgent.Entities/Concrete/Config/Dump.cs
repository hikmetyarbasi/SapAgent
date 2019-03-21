using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.Entities.Concrete.General.@enum;

namespace SapAgent.Entities.Concrete.Config
{
    public class Dump
    {
        public string ErrorId { get; set; }
        public int Amount { get; set; }
        public Category Category { get; set; }
    }
}
