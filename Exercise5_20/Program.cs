using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//For the Warehouse class of Exercise 16, overload the Warehouse constructor by adding
//another constructor to create a warehouse with specified initial quantities of radios, televisions,
//and computers.Revise the Main method to include tests of this new constructor.


namespace Exercise5_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse testWare = new Warehouse();
            testWare.addRadios(2);
            testWare.addTelevisions(3);
            testWare.addComputers(1);
            Console.WriteLine(testWare.toString());

            Warehouse anotherTestWare = new Warehouse(2, 4, 7);
            Console.WriteLine(anotherTestWare.toString());
        }
    }

    class Warehouse
    {
        private int radioQty = 0;
        private int televisionQty = 0;
        private int computerQty = 0;

        public Warehouse()
        {

        }

        public Warehouse(int radios, int televisions, int computers)
        {
            this.radioQty = radios;
            this.televisionQty = televisions;
            this.computerQty = computers;
        }

        public void addRadios(int x)
        {
            radioQty += x;
        }

        public void addTelevisions(int x)
        {
            televisionQty += x;
        }

        public void addComputers(int x)
        {
            computerQty += x;
        }

        //Getter/Setter methods for instance variables
        public void setRadioQty(int x)
        {
            this.radioQty = x;
        }

        public int getRadioQty()
        {
            return radioQty;
        }

        public void setTelevisionQty(int x)
        {
            this.televisionQty = x;
        }

        public int getTelevisitionQty()
        {
            return televisionQty;
        }

        public void setComputerQty(int x)
        {
            this.computerQty = x;
        }

        public int getComputerQty()
        {
            return computerQty;
        }

        public String toString()
        {
            return "Radio Quantity: " + radioQty + ", Television Quantity: " + televisionQty + ", Computer Quantity: " + computerQty;
        }
    }
}
