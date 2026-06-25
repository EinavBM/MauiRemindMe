using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Database;
using Firebase.Database.Query;
using MauiRemindMe.Models;


namespace MauiRemindMe.Services
{
    public class FirebaseService// מחלקה שמבצעת פעולות מול הפיירביס
    {

        private readonly FirebaseClient _firebaseClient;// משתנה שמעביר נתונים מהפיירבייס

        private const string FireBaseApiKey = "AIzaSyDDcMQoNMeZUGC3KTmaIbAJfG0sLqyzFlc";
        private readonly FirebaseAuthProvider authProvider;
        public FirebaseService() //מחלקה בונה
        {
            string firebaseDatabaseUrl = "https://remindme-c2389-default-rtdb.europe-west1.firebasedatabase.app/";// כתובת הפיירביס שאליה כל הנתונים נשלחים

            _firebaseClient = new FirebaseClient(firebaseDatabaseUrl);// מאתחלת את המשתנה
           // authProvider= new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));
        }
       
        public async Task<List<NotificationM>> GetNotificationAsync(string userId)//הגדרת פונ המקבלת משתמש ומחזירה את על התזכורות שלו
        {
		    List < NotificationM > notlist = new();// יוצר רשימה לתזכורות
			try// מגן במקרה של שגיאה או חוסר אינטרנט
            {
                var notifications = await _firebaseClient.Child("Notification").OnceAsync<NotificationM>();// בעזרת המשתנה שהגדרנו אנחנו פונים לעמוד של התזכורות ולקח משם את כולם

                foreach (var notification in notifications) //עובר על כל אחת מהתזכורות
                {
                    NotificationM not = notification.Object;// לקיחת כל תזכורת באובייקט NOT

                    if (notification!= null && not.UserId== userId)// אם התזכורת לא ריקה וגם מזהה את תז המשתמש של התזכורת
						notlist.Add(not);// מוסיף רשימה לרשימה מקורית
				}
                return notlist;//מחזיר רשימה
            }
            catch (Exception ex)// במקרה של שגיאה
            {
                System.Diagnostics.Debug.WriteLine($"Error retrieving data: {ex.Message}");// התראה
                return null; //מחזיר כלום
            }
        }

        public async Task<List<NotificationM>> GetNotificationAsync()//הגדרת פונ המקבלת משתמש ומחזירה את על התזכורות שלו
        {
            List<NotificationM> notlist = new();// יוצר רשימה לתזכורות
            try// מגן במקרה של שגיאה או חוסר אינטרנט
            {
                var notifications = await _firebaseClient.Child("Notification").OnceAsync<NotificationM>();// בעזרת המשתנה שהגדרנו אנחנו פונים לעמוד של התזכורות ולקח משם את כולם

                foreach (var notification in notifications) //עובר על כל אחת מהתזכורות
                {
                    NotificationM not = notification.Object;// לקיחת כל תזכורת באובייקט NOT

                        notlist.Add(not);// מוסיף רשימה לרשימה מקורית
                }
                return notlist;//מחזיר רשימה
            }
            catch (Exception ex)// במקרה של שגיאה
            {
                System.Diagnostics.Debug.WriteLine($"Error retrieving data: {ex.Message}");// התראה
                return null; //מחזיר כלום
            }
        }


        public async Task<bool> DeleteNotification(string Id)//מוחק התרעה
        {

            try
            {
                // 1. שליפת כל ההראות מהשרת
                var list = await _firebaseClient
                    .Child("Notification")
                    .OnceAsync<NotificationM>();

                // 2. לולאה למציאת ההתראה המתאים
                foreach (var item in list)

                {
                    if (item.Object.Id == Id)
                    {
                        // 3. מחיקת הרשומה הספציפית מהשרת באמצעות הפקודה DeleteAsync
                        await _firebaseClient
                            .Child("Notification")
                            .Child(item.Key) // המפתח הייחודי ב-Firebase
                            .DeleteAsync();

                        return true; // המחיקה הצליחה
                    }
                }

                return false; // לא נמצא התזכורת
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting: {ex.Message}");
                return false;
            }








            //try
            //{
            //    var notifications = await _firebaseClient.Child("Notification").OnceAsync<NotificationM>();// מביא את הרשימה של התראות
            //    var target = notifications.FirstOrDefault(e => e.Object.Id == Id);//מביא מהרשימה שקיבלנו את אותו ה ID שקיבלנו מהקלט
            //    if (target == null)//אם לא מצא את הID
            //    {
            //        string id= target.Object.Id;
            //        await _firebaseClient.Child("Notification").Child(id).DeleteAsync();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return;
            //}




            //await _firebaseClient.Child("Notification").Child(Id).DeleteAsync();
        }

        public async Task <NotificationM> ShowNotification(string Id)
        {


            try
            {
                var list = await _firebaseClient
                        .Child("Notification")
                        .OnceAsync<NotificationM>();

                // 2. לולאה למציאת ההתראה המתאים
                foreach (var item in list)
                {
                    if (item.Object.Id == Id)
                    {
                        var target = item.Object;

                        return target; // המחיקה הצליחה
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting: {ex.Message}");
                return null;
            }



    //try
    //{
    //    var notifications = await _firebaseClient.Child("Notification").OnceAsync<NotificationM>();// מביא את הרשימה של התראות
    //    var target = notifications.FirstOrDefault(e => e.Object.Id == Id);//מביא מהרשימה שקיבלנו את אותו ה ID שקיבלנו מהקלט

    //    if (target== null)//אם לא מצא את הID
    //    {
    //        return null;//מחזיר ריק
    //    }
    //    target.Object.Id = target.Key;//שומר את הID בשדה מפתח שלפיו  נוכל לעשות זיהוי חד חד ערכי
    //    return target.Object;// מחזיר התראה
    //}
    //catch (Exception ex)
    //{
    //    return null;
    //}





    //_editVM.Notification = notification;
    //_editVM.IsEdit = true;
    //Dictionary<string, object> data = new Dictionary<string, object>();
    //data.Add("Notification", notification);
    ////נשלח את המידע עם הפניה למסך
    //await Shell.Current.GoToAsync("/update", data);
}
    }
}

  







