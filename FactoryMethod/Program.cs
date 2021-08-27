using System;
using System.Linq;

namespace FactoryMethod
{
    enum Skills
    {
        Jenkins,
        Docker,
        TeamCity,
        CSharp,
        CleanCode,
        Selenium,
        Postman,
        BlazeMeter
    }

    interface IEmployee
    {

    }

    class DevOps : IEmployee
    {

    }

    class CSharpDeveloper : IEmployee
    {

    }

    class Tester : IEmployee
    {

    }

    interface IHiringAgency
    {
        IEmployee Hire(Skills[] expectedSkills);
    }

    class EmployeeFactory : IHiringAgency
    {
        public IEmployee Hire(Skills[] expectedSkills)
        {
            if (Enumerable.SequenceEqual(expectedSkills, 
                new[] { Skills.Jenkins, Skills.Docker, Skills.TeamCity }))
            {
                return new DevOps();
            }
            if (Enumerable.SequenceEqual(expectedSkills, 
                new[] { Skills.CSharp, Skills.CleanCode }))
            {
                return new CSharpDeveloper();
            }
            if (Enumerable.SequenceEqual(expectedSkills, 
                new[] { Skills.Selenium, Skills.Postman, Skills.BlazeMeter }))
            {
                return new Tester();
            }
            throw new ArgumentException("Unexpected skillset");

        }
    }

    //this class implement STATIC Factory Method design pattern - not to be confused with Factory Method design pattern!
    class BankAccount
    {
        private int _maxWithdrawalSum;

        private BankAccount(bool isForChildren)
        {
            if (isForChildren)
            {
                _maxWithdrawalSum = 1000;
            }
            else
            {
                _maxWithdrawalSum = 10000;
            }
        }

        public static BankAccount ForChildren()
        {
            return new BankAccount(true);
        }

        public static BankAccount Regular()
        {
            return new BankAccount(false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var firstEmployeeRequiredSkills = new[] { Skills.Jenkins, Skills.Docker, Skills.TeamCity };
            var secondEmployeeSkills = new[] { Skills.CSharp, Skills.CleanCode };
            var thirdEmployeeSkills = new[] { Skills.Selenium, Skills.Postman, Skills.BlazeMeter };

            var employee = new EmployeeFactory().Hire(firstEmployeeRequiredSkills);
            Console.WriteLine($"Hired employee is {employee}");

            var bankAccount = BankAccount.ForChildren();
            var otherBankAccount = BankAccount.Regular();

            Console.ReadKey();
        }
    }
}
