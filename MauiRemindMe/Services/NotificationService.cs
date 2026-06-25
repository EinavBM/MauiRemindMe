using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiRemindMe.Services
{ // מכילה את כל הפעולות שנצטרך לנוטיפיקציה
    public class NotificationService// מחלקה לנוטיפיקציות
    {
        public async Task<bool> RequestPermissions()
        {
            if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            {
                await LocalNotificationCenter.Current.RequestNotificationPermission();
            }
            return await LocalNotificationCenter.Current.AreNotificationsEnabled();
        }

        public async Task ShowBasicNotification(string title, string message)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 1000,
                Title = title,
                Description = message,
                BadgeNumber = 1,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                  //   NotifyTime = DateTime.Now.AddDays(1)
                }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }

        public async Task ShowNotificationWithImage(string title, string message, string imageUrl)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 1001,
                Title = title,
                Description = message,
                Image = new NotificationImage
                {
                    FilePath = imageUrl
                },
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }

        public async Task ShowScheduledNotification(string title, string message, DateTime scheduleTime)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 1002,
                Title = title,
                Description = message,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = scheduleTime
                }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }

        public async Task ShowRepeatingNotification(string title, string message)
        {
            var notification = new NotificationRequest
            {
                NotificationId = 1003,
                Title = title,
                Description = message,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                    RepeatType = NotificationRepeat.Daily
                }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }

        public void CancelNotification(int notificationId)
        {
            LocalNotificationCenter.Current.Cancel(notificationId);
        }

        public void CancelAllNotifications()
        {
            LocalNotificationCenter.Current.CancelAll();
        }

    }
}
