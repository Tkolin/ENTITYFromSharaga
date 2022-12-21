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
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Page
    {
        pro_9Entities context;
        Client client;
        bool add = false;
        public AddEditClient(pro_9Entities context)
        {
            InitializeComponent();
            DataContext = context;

            this.context = context;
            add = true;

        }
        public AddEditClient(pro_9Entities context, Client client)
        {
            InitializeComponent();
            DataContext = context;

            this.context = context;
            this.client = client;
            tbox.Text = client.FirstName;
            //И так далие по всем полям
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {        
            client.FirstName = tbox.Text;
            //и тд
            if (add)
                context.Client.Add(client);
            //context.SaveChanges(); раскоментить 
            NavigationService.GoBack();

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
