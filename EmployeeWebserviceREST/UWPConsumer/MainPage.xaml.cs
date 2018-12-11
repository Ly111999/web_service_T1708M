using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPConsumer.EmployeeReference;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPConsumer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        EmployeeReference.EmployeeClient client = new EmployeeReference.EmployeeClient();
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            getEmployee();
        }

        async void getEmployee()
        {
            try
            {
                ProgressBar.IsIndeterminate = true;
                ProgressBar.Visibility = Visibility.Visible;
                GridViewEmployee.ItemsSource = await client.GetProductListAsync();
                ProgressBar.Visibility = Visibility.Collapsed;
                ProgressBar.IsIndeterminate = false;
            }
            catch (Exception e)
            {
                MessageDialog messageDialog = new MessageDialog(e.Message);
                await messageDialog.ShowAsync();
                ProgressBar.Visibility = Visibility.Collapsed;
                ProgressBar.IsIndeterminate = false;
            }
        }

        private async void GridViewEmployee_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count != 0)
                {
                    Employee selectedEmployee = e.AddedItems[0] as Employee;
                    TextBoxName.Text = selectedEmployee.firstName;
                    TextBoxSurName.Text = selectedEmployee.lastName;
                    TextBoxCity.Text = selectedEmployee.address;
                    TextBoxAge.Text = selectedEmployee.age.ToString();
                }
            }
            catch
            {
                MessageDialog messageDialog = new MessageDialog("Error data!");
                await messageDialog.ShowAsync();
                ProgressBar.Visibility = Visibility.Collapsed;
                ProgressBar.IsIndeterminate = false;
            }
        }

        private async void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgressBar.IsIndeterminate = true;
                ProgressBar.Visibility = Visibility.Visible;
                Employee newEmployee = new Employee();
                newEmployee.firstName = TextBoxName.Text;
                newEmployee.lastName = TextBoxSurName.Text;
                newEmployee.age = Int32.Parse(TextBoxAge.Text);
                newEmployee.address = TextBoxCity.Text;
                bool result = await client.AddEmployeeAsync(newEmployee);
                ProgressBar.Visibility = Visibility.Collapsed;
                ProgressBar.IsIndeterminate = false;
                if (result == true)
                {
                    MessageDialog dialog = new MessageDialog("Inserted successfully!");
                    await dialog.ShowAsync();
                    Reset();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Can't insert!");
                    await dialog.ShowAsync();
                }
                getEmployee();
            }
            catch (Exception exception)
            {
                MessageDialog messageDialog = new MessageDialog(exception.Message);
                await messageDialog.ShowAsync();
                ProgressBar.Visibility = Visibility.Collapsed;
                ProgressBar.IsIndeterminate = false;
            }
        }

        void Reset()
        {
            TextBoxName.Text = String.Empty;
            TextBoxSurName.Text = String.Empty;
            TextBoxCity.Text = String.Empty;
            TextBoxAge.Text = String.Empty;
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GridViewEmployee.SelectedItem != null)
            {
                try
                {
                    ProgressBar.IsIndeterminate = true;
                    ProgressBar.Visibility = Visibility.Visible;
                    bool result = await client.DeleteEmployeeAsync((GridViewEmployee.SelectedItem as Employee).empID);
                    if (result == true)
                    {
                        MessageDialog dialog = new MessageDialog("Deleted successfully!");
                        await dialog.ShowAsync();
                        Reset();
                    }
                    else
                    {
                        MessageDialog dialog = new MessageDialog("Can't delete");
                        await dialog.ShowAsync();
                    }
                    getEmployee();
                }
                catch (Exception exception)
                {
                    MessageDialog messageDialog = new MessageDialog(exception.Message);
                    await messageDialog.ShowAsync();
                    ProgressBar.Visibility = Visibility.Collapsed;
                    ProgressBar.IsIndeterminate = false;
                }
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Choise record to delete!");
                await dialog.ShowAsync();
            }
        }

        private async void ButtonModify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgressBar.IsIndeterminate = true;
                ProgressBar.Visibility = Visibility.Visible;
                Employee newEmployee = new Employee();
                newEmployee.empID = (GridViewEmployee.SelectedItem as Employee).empID;
                newEmployee.firstName = TextBoxName.Text;
                newEmployee.lastName = TextBoxSurName.Text;
                newEmployee.age = Int32.Parse(TextBoxAge.Text);
                newEmployee.address = TextBoxCity.Text;

                bool result = await client.PutEmployeeAsync(newEmployee);
                ProgressBar.Visibility = Visibility.Collapsed;
                ProgressBar.IsIndeterminate = false;
                if (result == true) 
                {
                    MessageDialog dialog = new MessageDialog("Edited successfully!");
                    await dialog.ShowAsync();
                    Reset();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Can't edit!");
                    await dialog.ShowAsync();
                }
                getEmployee();
            }
            catch
            {
                MessageDialog messageDialog = new MessageDialog("Choise Employee!");
                await messageDialog.ShowAsync();
                ProgressBar.Visibility = Visibility.Collapsed;
                ProgressBar.IsIndeterminate = false;
            }
        }
    }
}
