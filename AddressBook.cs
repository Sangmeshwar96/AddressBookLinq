using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookLINQ
{
    public class AddressBookDataTable
    {

        DataTable table = new DataTable("AddressBook");


        public AddressBookDataTable()
        {
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));

            table.Rows.Add("Mukhesh", "Attuluri", "8-47", "Ppm", "Ap", "535501", "8978496720", "mkh.com");
            table.Rows.Add("Ram", "Bantu", "Sun nagar", "Vizag", "Ap", "546489", "8570456737", "ram.com");
            table.Rows.Add("Ravi", "Kumar", "Rain colony", "Hyd", "Telangana", "546362", "9878678593", "ravi.com");
            table.Rows.Add("Srinu", "Rao", "WhiteField", "Banglore", "Karnataka", "125445", "7206326427", "srinu.com");
        }
        public void GetAllContacts()
        {
            foreach (DataRow dr in table.AsEnumerable())
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("lastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
            }

        }


        public void UpdateContact(string firstName, string lastName, string columnName, string newValue)
        {
            DataRow updateContact = table.Select("FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
            updateContact[columnName] = newValue;
            Console.WriteLine("Updated Contact");
        }
        public void DeleteContact(string firstName, string lastName)
        {
            DataRow deleteContact = table.Select("FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
            table.Rows.Remove(deleteContact);
        }
        public void RetrieveByCityOrState(string city, string state)
        {
            ArrayList list = new ArrayList();
            var contact = from c in table.AsEnumerable()
                          where c.Field<string>("City") == city || c.Field<string>("State") == state
                          select c;
            foreach (DataRow dr in contact)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("lastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
            }

        }
        public void CountByCityOrState(string city, string state)
        {
            var contact = from c in table.AsEnumerable()
                          where c.Field<string>("City") == city && c.Field<string>("State") == state
                          select c;

            Console.WriteLine("Count of contacts in City:{0} and  State:{1} is {2}", city, state, contact.Count());
        }
        public void GetAllByCityOrderByName(string city)
        {
            var contact = from c in table.AsEnumerable()
                          where c.Field<string>("City") == city
                          orderby c.Field<string>("FirstName"), c.Field<string>("LastName")
                          select c;
            foreach (DataRow dr in contact)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("lastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
            }


        }
        public void AddAddressBookNameType()
        {
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "AddressBookName";
            column.AllowDBNull = false;
            column.DefaultValue = "Mkh";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ContactType";
            column.AllowDBNull = false;
            column.DefaultValue = "Friends";
            table.Columns.Add(column);
        }
        public void GetCountByType()
        {
            var element = from contact in table.AsEnumerable()
                          group contact by contact.Field<string>("ContactType") into g
                          select new { typename = g.Key, Count = g.Count() };

            element.ToList().ForEach(ele => Console.WriteLine($"ContactType : {ele.typename} \t Count = {ele.Count}"));
        }
    }
}