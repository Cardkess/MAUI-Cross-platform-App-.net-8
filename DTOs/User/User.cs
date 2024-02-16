using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.DTOs.User;

public partial class User : ObservableObject
{
    [ObservableProperty]
    string? _userId;

    [ObservableProperty]
    string? _firstName;

    [ObservableProperty]
    string? _lastName;
}
