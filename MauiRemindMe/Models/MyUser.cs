namespace MauiRemindMe.Models
{
    public class MyUser// פרטי משתמש נשמרים
    {
        public string? Id { get; set; } //תז המשתמש בפיירביס
        public string? Name { get; set; } //שם
        public string? Email { get; set; }// מייל
        public string? Password { get; set; }//סיסמה
        public bool? Admin { get; set; }// אם מנהל
    }
}
