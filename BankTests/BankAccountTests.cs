using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS; 

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 15.97;
            double debitAmount = -150.00;
            BankAccount account = new BankAccount("Mr.Ben", beginningBalance);

            // Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 12.59;
            double debitAmount = 23.0;
            BankAccount account = new BankAccount("Mr.Ben", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
