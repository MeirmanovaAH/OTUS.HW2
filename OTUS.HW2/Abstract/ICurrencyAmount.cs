using System;
using System.Collections.Generic;
using System.Text;

namespace OTUS.HW2.Abstract
{
    public interface ICurrencyAmount
    {
        string CurrencyCode { get; }
        decimal Amount { get; }
    }
}
