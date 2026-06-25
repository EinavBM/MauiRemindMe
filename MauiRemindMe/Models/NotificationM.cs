namespace MauiRemindMe.Models
{
    public class NotificationM //פרטי תזכורת נשמרים
    {
        public string? Id { get; set; }// תז התזכורת בפיירביס
        public DateTime DateN { get; set; }// תאריך
        public string? TimeN { get; set; }// זמן
        public string? UserId { get; set; }// תז המשתמש של התזכורת
        public string? Status { get; set; }// מצב התזכורת
        public string? Info { get; set; }// שם
        public TimeSpan Time { get; set; } //לוקח זמן ומשנה אותו ממחרוזת לרכיב זמן


        //  public TimeSpan Time => TimeSpan.Parse(TimeN); //לוקח זמן ומשנה אותו מכתב לרכיב זמן

    }
}
