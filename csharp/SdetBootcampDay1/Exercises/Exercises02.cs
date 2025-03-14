using System.Runtime.Serialization.Formatters;
using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        /**
         * TODO: rewrite these three tests into a single, parameterized test.
         * You decide if you want to use [TestCase] or [TestCaseSource], but
         * I would like to know why you chose the option you chose afterwards.
         */
         /*
        [Test]
        public void CreateNewSavingsAccount_Deposit100Withdraw50_BalanceShouldBe50()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(100);
            account.Withdraw(50);

            Assert.That(account.Balance, Is.EqualTo(50));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit1000Withdraw1000_BalanceShouldBe0()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(1000);
            account.Withdraw(1000);

            Assert.That(account.Balance, Is.EqualTo(0));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit250Withdraw1_BalanceShouldBe249()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(250);
            account.Withdraw(1);

            Assert.That(account.Balance, Is.EqualTo(249));
        }
        */

        [Test, TestCaseSource("BalanceTest")]
        public void VerifySavingsBalance(int deposit_amount, int withdraw_amount, int balance_to_verify)
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(deposit_amount);
            account.Withdraw(withdraw_amount);

            Assert.That(account.Balance, Is.EqualTo(balance_to_verify));
        }
        
        struct TestCaseInfo
        {
            public int DepositAmount;
            public int WithdrawAmount;
            public int BalanceToVerify;

            public string GetCaseName()
            {
                return "Deposit: " + DepositAmount + "| Withdraw: " + WithdrawAmount + "| Balance to Verify: " + BalanceToVerify;
            }
        }

        private static IEnumerable<TestCaseData> BalanceTest()
        {
            Random rand = new Random();
            
            // Initialize new array of predefined test cases
            TestCaseInfo[] StaticTestCases = new TestCaseInfo[]{
                new TestCaseInfo {DepositAmount = 100, WithdrawAmount = 50, BalanceToVerify = 50},
                new TestCaseInfo {DepositAmount = 1000, WithdrawAmount = 1000, BalanceToVerify = 0},
                new TestCaseInfo {DepositAmount = 250, WithdrawAmount = 249, BalanceToVerify = 1},
                new TestCaseInfo {DepositAmount = 1000, WithdrawAmount = 500, BalanceToVerify = 500}
            };

            int h = 0;
            // Verify static cases
            foreach(TestCaseInfo t in StaticTestCases)
            {
                yield return new TestCaseData(t.DepositAmount, t.WithdrawAmount, t.BalanceToVerify).SetName(t.GetCaseName());
                Console.WriteLine("Instantiate dynamic test case {0}", h++);
            }

            // Initialize array of randomized test cases
            TestCaseInfo[] DynamicTestCases = new TestCaseInfo[5];

            for (int i = 0; i < 5; i++)
            {
                int deposit_amount = rand.Next(500, 1000);
                int withdraw_amount = rand.Next(0, 500);
                int balance_to_verify = deposit_amount + withdraw_amount;

                DynamicTestCases[i] = new TestCaseInfo {DepositAmount = deposit_amount, WithdrawAmount = withdraw_amount, BalanceToVerify = balance_to_verify};

                Console.WriteLine("Instantiate dynamic test case {0}", i);
            }


            int j = 0;
            // Verify dynamic cases
            foreach(TestCaseInfo t in DynamicTestCases)
            {
                string case_name = "Randomized Case " + j;
                yield return new TestCaseData(t.DepositAmount, t.WithdrawAmount, case_name);
                Console.WriteLine("Instantiate dynamic test case {0}", j++);
            }
        }
    }
}
