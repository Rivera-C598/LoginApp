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
    public partial class RegisterPage : ContentPage
    {
        private DBConnect dbconnect;
        public RegisterPage()
        {
            InitializeComponent();
            dbconnect = new DBConnect(DependencyService.Get<IFileHelper>().GetLocalFilePath("database.db3"));
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e) 
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            List<User> users = await dbconnect.GetUsersAsync();
            bool usernameExists = users.Any(u => u.Username == username);

            

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {

                if (usernameExists)
                {
                    await DisplayAlert("Registration", "Username already exists", "OK");

                }
                else
                {
                    User newUser = new User
                    {
                        Username = username,
                        Password = password
                    };

                    //Save the user
                    await dbconnect.SaveUserAsync(newUser);
                    await DisplayAlert("Registration", "Registreation success", "OK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Registration", "Error, please enter username and password", "OK");
            }

        }

    }
}