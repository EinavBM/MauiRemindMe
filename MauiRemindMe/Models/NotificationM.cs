using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiRemindMe.Models
{
    public class NotificationM
    {
        public string? Id { get; set; }
        public DateOnly? DateN { get; set; }
        public TimeSpan? TimeN { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
        public string? Info { get; set; }
    }
}
