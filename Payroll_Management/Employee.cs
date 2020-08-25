using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Aman_A1
{
   class Employee
    {
        public int empID;
        public string empName;
        public string empAddress;
        public string empEmail;
        public string empPhone;
        public string empRole;


        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }

        public String Name 
        {
            get { return empName; }
            set { empName = value; }
        }

        public String Address
        {
            get { return empAddress; }
            set { empAddress = value; }
        }

        public String Email
        {
            get { return empEmail; }
            set { empEmail = value; }
        }
        public String Phone
        {
            get { return empPhone; }
            set { empPhone = value; }
        }
        public String Role
        {
            get { return empRole; }
            set { empRole = value; }
        }

        public Employee(int id, string n, string adrs, string mail, string phone, string role)
        {
            empID = id;
            empName = n;
            empAddress = adrs;
            empEmail = mail;
            empPhone = phone;
            empRole = role;

        }

        public Employee()
        {
        }

        // method to view all employees
        public void viewAllEmployee(List<Employee> emp)
        {

            var allemp = from objEmp in emp
                         select objEmp;
            Console.WriteLine("\n ---------------------- List of Employees ----------------------- \n");
            Console.WriteLine("Emp ID \t\t Name \t\t Address \t\t Email \t\t\t Phone \t\t\t Role");

            foreach (var i in allemp)
            {
                Console.WriteLine(i.empID + "\t\t" + i.empName + "\t\t" + i.empAddress + "\t\t" + i.empEmail + "\t\t" + i.empPhone + "\t\t" + i.empRole);
            }
        }

        // method to add employees employees
        public void addEmployee(List<Employee> emp, List<Vacation> vacation)
        {
            // sorting list
            Employee empAdd = new Employee();
            Vacation objVacation = new Vacation();
            var id = from objemp in emp 
                     orderby objemp.empID descending
                     select objemp;

            empAdd.empID = id.First().empID+1;
            try
            {

                Console.Write("Enter Employee Name:");
                empAdd.empName = Console.ReadLine();
                Console.Write("Enter Employee Address:");
                empAdd.empAddress = Console.ReadLine();
                Console.Write("Enter Employee Email:");
                empAdd.empEmail = Console.ReadLine();
                Console.Write("Enter Employee phone:");
                empAdd.empPhone = Console.ReadLine();
                Console.Write("Enter Employee role:");
                empAdd.empRole = Console.ReadLine();

                emp.Add(empAdd);
                objVacation.addVacation(vacation, empAdd.empID);

                Console.WriteLine("\n ########## Employee Deatil Added Successfull. ########## ");

            }
            catch(Exception)
            {
                Console.WriteLine("\n ########## Sorry! Something went wrong. Please try again.##########");
            }
        }

        // method to delete employees
        public void deleteEmployee(List<Employee> empList)
        {

            Console.Write("Enter Employee ID:");
            int removeID = int.Parse(Console.ReadLine());

            var idcheck = from obj in empList
                          where obj.empID == removeID
                          select obj;

            if (idcheck.Count() == 0)
            {
                Console.WriteLine("\n ########## Sorry! No record found. ##########  ");
            }
            else
            {
                empList.Remove(idcheck.First());
                Console.WriteLine("\n ########## Record Successfully removed. ##########  ");
            } 
        }

        // method to update employees employees
        public void updateEmployee(List<Employee> empList, Employee obj)
        {
            Console.Write("Enter employee ID : ");
            int removeID = int.Parse(Console.ReadLine());

            var idcheck = from objCheck in empList
                          where objCheck.empID == removeID
                          select objCheck;

            if (idcheck.Count() == 0)
            {
                Console.WriteLine("\n ########## Sorry! No record found. ##########  ");
            }
            else
            {
                try
                {
                    Console.Write("Enter Employee Name:");
                    obj.empName = Console.ReadLine();
                    Console.Write("Enter Employee Address:");
                    obj.empAddress = Console.ReadLine();
                    Console.Write("Enter Employee Email:");
                    obj.empEmail = Console.ReadLine();
                    Console.Write("Enter Employee phone:");
                    obj.empPhone = Console.ReadLine();
                    Console.Write("Enter Employee role:");
                    obj.empRole = Console.ReadLine();

                    foreach (var i in idcheck)
                    {
                        i.empID = removeID;
                        i.empName = obj.empName;
                        i.empAddress = obj.empAddress;
                        i.empEmail = obj.empEmail;
                        i.empPhone = obj.empPhone;
                        i.empRole = obj.empRole;
                    }

                    Console.WriteLine("\n ########## Record Updated Sucessfully! ########## ");

                }
                catch (Exception)
                {
                    Console.WriteLine("\n ########## Sorry! Something went wrong. Please try again.##########");
                }
            }
        }
    }
}
