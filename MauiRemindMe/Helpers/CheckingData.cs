using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiRemindMe.Helpers
{
    public class CheckingData
    {
        public static bool CheckingInput(string data, int min= 2, int max= 30)
        {
            if (string.IsNullOrEmpty(data))
                return false;
            if (data.Length < min || data.Length > max)
            {
                return false;
            }
            return true;
        }

        public static bool CheckingDate(DateTime dt)
        {
            if (dt.ToString() == null)
                return false;
            if(dt.Date.Year < DateTime.Now.Year-100)
                return false;
            return true;
        }
    }
}
