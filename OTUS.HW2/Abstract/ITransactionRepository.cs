using System;
using System.Collections.Generic;
using System.Text;

namespace OTUS.HW2.Abstract
{
    public interface ITransactionRepository
    {
        void AddTransaction(ITransaction transaction);
        ITransaction[] GetTransactions();
    }
}