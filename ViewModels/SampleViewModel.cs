using CommunityToolkit.Mvvm.Input;
using MAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ViewModels
{
    public partial class SampleViewModel : BaseViewModel
    {
        readonly IUserService _userService;

        [ObservableProperty]
        public int _count = 0;

        public SampleViewModel(IUserService  userService) { 
        
           _userService = userService;
        }

        [RelayCommand]
        Task Increment()
        {
            Count++;

            return Task.CompletedTask;
        }
    }
}
