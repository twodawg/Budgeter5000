using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budget5000.Service.Service;
using Budget5000.Infrastructure.Model;

namespace Budget5000.Test
{
    [TestClass]
    public class TransactionServiceTest
    {
        [TestMethod]
        public void TransactionAdd()
        {
            var transactionService = new TransactionService();
            var transData = transactionService.GetTransactions();
            var transCount = transData.Count;

            transData.Add(new Transaction()
            {
                Description = "Test Transaction",
                TimeStamp = DateTime.Now,
            });

            Assert.AreEqual(++transCount, transData.Count);
        }
    }
}
