using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Camphor.Model;

namespace Camphor.Controller {
    public class DateTimeManager {
        DateTime todayDate;
        DateTime firstDayOfSem;
        DateTime lastDayOfSem;
        
        DateTime[] importantSemDates = new DateTime[4];
        
        public DateTimeManager() {
            todayDate = DateTime.Today;
            firstDayOfSem = new DateTime(2012, 01, 09);
            lastDayOfSem = new DateTime(2012, 05, 05);
            importantSemDates[0] = new DateTime(2011, 08, 08);
            importantSemDates[1] = new DateTime(2011, 12, 03);
            importantSemDates[2] = new DateTime(2012, 01, 09);
            importantSemDates[3] = new DateTime(2012, 05, 05);
        }
        
        public DateTimeManager(string academicYear, 
                               DateTime firstDayOfSem1,
                               DateTime lastDayOfSem1,
                               DateTime firstDayOfSem2,
                               DateTime lastDayOfSem2) {
            todayDate = DateTime.Today;
            importantSemDates = new DateTime[4];
            importantSemDates[0] = firstDayOfSem1;
            importantSemDates[1] = lastDayOfSem1;
            importantSemDates[2] = firstDayOfSem2;
            importantSemDates[3] = lastDayOfSem2;
        }
        
        public int NumberOfDaysTillEvent(Event theEvent) {
            
            DateTime startDate = theEvent.startDate;
            return (startDate.Subtract(todayDate)).Days;
        }
        
        public int NumberOfDaysTillTask(Task theTask) {
            
            DateTime startDate = theTask.deadline;
            return (startDate.Subtract(todayDate)).Days;
        }

        public string CurrentAcademicYear() {
            int index = 0;
            
            while (DateTime.Compare(todayDate, importantSemDates[index]) > 0) {
                // To determine which time range the date falls under
                // -ve if test is earlier
                // +ve is test is later
                index++;
            }
                   
            index--;

            switch (index) {
                case 0:
                    return "AY2011/12 SEMESTER 1";
                case 1:
                    return "SPECIAL SEMESTER";
                case 2:
                    return "AY2011/12 SEMESTER 2";
                default:
                    return "SPECIAL SEMESTER";
            } 
        }
        
     //   DateTime test = new DateTime(2011, 09, 27);

        public string CurrentAcademicWeek() {
            int index = 0;
            
            while (DateTime.Compare(todayDate, importantSemDates[index]) > 0) {
                // To determine which time range the date falls under
                // -ve if test is earlier
                // +ve is test is later
                index++;
            }
                   
            index--;

           // Console.WriteLine(index);
            
            if (index == 0 || index == 2) {
                return CurrentAcademicWeek(importantSemDates[index]);
            } else {
                return "Vacation Week";
            }            
        }
        
        private string CurrentAcademicWeek(DateTime firstDayOfCurrSem) {
            int numberOfDays = this.todayDate.Subtract(firstDayOfCurrSem).Days + 1;
            //this.todayDate.Subtract(firstDayOfSem).Days;
            int numberOfWeeks;
            if (numberOfDays % 7 == 0) {
                numberOfWeeks = numberOfDays / 7;
            } else {
                numberOfWeeks = (numberOfDays / 7) + 1;
            }
            
         //   Console.WriteLine("test date is " + test.Date);
         //   Console.WriteLine("first day of sem is " + firstDayOfCurrSem.Date);
         //   Console.WriteLine("number of days is: " + numberOfDays);
         //   Console.WriteLine("number of weeks is: " + numberOfWeeks);
            StringBuilder sb = new StringBuilder();
                        
            switch (numberOfWeeks) {
                case 7:
                    sb.Append("Recess Week");
                    break;
                case 15:
                    sb.Append("Reading Week");
                    break;
                case 16:
                    sb.Append("Examination Week 1");
                    break;
                case 17:
                    sb.Append("Examination Week 2");
                    break;
                default:
                    int weekNumber = numberOfWeeks;
                    if (numberOfWeeks > 7) {
                        weekNumber--;
                        Console.WriteLine("entered");
                    } 
                    sb.Append("WEEK ");
                    sb.Append(Convert.ToString(weekNumber));
                    break;
            }
            return sb.ToString();
            
        }
    }
}
