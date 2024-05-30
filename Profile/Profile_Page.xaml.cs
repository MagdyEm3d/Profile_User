using System.Windows.Controls;
namespace Profile
{
   
    public partial class Profile_Page : Page
    {
        ExamEntities Exam=new ExamEntities();
        public Profile_Page(userr user)
        {
            InitializeComponent();
            DisplayUserInfo(user);
        }

        private void DisplayUserInfo(userr user)
        {
            lable.Content = "Welcome " + user.username;
            textbox1.Text = user.username;
            password.Password = user.password;
            textbox3.Text = user.age.ToString();
            textbox5.Text = user.phonenumber;
            textbox6.Text = user.city;
            textbox4.Text = user.gender;
        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textbox4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
