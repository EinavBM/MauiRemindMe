using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiRemindMe.Models
{  // מגדיר את האובייקט שישמר במסד הנתונים כאובייקט שתמיד מוכן לשינויים
    internal class ThingsToSave:ObservableObject
    {
        private int _id;
        public int Id 
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value; OnPropertyChanged();
                }
            }
        }

        private DateTime _tdate;
        public DateTime Tdate
        {
            get => _tdate;
            set
            {
                if (_tdate != value)
                {
                    _tdate = value; OnPropertyChanged();
                }
            }
        }

        private int _thour;
        public int  Thour
        {
            get => _thour;
            set
            {
                if (_thour != value)
                {
                    _thour = value; OnPropertyChanged();
                }
            }
        }

        private bool _statusMs;
        public bool StatusMs
        {
            get => _statusMs;
            set
            {
                if (_statusMs != value)
                {
                    _statusMs = value; OnPropertyChanged();
                }
            }
        }

    }
}
