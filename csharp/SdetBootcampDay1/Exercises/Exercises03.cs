using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises03
    {
        [Test]
        public void TryingToOverdrawOnASavingsAccountThrowsExpectedException()
        {
            /**
             * TODO: Create a new savings account and deposit 50.
             * Verify that attempting to withdraw 100 throws an ArgumentException
             * Also verify the exception message to be 'You cannot overdraw on a savings account'
             * Finally, verify that the account balance is unchanged (i.e., you still have $50)
             */

            var account = new Account(AccountType.Savings);

            account.Deposit(50);
            bool withdraw_successful = true;

            try
            {
            account.Withdraw(100);
            }
            catch (ArgumentException e)
            {
                withdraw_successful = false;
            }

            Assert.That(withdraw_successful, Is.EqualTo(true));
        }
    }
}
