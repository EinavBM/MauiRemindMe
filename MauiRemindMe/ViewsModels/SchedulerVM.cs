using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MauiRemindMe.Models;
using MauiRemindMe.Services;
using Plugin.LocalNotification;
using Syncfusion.Maui.Scheduler;

namespace MauiRemindMe.ViewsModels
{
    public partial class SchedulerVM: ContentPage
    {
        private readonly FirebaseService _firebaseService;
        int countNoti= 0;
        public ObservableCollection<SchedulerAppointment> SchedulerEvent { get; set; }
        public ObservableCollection<ControlM> CustomEvent { get; set; }
        public List<NotificationM> notifications { get; set; }

        private readonly NotificationService _notificationService;
        public SchedulerVM()
        {
            _firebaseService = new FirebaseService();
            _notificationService = new NotificationService();
            LoadData();
            
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _notificationService.RequestPermissions();
        }


        private async Task StartNotificationAsync()
        {
            var service = new NotificationService();

            await service.ShowBasicNotification("The notifications for today", "You have " +countNoti+" notification(s) "+DateTime.Now.Date.ToString());
        }



        private async void LoadData()
        {
            //countNoti = 0;
            string id = Preferences.Default.Get("UserId", "");
            SchedulerEvent = new ObservableCollection<SchedulerAppointment>();
            List<NotificationM> notifications = await _firebaseService.GetNotificationAsync(id);

            if (notifications != null)
            {
                foreach (NotificationM notification in notifications)
                {
                    DateTime t = notification.DateN;
                    TimeSpan ts = notification.Time;
                    string info = notification.Info.ToString();
                    DateTime today= DateTime.Now.Date;
                    DateTime fb = t.Date;
                    if (today== fb)
                    {
                        countNoti++;
                    }

                    SchedulerAppointment sa = new SchedulerAppointment
                    {

                        StartTime = new DateTime(t.Year, t.Month, t.Day, ts.Hours, ts.Minutes, ts.Seconds),
                        EndTime = new DateTime(t.Year, t.Month, t.Day, ts.Hours + 1, ts.Minutes, ts.Seconds),
                        Subject = info,
                        Background = Colors.Green
                    };
                    SchedulerEvent.Add(sa);


                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", $"No data found", "ok");
            }
            StartNotificationAsync();


        }



        [RelayCommand]
        private async Task Search()
        {
            await Shell.Current.GoToAsync("/searchDate");

        }

        [RelayCommand]
        private async Task AddNotificationBn()
        {
            await Shell.Current.GoToAsync("/add");

        }

        [RelayCommand]
        private async Task NotificationListBn()
        {
            await Shell.Current.GoToAsync("/notiList");

        }

    }
}
