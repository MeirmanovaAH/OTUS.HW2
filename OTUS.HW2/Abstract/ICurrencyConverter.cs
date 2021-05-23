
using System;
using System.Collections.Generic;
using System.Text;

namespace OTUS.HW2.Abstract
{
    public interface ICurrencyConverter
    {
        ICurrencyAmount ConvertCurrency(ICurrencyAmount amount, string currencyCode);
    }
}
