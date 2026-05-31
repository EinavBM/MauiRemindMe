namespace MauiRemindMe.Models
{
    public class NotificationM
    {
        public string? Id { get; set; }
        public string? DateN { get; set; }
        public string? TimeN { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
        public string? Info { get; set; }

        public DateOnly Date => DateOnly.Parse(DateN);
        public TimeSpan Time => TimeSpan.Parse(TimeN);
    }
}
