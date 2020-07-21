using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarin_biometric
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
            if (!isFingerprintAvailable)
            {
                await DisplayAlert("Error",
                    "Biometric authentication is not available or is not configured.", "OK");
                return;
            }

            AuthenticationRequestConfiguration conf =
                new AuthenticationRequestConfiguration("Authentication",
                "Authenticate access to your personal data");

            var authResult = await CrossFingerprint.Current.AuthenticateAsync(conf);
            if (authResult.Authenticated)
            {
                //Success  
                await DisplayAlert("Success", "Authentication succeeded", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Authentication failed", "OK");
            }
        }
    }
}
