using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiRemindMe.Models;
using MauiRemindMe.Services;

namespace MauiRemindMe.ViewsModels
{
    public class SearchDate2: ObservableObject
    {
        private readonly FirebaseService _firebaseService;//יוצר משתנה מקשר פיירביס
        // הרשימה המקורית של כל ההתראות שקיימות באפליקציה (מה-DB שלך)
        public ObservableCollection<NotificationM> AllNotifications { get; set; } = new();// משיג רשימה של כל ההתראות

        // הרשימה המסוננת שמוצגת ב-XAML בזמן אמת
        private ObservableCollection<NotificationM> _filteredNotifications = new();// מציג רשימה של התראות ממוינות לפי תנאי
        public ObservableCollection<NotificationM> FilteredNotifications
        {
            get => _filteredNotifications;
            set { _filteredNotifications = value; OnPropertyChanged(); }
        }

        // התאריך שהמשתמש בחר ב-DatePicker (מתחיל מהתאריך של היום)
        private DateTime _selectedSearchDate = DateTime.Today;
        public DateTime SelectedSearchDate
        {
            get => _selectedSearchDate;
            set
            {
                _selectedSearchDate = value;
                OnPropertyChanged();
                FilterNotificationsByDate(); // בכל פעם שהתאריך משתנה, מפעילים אוטומטית את הסינון
            }
        }

        // טקסט דינמי שמציג את כמות התוצאות
        private string _resultsCountText;
        public string ResultsCountText
        {
            get => _resultsCountText;
            set { _resultsCountText = value; OnPropertyChanged(); }
        }

        public ICommand GoToAddNotificationCommand { get; private set; }// מגדיר את הפעולה שהכפתור של הוספת תזכורת

        public SearchDate2()
        {
            _firebaseService = new FirebaseService();// יוצר משתנה חדש

            // אתחול כפתור הניווט
            GoToAddNotificationCommand = new Command(async () => await GoToAddNotification());

            // 1. טעינת נתונים (כאן תביאי את הרשימה מה-Firebase/Database שלך)
            LoadSampleData();

            // 2. הפעלת סינון ראשוני עבור היום הנוכחי
            FilterNotificationsByDate();
            
        }

        // פונקציית הלוגיקה שמסננת את המשימות לפי התאריך הנבחר
        private void FilterNotificationsByDate()
        {
            var matchedItems = AllNotifications
                .Where(n => n.DateN.Date == SelectedSearchDate.Date)
                .OrderBy(n => n.TimeN)
                .ToList();

            FilteredNotifications = new ObservableCollection<NotificationM>(matchedItems);

            // עדכון הטקסט של כמות התוצאות
            if (FilteredNotifications.Count == 0)
                ResultsCountText = "No reminders for this day";
            else
                ResultsCountText = $"Found {FilteredNotifications.Count} reminder(s):";
        }

        
        private async Task GoToAddNotification()
        {
            // ניווט לעמוד הוספת תזכורת (ודאי שה-Route רשום ב-AppShell שלך)
            await Shell.Current.GoToAsync("/add");
        }

        private async void LoadSampleData()// מביא את כל הנתונים של כל ההתראות
        {
            List<NotificationM> list = await _firebaseService.GetNotificationAsync();//מביא נוטיפיקציות של משתמש
            foreach (NotificationM item in list)
            {
                AllNotifications.Add(item);
            }
        }
    }
}
