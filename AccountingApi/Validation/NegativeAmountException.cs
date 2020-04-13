using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApi.Validation
{
    public class NegativeAmountException : Exception
    {
        public NegativeAmountException() : base("Result amount can't be less than zero")
        {
        }
    }
}
