using System;
using System.Collections.Generic;
using System.Text;

namespace OTUS.HW2.Abstract
{
    public interface ITransaction
    {
        DateTimeOffset Date { get; }
        ICurrencyAmount Amount { get; }
    }
}

