using CommunityToolkit.Mvvm.Input;
using MAUI.Services;
using MAUI.ViewModels;
using MAUI.ViewModels.ModalViewModels;
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

        public SampleModalViewModel SampleModalViewModel { get; set; }  

        [ObservableProperty]
        public int _count = 0;

        public SampleViewModel(IUserService  userService, SampleModalViewModel sampleModalViewModel) { 
        
           _userService = userService;

           SampleModalViewModel = sampleModalViewModel;
        }

        [RelayCommand]
        Task Increment()
        {
            Count++;

            return Task.CompletedTask;
        }

        [RelayCommand]
        Task ShowModal()
        {
           _= SampleModalViewModel.ShowModal(SampleModalTriggers.WelcomingUser);

            return Task.CompletedTask;
        }
    }
}
