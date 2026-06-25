using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiRemindMe.Models
{
    public class ControlM
    {
        public DateTime EventStart { get; set; } //יצירת זמן
        public DateTime EventEnd { get; set; } //סיום
        public string ?Name { get; set; } //שם התזכורת
        public Brush ?Color { get; set; }// צבע התזכורת בלוח


    }
}
