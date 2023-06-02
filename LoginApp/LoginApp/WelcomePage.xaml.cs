using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {

        public WelcomePage(string username)
        {
            InitializeComponent();

            labelUsername.Text = "Welcome, " + username + "!";
        }

        public async void OnLogoutButtonClicked (object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}