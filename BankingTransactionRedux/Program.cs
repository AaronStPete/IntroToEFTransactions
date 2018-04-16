using BankingTransactionRedux.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingTransactionRedux
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DataContext();

            //query to insert transaction
            //var newTransaction = new Transactions
            //{
            //    Timestamp = new DateTime(2018, 01, 01),
            //    Action = "Opened new account",
            //    AccountNumber = "0002",
            //    AmountChanged = 100m,
            //    NewAmount = 100m
            //};

            //var new1 = new Transactions
            //{
            //    Timestamp = new DateTime(2018, 01, 10),
            //    Action = "deposited",
            //    AccountNumber = "0002",
            //    AmountChanged = 100m,
            //    NewAmount = 800m
            //};

            //var new2 = new Transactions
            //{
            //    Timestamp = new DateTime(2018, 01, 11),
            //    Action = "deposited",
            //    AccountNumber = "0002",
            //    AmountChanged = 100m,
            //    NewAmount = 900m
            //};

            //var new3 = new Transactions
            //{
            //    Timestamp = new DateTime(2018, 01, 12),
            //    Action = "deposited",
            //    AccountNumber = "0002",
            //    AmountChanged = 100m,
            //    NewAmount = 1000m
            //};

            //var new4 = new Transactions
            //{
            //    Timestamp = new DateTime(2018, 01, 13),
            //    Action = "deposited",
            //    AccountNumber = "0002",
            //    AmountChanged = 100m,
            //    NewAmount = 1100m
            //};

            //dbContext.Transactions.Add(new1);
            //dbContext.Transactions.Add(new2);
            //dbContext.Transactions.Add(new3);
            //dbContext.Transactions.Add(new4);
            dbContext.SaveChanges();

            //Create a query that finds all transaction from Today
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var todaysTransactions = dbContext.Transactions.Where(search => search.Timestamp < tomorrow && search.Timestamp > today);

            foreach (var transaction in todaysTransactions)
            {
                Console.WriteLine($"{transaction.Timestamp} {transaction.Action}");
            }

            //Create a query that counts all transactions for a Given Day and given day
            var searchDay = new DateTime(2018, 01, 02);
            var searchOnDay = dbContext.Transactions.Where(search => search.Timestamp == searchDay);
            int count = 0;
            foreach (var transaction in searchOnDay)
            {
                count++;
            }
            Console.WriteLine(count);

            //Ten most recent transactions for a given user

            var tenRecent = dbContext.Transactions.Where(transaction => transaction.AccountNumber == "0002").OrderByDescending(criteria => criteria.Timestamp).Take(10);
            foreach (var post in tenRecent)
            {
                Console.WriteLine($"{post.Timestamp} {post.Action}");
            }
        }
    }
}
