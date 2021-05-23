using Microsoft.Extensions.Caching.Memory;
using OTUS.HW2.Concrete;
using OTUS.HW2.Repository;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace OTUS.HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение для личного финансового учета");

            Trace.Listeners.Add(new ConsoleTraceListener());

            var currencyConverter = new ExchangeRatesApiConverter(new HttpClient(), new MemoryCache(new MemoryCacheOptions()), "a5cf9da55cb835d0a633a7825b3aa8b5");

            var transactionParser = new TransactionParser();
            // var transactionRepository = new InMemoryTransactionRepository();
            var transactionRepository = new FileTransactionRepository("transactions.txt", transactionParser);

            var budgetApp = new BudjetApplication(transactionRepository, transactionParser, currencyConverter);

            //budgetApp.AddTransaction("Трата -10 EUR Продукты A-Store");
            //budgetApp.AddTransaction("Трата -100 USD Бензин RP");
            //budgetApp.AddTransaction("Трата -50 EUR Кафе Turandot");
            //budgetApp.AddTransaction("Зачисление 2000 EUR Зарплата");
            //budgetApp.AddTransaction("Перевод 50 EUR Услуги BeeLine");

            budgetApp.OutputTransactions();

            budgetApp.OutputBalanceInMainCurrencies();

            var flagContinue = true;

            while (flagContinue)
            {
                Console.WriteLine("Введите 1 - для ввода новой транзакции, 2 - вывести транзакции, 0 - Выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.KeyChar == '0')
                {
                    flagContinue = false;
                }
                else if (key.KeyChar == '1')
                {
                    Console.WriteLine("Введите транзакцию: ");
                    var input = Console.ReadLine();

                    budgetApp.AddTransaction(input);
                    budgetApp.OutputBalanceInMainCurrencies();

                }
                else if (key.KeyChar == '2')
                {
                    Console.WriteLine("Список транзакций:");
                    Console.WriteLine("======================");

                    budgetApp.OutputTransactions();
                    budgetApp.OutputBalanceInMainCurrencies();

                }
            }


        }


    }
}
