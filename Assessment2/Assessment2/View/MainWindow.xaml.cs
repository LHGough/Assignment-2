using System;
using System.Collections.Generic;
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

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string STAFF_LIST_KEY = "staffList";
        private Faculty faculty;

        private int[] ID = { 1, 2, 3, 4 };
        private string[] researchers = { "John Smith", "Mary Overland", "Obadiah Beetlejuice", "Frodo Baggins" };

        private void bindListBox()
        {
            researcherListBox.ItemsSource = researchers;
        }

       
        public MainWindow()
        {
            InitializeComponent();
            bindListBox();

            faculty = (Faculty)(Application.Current.FindResource(STAFF_LIST_KEY) as ObjectDataProvider).ObjectInstance;

        }

        private void researcherListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(researcherListBox.SelectedItem.ToString(), "researchers", MessageBoxButton.OK, MessageBoxImage.Information); ;
        }


        private void sampleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                DetailsPanel.DataContext = e.AddedItems[0];
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The text entered is: " + searchTextBox.Text);
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                searchButton_Click(sender, e);
            }
        }

        private void btnDeleteOne_Click(object sender, RoutedEventArgs e)
        {

            DetailsPanel.DataContext = new { Name = "Fred", SkillCount = 5 };


            if (faculty.VisibleWorkers.Count > 0)
            {
                Researcher theRemoved = faculty.VisibleWorkers[0]; //this is just to keep the GUI tidy (after Task 4 implemented)
                faculty.VisibleWorkers.RemoveAt(0); //the actual removal step
                //completing keeping the GUI tidy (something similar may be required in the assignment)
                if (DetailsPanel.DataContext == theRemoved)
                {
                    DetailsPanel.DataContext = null;
                }
            }
        }

    }
}
