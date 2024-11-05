using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonkeyFinder.Model;
using MonkeyFinder.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeyFinder.ViewModel
{
    public partial class MonkeysViewModel : BaseViewModel
    {
        MonkeyService monkeyService;
        public ObservableCollection<Monkey> Monkeys { get; } = new();  //new ObservableCollection<Monkey>(); //We can use both
       
        public MonkeysViewModel(MonkeyService monkeyService) 
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
        }

        [RelayCommand]
        async Task GetMonkeysAsync()
        {
            if(IsBusy) 
                return;

            try
            {
                IsBusy = true;
                var monkeys = await monkeyService.GetMonkeys();

                if(Monkeys.Count != 0 ) 
                    Monkeys.Clear();

                foreach(var monkey in monkeys)
                    Monkeys.Add(monkey);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Failed! Something went wrong! Message:{ex.Message}", "Ok"); //Note : We should not show the error message to our user.
            }
            finally 
            { 
                IsBusy = false;
            }
        }
    }
}
