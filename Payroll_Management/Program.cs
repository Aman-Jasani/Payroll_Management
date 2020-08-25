using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Aman_A1
{
    class Program
    {
        static void Main(string[] args)
        {
            // object for employee class
            Employee obj = new Employee();
            List<Employee> emp = new List<Employee>();

            // object for payroll
            Payroll objPayroll = new Payroll();
            List<Payroll> payroll = new List<Payroll>();

            // object for vacation
            Vacation objVacation = new Vacation();
            List<Vacation> vacation = new List<Vacation>();

            // hardcode values for emploees data
            emp.Add(new Employee(1, "Aman", "Brickyardway", "aman@gmail.com", "7848792849", "Manager"));
            emp.Add(new Employee(2, "Jack", "USA Drive", "j2@gmail.com", "97848792129", "Staff"));
            emp.Add(new Employee(3, "Lee", "Timberlan", "lee@gmail.com", "7848284911", "Staff"));
            emp.Add(new Employee(4, "Donald", "driveway", "doanl@gmail.com", "9284922342", "sales member"));
            emp.Add(new Employee(5, "Tim", "Main Street", "timn@gmail.com", "9700000009", "President"));

            // hardcode values for Payroll data
            payroll.Add(new Payroll(1, 1, 9, 32, "02-29-2019"));
            payroll.Add(new Payroll(2, 2, 4, 100, "03-29-2020"));
            payroll.Add(new Payroll(3, 3, 0, 14, "03-29-2020"));
            payroll.Add(new Payroll(4, 4, 10, 52, "02-29-2021"));
            payroll.Add(new Payroll(5, 5, 15, 902, "02-29-2023"));

            // hardcode values for Vacation data
            vacation.Add(new Vacation(1, 1, 14));
            vacation.Add(new Vacation(2, 2, 14));
            vacation.Add(new Vacation(3, 3, 14));
            vacation.Add(new Vacation(4, 4, 14));
            vacation.Add(new Vacation(5, 5, 14));

            int choiceEmp;
            int choicePayroll;
            int choiceVacation;
            int choiceMain;

            Console.WriteLine(" \t\t\t\t ----------------------------------------------");
            Console.WriteLine("\t\t\t\t\t  Employee Management System  ");
            Console.WriteLine(" \t\t\t\t ----------------------------------------------");

            try {
                do
                {
                    // Main menu
                    Console.WriteLine("\n\n -------------------------- Main Menu --------------------------");
                    Console.WriteLine("\n\t Press 1 to modify employees");
                    Console.WriteLine("\t Press 2 to add payroll");
                    Console.WriteLine("\t Press 3 to view vacation days ");
                    Console.WriteLine("\t Press 4 to end ");
                    Console.Write(" \n\t Enter number :  ");
                    choiceMain = int.Parse(Console.ReadLine());

                    // Employee Menu
                    while (choiceMain == 1)
                    {
                        Console.WriteLine("\n ------------------------ Employees Data ------------------------");
                        Console.WriteLine("\n\t Press 1 to list all employees");
                        Console.WriteLine("\t Press 2 to add new employees");
                        Console.WriteLine("\t Press 3 to update employees ");
                        Console.WriteLine("\t Press 4 to delete employees ");
                        Console.WriteLine("\t Press 5 to return to main menu ");
                        Console.Write("\n\t Enter number :  ");
                        choiceEmp = int.Parse(Console.ReadLine());
                        if (choiceEmp == 5) break;

                        if (choiceEmp == 1)
                            obj.viewAllEmployee(emp);
                        else if (choiceEmp == 2)
                            obj.addEmployee(emp, vacation);
                        else if (choiceEmp == 3)
                            obj.updateEmployee(emp, obj);
                        else if (choiceEmp == 4)
                            obj.deleteEmployee(emp);
                    }

                    // payroll Menu
                    while (choiceMain == 2)
                    {
                        Console.WriteLine("\n ------------------------- Payroll Data -------------------------");
                        Console.WriteLine("\n\t Press 1 to insert new payroll entry");
                        Console.WriteLine("\t Press 2 to view payroll histroy");
                        Console.WriteLine("\t Press 3 to Update payroll");
                        Console.WriteLine("\t Press 4 to delete payroll");
                        Console.WriteLine("\t Press 5 to return to main menu ");
                        Console.Write("\n\t Enter number :  ");
                        choicePayroll = int.Parse(Console.ReadLine());
                        if (choicePayroll == 5) break;

                        if (choicePayroll == 1)
                        {
                            objPayroll.addPayroll(payroll, vacation);
                           
                        }
                        else if (choicePayroll == 2)
                            objPayroll.viewAllPayroll(payroll);
                        else if (choicePayroll == 3)
                            objPayroll.updatePayroll(payroll, objPayroll);
                        else if (choicePayroll == 4)
                            objPayroll.deletePayroll(payroll);
                    }

                    // Vacation Menu
                    while (choiceMain == 3)
                    {
                        Console.WriteLine("\n ------------------------ Vacation Data ------------------------ ");
                        Console.WriteLine("\t Press 1 to view vacation days");
                        Console.WriteLine("\t Press 2 to update the vacation days ");
                        Console.WriteLine("\t Press 3 to delete the record of vacation days ");
                        Console.WriteLine("\t Press 4 to return to main menu ");
                        Console.Write("\n\t Enter number :  ");
                        choiceVacation = int.Parse(Console.ReadLine());
                        if (choiceVacation == 4) break;

                        if (choiceVacation == 1)
                            objVacation.viewAllVacation(vacation);
                        else if (choiceVacation == 2)
                            objVacation.updateVacation(vacation, objVacation);
                        else if (choiceVacation == 3)
                            objVacation.deleteVacation(vacation);
                    }

        } while (choiceMain != 4);
            Console.WriteLine("\n You chose to exit. Thank you!");
            }
            catch
            {
                Console.WriteLine("\n ########## Sorry! you eneterd wrong input. Please try again.");
            }
        }
    }
}

