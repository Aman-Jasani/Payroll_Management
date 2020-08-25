using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aman_A1
{
    class Vacation
    {
        public int vacationID;
        public int empID;
        public int days;

        public Vacation(int vacationID, int empID, int days)
        {
            this.vacationID = vacationID;
            this.empID = empID;
            this.days = days;
        }

        public Vacation()
        {
        }

        public int VacationID
        {
            get { return vacationID; }
            set { vacationID = value; }
        }

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        public int Days
        {
            get { return days; }
            set { days = value; }
        }


        // method to view all records for employees vacation days
        public void viewAllVacation(List<Vacation> vacation)
        {

            var allVac = from objPay in vacation
                         select objPay;
            Console.WriteLine("\n ---------------------- List of Vacation days ----------------------- \n");
            Console.WriteLine("ID \t Emp ID \t Days");

            foreach (var i in allVac)
            {
                Console.WriteLine(i.vacationID + "\t" + i.empID + "\t\t" + i.days);
            }
        }

        // method to add vacation days fore employees
        public void addVacation(List<Vacation> vacation, int id)
        {
            // sorting list
           
            var vacid = from objvac in vacation
                        orderby objvac.vacationID descending
                        select objvac.vacationID;

            var objVac = from objvac in vacation
                         where objvac.empID == id
                         select objvac;

            if (objVac.Count() == 0)
            {
                //addd in vacation 
                vacation.Add(new Vacation(vacid.First() + 1, id, 14));
            }
            else
            {
                for (int i = 0; i < vacation.Count; i++)
                {
                    if (vacation[i].empID == id)
                        vacation[i].days += 1;
                }
            }


        }

        // method to delete vacation for employees
        public void deleteVacation(List<Vacation> vacation)
        {
            try
            {
                Console.Write("Enter Payroll ID:");
                int removeID = int.Parse(Console.ReadLine());

                var idcheck = from obj in vacation
                              where obj.vacationID == removeID
                              select obj;

                if (idcheck.Count() == 0)
                {
                    Console.Write("\n ########## Sorry! No Record for this ID found. ##########");
                }
                else
                {
                    vacation.Remove(idcheck.First());
                    Console.WriteLine("\n ########## Record Successfully removed. ##########  ");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n ########## Sorry! Something went wrong. Please try again.##########");
            }
        }
        // method to update vacation days for employees 
        public void updateVacation(List<Vacation> vacation, Vacation objVacation)
        {
            Console.Write("Enter vacation ID : ");
            int removeID = int.Parse(Console.ReadLine());

            var idcheck = from objCheck in vacation
                          where objCheck.vacationID == removeID
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
                    objVacation.empID = int.Parse(Console.ReadLine());
                    Console.Write("Enter days:");
                    objVacation.days = int.Parse(Console.ReadLine());

                    foreach (var i in idcheck)
                    {
                        i.vacationID = removeID;
                        i.empID = objVacation.empID;
                        i.days = objVacation.days;
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