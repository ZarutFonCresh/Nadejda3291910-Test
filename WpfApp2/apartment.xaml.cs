using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для apartment.xaml
    /// </summary>
    public partial class apartment : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Apartments;
        public apartment()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["homeEntities"].ConnectionString;
        }

        private void PageGrid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Apartment";
            Apartments = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(Apartments);
                PageGrids.ItemsSource = Apartments.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void Up()
        {
            SqlCommandBuilder sqlcombil = new SqlCommandBuilder(adapter);
            adapter.Update(Apartments);
        }
        private void Del()
        {
            if (PageGrids.SelectedItem != null)
            {
                for (int i = 0; i < PageGrids.SelectedItems.Count; i++)
                {
                    DataRowView drv = PageGrids.SelectedItems[i] as DataRowView;
                    if (drv != null)
                    {
                        DataRow dr = (DataRow)drv.Row;
                        dr.Delete();
                    }
                }
            }
            Up();
        }
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            Up();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Del();
        }
    }
}
