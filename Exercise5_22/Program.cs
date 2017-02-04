using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a coffee vending machine class. Include fields giving the number of cups of coffee
//available, the cost of one cup of coffee, and the total amount of money inserted by
//the user.This machine requires exact change.Include one constructor that stocks the machine
//with a quantity and price of coffee specified as parameters, and another constructor
//with no parameters that stocks the machine with 10 cups of coffee at 50 cents each.
//Include the following methods:
//    Menu() // displays the quantity and price of coffee
//    Insert(int quarters, int dimes, int nickels)
//    // inserts the given amount
//    Select() // dispenses a cup of coffee if user has inserted enough
//    // money and coffee is available,
//    // otherwise displays a message.
//    Refund() // returns the money inserted
//Write a Main method to create some vending machines and test their operation.


namespace Exercise5_22
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeVendingMachine testVend = new CoffeeVendingMachine();
            testVend.Menu();
            testVend.Insert(4, 0, 0);
            testVend.Select();

            CoffeeVendingMachine anotherTestVend = new CoffeeVendingMachine(5, 1.0);
            anotherTestVend.Menu();
            anotherTestVend.Insert(1, 1, 5);
            anotherTestVend.Select();
            anotherTestVend.Refund();
        }
    }

    class CoffeeVendingMachine
    {
        private int coffeeCups = 0;
        private double price = 0.0;
        private double balance = 0.0;

        //Default constructor that sets 10 cups for $.50 each
        public CoffeeVendingMachine()
        {
            coffeeCups = 10;
            price = .50;
        }

        //Constructor that sets amount of coffee cups and price
        public CoffeeVendingMachine(int cups, double price)
        {
            this.coffeeCups = cups;
            this.price = price;
        }

        //Displays to console the number of cups and price of each cup
        public void Menu()
        {
            Console.WriteLine("Coffee cups: " + coffeeCups);
            Console.WriteLine("Price per cup: " + price);
        }

        //Adds total of money inserted into balance of machine
        public void Insert(int quarters, int dimes, int nickels)
        {
            double total = 0;

            if (quarters > 0)
            {
                total += quarters * 0.25;
            }
            if(dimes > 0)
            {
                total += dimes * .10;
            }
            if(nickels > 0)
            {
                total += nickels * .05;
            }

            balance += total;
            Console.WriteLine("You have inserted $" + total + ".");

        }

        //Checks to ensure sufficient balance, then dispenses coffee cup
        public void Select()
        {
            if(balance >= price)
            {
                coffeeCups--;
                balance -= price;
                Console.WriteLine("Dispensed 1 coffee cup.");
            }
            else
            {
                Console.WriteLine("Insufficient Funds. Please insert more money.");
            }
        }

        //Refunds balance, sets balance back to 0.00
        public void Refund()
        {
            Console.WriteLine("$" + balance + " has been refunded.");
            balance = 0.0;
        }
    }
}
