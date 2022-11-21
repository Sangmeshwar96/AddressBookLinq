using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBook_Linq
{
    class AddressBook
    {
        DataTable table = new DataTable("AddressBook");
        public AddressBook()
        {
    
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));
        }
     
        public void InsertContactToTable()
        {
           
            table.Rows.Add("Shreya", "Malviya", "Howrah", "Nagpur", "MH", 75866, "8596748585", "shreya@gmail.com");
            table.Rows.Add("prajakta", "Nayak", "Durgapur", "A zone", "West Bengal", 14526, "8596748585", "prajakta@gmail.com");
            table.Rows.Add("Tanmay", "Agarwal", "Kolkata", "NewTown", "West Bengal", 78596, "8596748585", "tanmay@gmail.com");
            table.Rows.Add("ekta", "Nath", "Patna", "Patna City", "Bihar", 125896, "8596748585", "ekta@gmail.com");
            Console.WriteLine("Contact details added successfully!\n Select 2 for view contact\n");



        }

        public void DisplayDetails()
        {

            foreach (var table in table.AsEnumerable())
            {
                
                Console.WriteLine("\nFirstName:-" + table.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + table.Field<string>("LastName"));
                Console.WriteLine("Address:-" + table.Field<string>("Address"));
                Console.WriteLine("City:-" + table.Field<string>("City"));
                Console.WriteLine("State:-" + table.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + table.Field<string>("Zip"));
                Console.WriteLine("PhoneNumber:-" + table.Field<string>("PhoneNumber"));
                Console.WriteLine("Email:-" + table.Field<string>("Email"));
            }
        }

        public void EditExistingContact()
        {
            try
            {
                
                string editName = "prajakta";

                var updateData = table.AsEnumerable().Where(x => x.Field<string>("FirstName").Equals(editName)).FirstOrDefault();
                if (updateData != null)
                {
                    
                    updateData.SetField("PhoneNumber", "895478520");
                    updateData.SetField("City", "Pune");
                    Console.WriteLine("\n PhoneNumber and ity of {0} updated successfully!", editName);
                    DisplayDetails();
                }
                else
                {
                    Console.WriteLine("There is no such record in the Address Book!");
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}