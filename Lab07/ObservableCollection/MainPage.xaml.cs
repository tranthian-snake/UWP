using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ObservableCollection.Models;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ObservableCollection
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Icon> Icons;
        private ObservableCollection<Contact> Contacts;
        public MainPage()
        {
            this.InitializeComponent();
            Icons = new List<Icon>();
            Icons.Add(new Icon { NameIcon = "Male-1", IconPath = "Assets/male-01.png" }); ;
            Icons.Add(new Icon { NameIcon = "Male-2", IconPath = "Assets/male-02.png" });
            Icons.Add(new Icon { NameIcon = "Male-3", IconPath = "Assets/male-03.png" });
            Icons.Add(new Icon { NameIcon = "Female-1", IconPath = "Assets/female-01.png" });
            Icons.Add(new Icon { NameIcon = "Female-2", IconPath = "Assets/female-02.png" });
            Icons.Add(new Icon { NameIcon = "Female-3", IconPath = "Assets/female-03.png" });
            AvatarComboBox.ItemsSource = Icons;
            AvatarComboBox.SelectedIndex = 0;

            Contacts = new ObservableCollection<Contact>();
        }
        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            string avatar = ((Icon)AvatarComboBox.SelectedValue).IconPath;
            Contacts.Add(new Contact { FirstName = FirstNameTextBox.Text, LastName = LastNameTextBox.Text, AvatarPath = avatar });

            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            AvatarComboBox.SelectedIndex = -1;

            FirstNameTextBox.Focus(FocusState.Programmatic);
        }
    }
}
