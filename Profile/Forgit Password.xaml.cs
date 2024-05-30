using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Profile
{
    /// <summary>
    /// Interaction logic for Forgit_Password.xaml
    /// </summary>
    public partial class Forgit_Password : Page
    {
        ExamEntities Exam=new ExamEntities();
        public Forgit_Password()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            var value = Exam.userrs.FirstOrDefault(x => x.username == textbox1.Text);
            if (value != null)
            {
               
                
                if(strongpassword(textbox2.Text))
                {
                    value.password = textbox2.Text;
                    Exam.userrs.AddOrUpdate(value);
                    Exam.SaveChanges();
                    MessageBox.Show("Password Updated Successfully");
                    Sign_in sign_In=new Sign_in();
                    this.NavigationService.Navigate(sign_In);   

                }
                else
                {
                    MessageBox.Show("Password not strong");
                }


            }
            else
            {
                MessageBox.Show("This User Not Found");
            }

        }

        private static bool strongpassword(string password)
        {
            return password.Any(char.IsDigit) && password.Any(char.IsLower)&&password.Any(char.IsUpper)&& password.Any(c=> !char.IsLetterOrDigit(c));
        }


        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
