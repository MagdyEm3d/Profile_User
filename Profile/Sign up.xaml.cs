using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Profile
{
    /// <summary>
    /// Interaction logic for Sign_up.xaml
    /// </summary>
    public partial class Sign_up : Page
    {
        ExamEntities Exam = new ExamEntities();

        public Sign_up()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forgit_Password forgit_Password = new Forgit_Password();
            this.NavigationService.Navigate(forgit_Password);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Sign_in sign_In = new Sign_in();
            this.NavigationService.Navigate(sign_In);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(textbox1.Text) ||
                string.IsNullOrWhiteSpace(textbox2.Text) ||
                string.IsNullOrWhiteSpace(textbox3.Text) ||
                string.IsNullOrWhiteSpace(textbox4.Text) ||
                combox.SelectedItem == null ||
                (male.IsChecked == false && female.IsChecked == false))
            {
                MessageBox.Show("Please Enter All Information");
                return;
            }

           
            if (!strongpassword(textbox2.Text))
            {
                MessageBox.Show("Password Not Strong");
                return;
            }

          
            if (textbox4.Text.Length != 11)
            {
                MessageBox.Show("Phone number must be 11 digits");
                return;
            }

            
            userr userr = new userr
            {
                username = textbox1.Text,
                password = textbox2.Text,
                age = int.Parse(textbox3.Text),
                phonenumber = textbox4.Text
            };

           
            if (male.IsChecked == true)
            {
                userr.gender = "Male";
            }
            else if (female.IsChecked == true)
            {
                userr.gender = "Female";
            }

           
            string selectedvalue = ((ComboBoxItem)combox.SelectedItem).Content.ToString();
            userr.city = selectedvalue;

            Exam.userrs.Add(userr);
            Exam.SaveChanges();

            
            MessageBox.Show("Sign Up Successfully");
            Profile_Page profile_Page = new Profile_Page(userr);
            this.NavigationService.Navigate(profile_Page);
        }

        private static bool strongpassword(string password)
        {
            return password.Any(char.IsDigit) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsUpper) &&
                   password.Any(c => !char.IsLetterOrDigit(c));
        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void textbox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
