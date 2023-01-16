
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mobile1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile1.ViewModels
{
    public partial class ScheduleListViewModel:ObservableObject
    {
        public ObservableCollection<DaysModel> WeekDays { get; set; } = new ObservableCollection<DaysModel>();
        public ObservableCollection<ScheduleModel> ScheduleList { get; set; } = new ObservableCollection<ScheduleModel>();
        private List<ScheduleModel> _allScheduleList = new List<ScheduleModel>();

        [ObservableProperty]
        private DateTime _currentDate = DateTime.Now;

        [ObservableProperty]
        private bool _isBusy;

        public ScheduleListViewModel()
        {
            AddAllScheduleList();
        }



        private void AddAllScheduleList()
        {
            var scheudleList = new List<ScheduleModel>();
            scheudleList.Add(new ScheduleModel
            {
                AppName = "Închiriez apartament 2 camere cartierul Dragoș vodă",
                ImageUrl = "ap1.jpeg",
                Price = "Pret: 500 lei",
                Description = "Apartamentul este compus din 1 cameră, living, bucătarie open space, baie și un balcon designul este clasic si modernt",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(24),
                Location = "Locatie: Cluj",
                BackgroundColor = Color.FromArgb("#232325"),
            });

            scheudleList.Add(new ScheduleModel
            {
                AppName = "Apartament 2 camere, Militari - Rosu - Cartierul Crinului",
                ImageUrl = "ap2.jpeg",
                Price = "Pret: 700 lei",
                Description = "Str. Crinului Nr. 42, la 7 minute de mers pe jos pana la statia STB General Praporgescu (STB 434), an constructie 2019, etaj parter/P+3E.",
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddHours(48),
                Location = "Locatie: Satu Mare",
                BackgroundColor = Color.FromArgb("#232325"),
            });

            scheudleList.Add(new ScheduleModel
            {
                AppName = "Chirie apartament 3 camere Unirii",
                ImageUrl = "ap3.jpeg",
                Price = "Pret: 1000 lei",
                Description = "Apartamentul este izolat eficient, cu centrala proprie, geamuri termopan, usa metalica.",
                StartDateTime = DateTime.Now.Date.AddDays(1).Add(new TimeSpan(13, 0, 0)),
                EndDateTime = DateTime.Now.Date.AddDays(1).Add(new TimeSpan(14, 0, 0, 0)).AddHours(4),
                Location = "Locatie: Bucuresti",
                BackgroundColor = Color.FromArgb("#232325"),
            });

            scheudleList.Add(new ScheduleModel
            {
                AppName = "Garsoniera de inchiriat 1 decembhrie 1918",
                ImageUrl = "ap4.jpeg",
                Price = "Pret: 1200 lei",
                Description = "Se ofera spre inchiriere o garsoniera o camera, un dormitor, etaj 2 / 5, confort I, in bloc mixt, decomandat, constructie finalizata, 39mp, constr. 2021, supr. utila : 44mp, utilat, o baie, o bucatarie, in apropiere de metrou, transport in comun, parc, magazine, mall, piata, unitate sanitara, scoala, gradinita, loc parcare, centrala termica proprie, gresie, faianta, parchet, tv, frigider",
                StartDateTime = DateTime.Now.AddDays(1).Add(new TimeSpan(15, 0, 0)),
                EndDateTime = DateTime.Now.AddDays(3).Add(new TimeSpan(16, 0, 0)),
                Location = "Locatie: Tara Oasului",
                BackgroundColor = Color.FromArgb("#232325"),
            });

            scheudleList.Add(new ScheduleModel
            {
                AppName = "Garsoniera de inchiriat-Calea Dorobanti",
                ImageUrl = "ap6.jpeg",
                Price = "Pret: 1500 lei",
                Description = "Garsoniera de inchiriat, Calea Dorobantilor, Bloc BRD, et 6/10, mobilata modern, toate utilitatile, Balcon 4m2, AC, vedere pe spate, zona cu liniste.\r\nGarsoniera este disponibila imediat.\r\nPentru informatii suplimentare,va asteptam sa ne contactati",
                StartDateTime = DateTime.Now.AddDays(2).Add(new TimeSpan(19, 0, 0)),
                EndDateTime = DateTime.Now.AddDays(4).Add(new TimeSpan(20, 0, 0)),
                Location = "Locatie: Cluj",
                BackgroundColor = Color.FromArgb("#232325"),
            });

            scheudleList.Add(new ScheduleModel
            {
                AppName = "sat vacanta,apartament 2 camere confort 3",
                ImageUrl = "ap7.jpeg",
                Price = "Pret: 750 lei",
                Description = "sat vacanta,apartament 2 camere confort 3",
                StartDateTime = DateTime.Now.AddDays(2).Add(new TimeSpan(19, 0, 0)),
                EndDateTime = DateTime.Now.AddDays(8).Add(new TimeSpan(20, 0, 0)),
                Location = "Locatie: Hurezu Mare",
                BackgroundColor = Color.FromArgb("#232325"),
            });

            _allScheduleList.AddRange(scheudleList);

           BindDataToScheduleList();
        }

        public void BindDataToScheduleList()
        {

            IsBusy = true;
            Task.Run(async () =>
            {

                await Task.Delay(500);
                var filterScheduleList = _allScheduleList.Where(schedule => schedule.StartDateTime.Date == CurrentDate.Date).ToList();


                App.Current.Dispatcher.Dispatch(() =>
                {
                    ScheduleList.Clear();
                    foreach (var schedule in filterScheduleList)
                    {
                        ScheduleList.Add(schedule);
                    }
                    GetWeekDaysInfo();
                    IsBusy = false;
                });
            });



        }

        private void GetWeekDaysInfo()
        {
            DateTime startDayOfWeek = CurrentDate.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
                (int)CurrentDate.DayOfWeek);

            WeekDays.Clear();
            for (int i = 0; i < 7; i++)
            {
                var recordToAdd = new DaysModel
                {
                    DayName = DayOfWeekChar((int)startDayOfWeek.DayOfWeek),
                    Date = startDayOfWeek.Date,
                    IsSelected = startDayOfWeek.Date == CurrentDate.Date,
                };

                WeekDays.Add(recordToAdd);
                startDayOfWeek = startDayOfWeek.AddDays(1);
            }

        }

        private char DayOfWeekChar(int dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case 0:
                    return 'D';
                case 1:
                    return 'L';
                case 2:
                    return 'M';
                case 3:
                    return 'M';
                case 4:
                    return 'J';
                case 5:
                    return 'V';
                case 6:
                    return 'S';
            }
            return ' ';
        }

        [RelayCommand]
        public void WeekDaysSelected(DaysModel item)
        {
            WeekDays.ToList().ForEach(f => f.IsSelected = false);
            item.IsSelected = true;
            CurrentDate = item.Date;

            BindDataToScheduleList();
        }
    }
}
