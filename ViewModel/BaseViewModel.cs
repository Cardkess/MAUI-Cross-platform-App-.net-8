using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel() { }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;

    public bool IsNotBusy => !IsBusy;

    public virtual Task InitAsync()
    {
        return Task.CompletedTask;
    }
}
