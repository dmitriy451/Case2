using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolPortalAPI.Models
{
    public class ResponseTimeTable
    {
        public ResponseTimeTable(List<DataBase.TimeTable> timeTable)
        {
            Monday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "monday").ToList().ConvertAll(p => new ResponseTimeTableDay(p));
            Tuesday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "tuesday").ToList().ConvertAll(p => new ResponseTimeTableDay(p));
            Wednesday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "wednesday").ToList().ConvertAll(p => new ResponseTimeTableDay(p));
            Thursday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "thursday").ToList().ConvertAll(p => new ResponseTimeTableDay(p));
            Friday = timeTable.Where(p => p.DayOfTheWeek.ToLower() == "friday").ToList().ConvertAll(p => new ResponseTimeTableDay(p));
            while (Monday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Monday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Monday.Add(new ResponseTimeTableDay(i));
                    }
                }
            }
            while (Tuesday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Tuesday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Tuesday.Add(new ResponseTimeTableDay(i));
                    }
                }
            }
            while (Wednesday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Wednesday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Wednesday.Add(new ResponseTimeTableDay(i));
                    }
                }
            }
            while (Thursday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Thursday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Thursday.Add(new ResponseTimeTableDay(i));
                    }
                }
            }
            while (Friday.Count < 8)
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (Friday.FirstOrDefault(p => p.Сount == i) == null)
                    {
                        Friday.Add(new ResponseTimeTableDay(i));
                    }
                }
            }
            Monday = Monday.OrderBy(p => p.Сount).ToList();
            Tuesday = Tuesday.OrderBy(p => p.Сount).ToList();
            Wednesday = Wednesday.OrderBy(p => p.Сount).ToList();
            Thursday = Thursday.OrderBy(p => p.Сount).ToList();
            Friday = Friday.OrderBy(p => p.Сount).ToList();

        }
        public List<ResponseTimeTableDay> Monday { get; set; }
        public List<ResponseTimeTableDay> Tuesday { get; set; }
        public List<ResponseTimeTableDay> Wednesday { get; set; }
        public List<ResponseTimeTableDay> Thursday { get; set; }
        public List<ResponseTimeTableDay> Friday { get; set; }
    }
}