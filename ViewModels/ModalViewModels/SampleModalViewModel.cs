using CommunityToolkit.Maui.Views;
using MAUI.Views.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ViewModels.ModalViewModels
{
    public partial class SampleModalViewModel : BaseViewModel
    {
        SampleModal? SampleModal { get; set; }

        [ObservableProperty]
        bool _isWelcomingUser;

        public SampleModalViewModel() { 
            
            IsWelcomingUser = false;

        }

        public async Task<SampleModalTriggers> ShowModal(SampleModalTriggers? trigger)
        {
            if(trigger == SampleModalTriggers.WelcomingUser)
            {
                IsWelcomingUser = true;
            }

            SampleModal = new SampleModal();

            SampleModal.BindingContext = this;

            var result = await Shell.Current.ShowPopupAsync(SampleModal);

            if(result != null)
            {
                return (SampleModalTriggers)result;
            }

            return SampleModalTriggers.None; 
        }

        public void UpdateModal(SampleModalTriggers trigger)
        {
            // IsWelcomingUser = false;
        }


        public async Task CloseModalAsync(SampleModalTriggers action)
        {
            if(SampleModal != null) { 
                
                await SampleModal.CloseAsync(action);
            }
        }


    }
}
