using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aman_A1
{
    class Payroll
    {
        public int payrollID;
        public int empID;
        public double hoursWorked;
        public double rate;
        public string date;

        public Payroll()
        {
        }

        public Payroll(int payrollID, int empID, double hoursWorked, double rate, string date)
        {
            this.payrollID = payrollID;
            this.empID = empID;
            this.hoursWorked = hoursWorked;
            this.rate = rate;
            this.date = date;
        }

        public int PayrollID
        {
            get { return payrollID; }
            set { payrollID = value; }
        }
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
        public double HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; }
        }
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }


        // method to view all employees
        public void viewAllPayroll(List<Payroll> payroll)
        {

            var allPay = from objPay in payroll
                         select objPay;
            Console.WriteLine("\n ---------------------- List of Payroll ----------------------- \n");
            Console.WriteLine("ID \t Emp ID \t Hours Worked \t\t Rate \t\t Date");

            foreach (var i in allPay)
            {
                Console.WriteLine(i.payrollID + "\t" + i.empID + "\t\t" + i.hoursWorked + "\t\t\t" + i.rate + "\t\t" + i.date);
            }
        }

        // method to add payroll employees employees
        public void addPayroll(List<Payroll> payroll, List<Vacation> vacation)
        {
            // sorting list
            Payroll payAdd = new Payroll();
            Vacation objVacation = new Vacation();
            var payid = from objemp in payroll
                        orderby objemp.PayrollID descending
                        select objemp;
            try
            {

                payAdd.PayrollID = payid.First().payrollID + 1;
                Console.Write("Enter Employee ID:");
                payAdd.empID = int.Parse(Console.ReadLine());
                Console.Write("Enter hours employee worked:");
                payAdd.hoursWorked = double.Parse(Console.ReadLine());
                Console.Write("Enter hourly rate:");
                payAdd.rate = double.Parse(Console.ReadLine());
                Console.Write("Enter date(MM-DD-YYYY):");
                payAdd.date = Console.ReadLine();


                payroll.Add(payAdd);
                objVacation.addVacation(vacation, payAdd.empID);
                Console.WriteLine("\n ########## Employee Payroll Deatil Added Successfull. ########## ");
            }
            catch (Exception)
            {
                Console.WriteLine("\n ########## Sorry! Something went wrong. Please try again.##########");
            }

        }

        // method to delete payroll for employees
        public void deletePayroll(List<Payroll> payroll)
        {

            try
            {
                Console.Write("Enter Payroll ID:");
                int removeID = int.Parse(Console.ReadLine());

                var idcheck = from obj in payroll
                              where obj.payrollID == removeID
                              select obj;

                if (idcheck.Count() == 0)
                {
                    Console.Write("\n ########## Sorry! No Record for this ID found. ##########");
                }
                else
                {
                    payroll.Remove(idcheck.First());
                    Console.WriteLine("\n ########## Record Successfully removed. ##########  ");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n ########## Sorry! Something went wrong. Please try again.##########");
            }
        }
        // method to update payroll for employees 
        public void updatePayroll(List<Payroll> payroll, Payroll objPayroll)
        {
            Console.Write("Enter Payroll ID : ");
            int removeID = int.Parse(Console.ReadLine());

            var idcheck = from objCheck in payroll
                          where objCheck.payrollID == removeID
                          select objCheck;

            if (idcheck.Count() == 0)
            {
                Console.Write("\n ########## Sorry! No Record for this ID found. ##########");
            }
            else
            {
                try
                {
                    Console.Write("Enter Employee ID:");
                    objPayroll.empID = int.Parse(Console.ReadLine());
                    Console.Write("Enter hours worked:");
                    objPayroll.hoursWorked = double.Parse(Console.ReadLine());
                    Console.Write("Enter hourly rate:");
                    objPayroll.rate = double.Parse(Console.ReadLine());
                    Console.Write("Enter date (MM-DD-YYYY):");
                    objPayroll.date = Console.ReadLine();

                    foreach (var i in idcheck)
                    {
                        i.payrollID = removeID;
                        i.empID = objPayroll.empID;
                        i.hoursWorked = objPayroll.hoursWorked;
                        i.rate = objPayroll.rate;
                        i.date = objPayroll.date;
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

