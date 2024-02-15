﻿using CommunityToolkit.Mvvm.Input;
using MAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ViewModel
{
    public partial class SampleViewModel : BaseViewModel
    {
        readonly IUserService _userService;
        public SampleViewModel(IUserService  userService) { 
        
            _userService = userService;
        }

        [RelayCommand]
        Task Increment()
        {
            return Task.CompletedTask;
        }
    }
}