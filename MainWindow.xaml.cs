using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<customer> result = new List<customer>();
        int i = 0;
        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";
        public class customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string DOB { get; set; }
            public string EmailID { get; set; }
            public string Address { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            customer customer1 = new customer()
            {
                ID = 1,
                Name = "Divya",
                DOB = "10/18/2020",
                EmailID = "dv@gmail.com",
                Address = "vizag"
            };
            customer customer2 = new customer()
            {
                ID = 2,
                Name = "shannu",
                DOB = "10/18/2020",
                EmailID = "shannu@gmail.com",
                Address = "hyderabad"

            };
            customer customer3 = new customer()
            {
                ID = 3,
                Name = "Suma",
                DOB = "10/18/2020",
                EmailID = "SF@gmail.com",
                Address = "QATeam"
            };

            result.Add(customer1);
            result.Add(customer2);
            result.Add(customer3);

            foreach (var item in result)
            {
                Name.Text = item.Name;
                DOB.Text = item.DOB;
                Email.Text = item.EmailID;
                Address.Text = item.Address;
                ID.Content = item.ID;
                break;
            }
            Name.IsReadOnly = true;
            Email.IsReadOnly = true;
            Address.IsReadOnly = true;
            update.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cust = result.FirstOrDefault(x => x.ID == Convert.ToInt32(ID.Content));
            if (cust != null)
            {
                if (Name.Text != String.Empty & DOB.Text != String.Empty)
                {
                    if (Email.Text != String.Empty)
                    {
                        bool isEmail = Regex.IsMatch(Email.Text, MatchEmailPattern);
                        if (isEmail)
                        {
                            if (Address.Text != String.Empty)
                            {
                                cust.Name = Name.Text;
                                cust.DOB = DOB.Text;
                                cust.EmailID = Email.Text;
                                cust.Address = Address.Text;
                                Message.Content = "Successfully updated";
                                foreach (var item in result)
                                {
                                    Name.Text = item.Name;
                                    DOB.Text = item.DOB;
                                    Email.Text = item.EmailID;
                                    Address.Text = item.Address;
                                    ID.Content = item.ID;
                                    break;
                                }
                                Name.IsReadOnly = true;
                                Email.IsReadOnly = true;
                                Address.IsReadOnly = true;
                            }
                            else
                            {
                                Message.Content = "Enter Address";
                            }
                        }
                        else
                        {
                            Message.Content = "Enter Valid Email ID";
                        }
                    }
                    else
                    {
                        Message.Content = "Enter Email ID";
                    }
                }
                else
                {
                    Message.Content = "Enter FullName";
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Name.IsReadOnly = false;
            Email.IsReadOnly = false;
            Address.IsReadOnly = false;
            update.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (i < result.Count - 1)
            {
                i++;
                ID.Content = result[i].ID;
                Name.Text = result[i].Name;
                DOB.Text = result[i].DOB;
                Email.Text = result[i].EmailID;
                Address.Text = result[i].Address;
            }
            else
            {
                if (result.Count > 0)
                {
                    i = 0;
                    ID.Content = result[i].ID;
                    Name.Text = result[i].Name;
                    DOB.Text = result[i].DOB;
                    Email.Text = result[i].EmailID;
                    Address.Text = result[i].Address;
                }
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (i == result.Count - 1 || i != 0)
            {
                i--;
                ID.Content = result[i].ID;
                Name.Text = result[i].Name;
                DOB.Text = result[i].DOB;
                Email.Text = result[i].EmailID;
                Address.Text = result[i].Address;
            }
            else
            {
                i = result.Count - 1;
                ID.Content = result[i].ID;
                Name.Text = result[i].Name;
                DOB.Text = result[i].DOB;
                Email.Text = result[i].EmailID;
                Address.Text = result[i].Address;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Name.IsReadOnly = true;
            Email.IsReadOnly = true;
            Address.IsReadOnly = true;
            update.Visibility = Visibility.Hidden;
            Cancel.Visibility = Visibility.Hidden;
            insert.Visibility = Visibility.Hidden;
            Add.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Visible;
            Message.Content = string.Empty;
            foreach (var item in result)
            {
                Name.Text = item.Name;
                DOB.Text = item.DOB;
                Email.Text = item.EmailID;
                Address.Text = item.Address;
                ID.Content = item.ID;
                break;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Name.Text = string.Empty;
            DOB.Text = string.Empty;
            Email.Text = string.Empty;
            Address.Text = string.Empty;
            ID.Content = string.Empty;
            Name.IsReadOnly = false;
            Email.IsReadOnly = false;
            Address.IsReadOnly = false;
            insert.Visibility = Visibility.Visible;
            update.Visibility = Visibility.Hidden;
            Cancel.Visibility = Visibility.Visible;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != String.Empty & DOB.Text != String.Empty)
            {
                if (Email.Text != String.Empty)
                {
                    bool isEmail = Regex.IsMatch(Email.Text, MatchEmailPattern);
                    if (isEmail)
                    {
                        if (Address.Text != String.Empty)
                        {
                            customer cust = new customer();
                            cust.ID = result.Count + 1;
                            cust.Name = Name.Text;
                            cust.DOB = DOB.Text;
                            cust.EmailID = Email.Text;
                            cust.Address = Address.Text;
                            result.Add(cust);
                            foreach (var item in result)
                            {
                                Name.Text = item.Name;
                                DOB.Text = item.DOB;
                                Email.Text = item.EmailID;
                                Address.Text = item.Address;
                                ID.Content = item.ID;
                                break;
                            }
                            Name.IsReadOnly = true;
                            Email.IsReadOnly = true;
                            Address.IsReadOnly = true;
                            Message.Content = "Successfully inserted";
                        }
                        else
                        {
                            Message.Content = "Enter Address";
                        }
                    }
                    else
                    {
                        Message.Content = "Enter Valid Email ID";
                    }
                }
                else
                {
                    Message.Content = "Enter Email ID";
                }
            }
            else
            {
                Message.Content = "Enter FullName";
            }
        }
    }
}
