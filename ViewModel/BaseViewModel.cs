﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace MonkeyFinder.ViewModel
{
    //[INotifyPropertyChanged]
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        [ObservableProperty]
        string title;
        public bool IsNotBusy => !IsBusy;


        // For learning from Raw Code
        //public bool IsBusy
        //{
        //    get => isBusy;
        //    set
        //    {
        //        if (isBusy == value)
        //            return;
        //        isBusy = value;
        //        OnPropertyChanged();
        //        OnPropertyChanged(nameof(IsNotBusy));
        //    }
        //}
        //public string Title
        //{
        //    get => title;
        //    set
        //    {
        //        if (title == value)
        //            return;
        //        title = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName]string name=null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
    }
}
