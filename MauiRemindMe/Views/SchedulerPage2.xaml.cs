using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiRemindMe.ViewsModels;


namespace MauiRemindMe.Views
{
  
    public partial class SchedulerPage2 : ContentPage
    {
        public SchedulerPage2(SchedulerVM vm)
        {
            InitializeComponent();
            BindingContext=vm;
        }
    }
}