using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginApp
{
    public partial class MainPage : ContentPage
    {
        private DBConnect dbconnect;

        public MainPage()
        {
            InitializeComponent();
            dbconnect = new DBConnect(DependencyService.Get<IFileHelper>().GetLocalFilePath("database.db3"));
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
            List<User> users = await dbconnect.GetUsersAsync();

            User user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Successful login
                await DisplayAlert("Login", "Login successful", "OK");
                // Navigate to the next page

                await Navigation.PushAsync(new WelcomePage(user.Username));
                
            }
            else
            {
                // Invalid login
                await DisplayAlert("Login", "Invalid username or password", "OK");
            }
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
    
}
