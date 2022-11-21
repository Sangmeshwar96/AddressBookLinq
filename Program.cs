using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book linq problem!");
            AddressBook addressBook = new AddressBook();
            int loop = 1;
            while (loop == 1)
            {
                Console.WriteLine("Enter your choice: \n1.Insert a new contact \n" +
                "2.Display existing contact" +
                " \n3.Edit existing contact " +
                " \n4.Delete existing contact " +
                " \n5.Exit.");
                int Selectchoice = Convert.ToInt32(Console.ReadLine());
                switch (Selectchoice)
                {
                    case 1:
                        addressBook.InsertContactToTable();
                        break;
                    case 2:
                        addressBook.DisplayDetails();
                        break;
                    case 3:
                        addressBook.EditExistingContact();
                        break;
                    case 4:
                        addressBook.DeleteContact("Shreya");
                        break;
                    default:
                        Console.WriteLine("Please enter the valid number : ");
                        break;

                        Console.ReadLine();

                }
            }
        }
    }
}
