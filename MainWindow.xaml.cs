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

namespace CA2
{
    //---------------------------------------------------------------------------------------------------------
    // Name : Ian
    // Date : December 2021
    // Task : CA2 
    //---------------------------------------------------------------------------------------------------------
    public partial class MainWindow : Window
    { 
        static List<Activity> AllActivities = new List<Activity>();
        static List<Activity> SelectedActivities = new List<Activity>();
        static decimal TotalCost = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Create 9 Activities
            Activity activity1 = new Activity("Kayaking",  10.50m, new DateTime(2021, 07, 15), "Learn to Kayak!", Activity.ActivityType.Water);
            Activity activity2 = new Activity("Skydiving",  250.00m, new DateTime(2025, 12, 25), "Learn to Skydive!", Activity.ActivityType.Air);
            Activity activity3 = new Activity("Racing",  10.50m, new DateTime(2020, 05, 10), "Learn to Racing!", Activity.ActivityType.Land);
            Activity activity4 = new Activity("Swimming",  150.00m, new DateTime(2026, 01, 01), "Learn to Swim!", Activity.ActivityType.Water);
            Activity activity5 = new Activity("Dogfighting",  25.00m, new DateTime(2025, 12, 25), "Learn to Dogfight!", Activity.ActivityType.Land);
            Activity activity6 = new Activity("Rollerblading", 105.00m, new DateTime(2021, 12, 31), "Learn to Rollerblade!", Activity.ActivityType.Land);
            Activity activity7 = new Activity("Drowning",  1.00m, new DateTime(2023, 04, 11), "Learn to Drown!", Activity.ActivityType.Water);
            Activity activity8 = new Activity("Falling",  2.00m, new DateTime(2021, 07, 15), "Learn to Fall!", Activity.ActivityType.Air);
            Activity activity9 = new Activity("Running", 0.50m, new DateTime(2021, 12, 01), "Learn to Run!", Activity.ActivityType.Land);

            //Add Each Activity to the All Activities List
            AllActivities.Add(activity1); AllActivities.Add(activity2); AllActivities.Add(activity3);
            AllActivities.Add(activity4); AllActivities.Add(activity5); AllActivities.Add(activity6);
            AllActivities.Add(activity7); AllActivities.Add(activity8); AllActivities.Add(activity9);

            //Sort them by date
            AllActivities.Sort();

            //Adds each activity into the textbox
            for (int i = 0; i < AllActivities.Count; i++)
            {
                lstBxAll.Items.Add(AllActivities[i]);
            }
        }

        private void lstBxAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Empties the desc box
            txtblkDescription.Text = string.Empty;
            Activity selectedActivity = (Activity)lstBxAll.SelectedItem;

            if(selectedActivity != null)
                txtblkDescription.Text = selectedActivity.Desc;
        }

        private void rdBtnAll_Checked(object sender, RoutedEventArgs e)
        {
            txtblkDescription.Text = string.Empty;

            //Clears the list box so it can be reconstructed 
            lstBxAll.Items.Clear();

            //Reconstructs the textbox
            for (int i = 0; i < AllActivities.Count; i++)
            {
                lstBxAll.Items.Add(AllActivities[i]);
            }
        }

        private void rdBtnLand_Checked(object sender, RoutedEventArgs e)
        {
            txtblkDescription.Text = string.Empty;

            //Clears the list box so it can be reconstructed 
            lstBxAll.Items.Clear();

            //New list created for filtered items
            List<Activity> filtered = new List<Activity>();

            foreach (Activity activity in AllActivities)
            {
                if (activity.TypeOfActivity == Activity.ActivityType.Land)
                {
                    filtered.Add(activity);
                }
            }

            //Reconstructs the textbox
            for (int i = 0; i < filtered.Count; i++)
            {
                lstBxAll.Items.Add(filtered[i]);
            }
        }

        private void rdBtnWater_Checked(object sender, RoutedEventArgs e)
        {
            txtblkDescription.Text = string.Empty;

            //Clears the list box so it can be reconstructed 
            lstBxAll.Items.Clear();

            //New list created for filtered items
            List<Activity> filtered = new List<Activity>();

            foreach (Activity activity in AllActivities)
            {
                if (activity.TypeOfActivity == Activity.ActivityType.Water)
                {
                    filtered.Add(activity);
                }
            }

            //Reconstructs the textbox
            for (int i = 0; i < filtered.Count; i++)
            {
                lstBxAll.Items.Add(filtered[i]);
            }
        }

        private void rdBtnAir_Checked(object sender, RoutedEventArgs e)
        {
            txtblkDescription.Text = string.Empty;

            //Clears the list box so it can be reconstructed 
            lstBxAll.Items.Clear();

            //New list created for filtered items
            List<Activity> filtered = new List<Activity>();

            foreach (Activity activity in AllActivities)
            {
                if (activity.TypeOfActivity == Activity.ActivityType.Air)
                {
                    filtered.Add(activity);
                }
            }

            //Reconstructs the textbox
            for (int i = 0; i < filtered.Count; i++)
            {
                lstBxAll.Items.Add(filtered[i]);
            }
        }

        private void btnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity selectedActivity = (Activity)lstBxAll.SelectedItem;
            bool isValid = true;

            for (int i = 0; i < SelectedActivities.Count; i++)
            {
                if (selectedActivity.Date == SelectedActivities[i].Date)
                {
                    MessageBox.Show("Can't have two activities on one day... You'll be knackered!");
                    isValid = false;
                }
            }
           
            if(selectedActivity != null && isValid)
            {
                SelectedActivities.Add(selectedActivity);
                AllActivities.Remove(selectedActivity);
                SelectedActivities.Sort();

                //Clears both list boxs so it can be reconstructed 
                lstBxAll.Items.Clear();
                lstBxSelected.Items.Clear();

                //Reconstructs the textbox
                for (int i = 0; i < AllActivities.Count; i++)
                {
                    lstBxAll.Items.Add(AllActivities[i]);
                }

                //Reconstructs the textbox
                for (int i = 0; i < SelectedActivities.Count; i++)
                {
                    lstBxSelected.Items.Add(SelectedActivities[i]);
                }

                TotalCost += selectedActivity.Cost;
                txtblkTotalCost.Text = $"{TotalCost:c}";
            }   
        }

        private void lstBxSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtblkDescription.Text = string.Empty;
            Activity selectedActivity = (Activity)lstBxSelected.SelectedItem;

            if (selectedActivity != null)
                txtblkDescription.Text = selectedActivity.Desc;
        }

        private void btnRemoveActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity selectedActivity = (Activity)lstBxSelected.SelectedItem;

            if (selectedActivity != null)
            {
                SelectedActivities.Remove(selectedActivity);
                AllActivities.Add(selectedActivity);
                AllActivities.Sort();

                //Clears both list boxs so it can be reconstructed 
                lstBxAll.Items.Clear();
                lstBxSelected.Items.Clear();

                //Reconstructs the textbox
                for (int i = 0; i < AllActivities.Count; i++)
                {
                    lstBxAll.Items.Add(AllActivities[i]);
                }

                //Reconstructs the textbox
                for (int i = 0; i < SelectedActivities.Count; i++)
                {
                    lstBxSelected.Items.Add(SelectedActivities[i]);
                }

                TotalCost -= selectedActivity.Cost;
                txtblkTotalCost.Text = $"{TotalCost:c}";
            }
        }
    }
}
