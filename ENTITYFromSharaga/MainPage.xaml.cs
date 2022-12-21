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

namespace ENTITYFromSharaga
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        pro_9Entities context;
        public MainPage()
        {
            InitializeComponent();
            context = new pro_9Entities();
            grid.ItemsSource = context.Client.ToList();
            cbox.ItemsSource = context.Gender.ToList();
        }

        private void tbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterGrid();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem == null)
                return;
            context.Client.Remove((Client)grid.SelectedItem);
            grid.SelectedItem = context.Client.ToList();
            //context.SaveChanges();//в этой базе не работает там связи есть надо каскад ставить
       
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditClient(context));
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem == null)
                return;

            NavigationService.Navigate(new AddEditClient(context,(Client)grid.SelectedItem));
        }

        private void cbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterGrid();
        }
        private void FilterGrid()
        {
            List<Client> list = context.Client.ToList();//тут все клиеты
            if (cbox.SelectedItem == null && tbox.Text == "")
                return;


            if (cbox.SelectedItem != null)
            {
                Gender selectGender = cbox.SelectedItem as Gender;
                list = list.Where(p => p.Gender == selectGender).ToList();//если гендер есть берём его
            }
            if (tbox.Text != "")
            {
                list = list.Where(p => p.FirstName.ToLower().Contains(tbox.Text.ToLower())).ToList();//фильтр по имени
            }
            grid.ItemsSource = list;
            
        }

        private void resetFilter_Click(object sender, RoutedEventArgs e)
        {
            tbox.Text = "";
            cbox.SelectedItem = null;
            grid.ItemsSource = context.Client.ToList(); 
        }
    }
}
