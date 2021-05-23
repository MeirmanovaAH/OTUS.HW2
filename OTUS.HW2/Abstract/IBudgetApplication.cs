﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OTUS.HW2.Abstract
{
    public interface IBudgetApplication
    {
        void AddTransaction(string input);
        void OutputTransactions();
        void OutputBalanceInCurrency(string currencyCode);
    }
}
