using System;
using System.Collections.Generic;
using System.Text;

namespace Operators.Service.Model
{
    public class Operator
    {
        public string Logo { get; set; }
        public string Name { get; set; }
        public double Persentage { get; set; }

        public List<int> Prefixes = new List<int>();

    }
}
