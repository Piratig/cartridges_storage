using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Сartridges_storage.Model
{

    public static class Queries
    {       
        // Main querie
        private static void List_output()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<Cartridge> cartridgesList = new List<Cartridge>();

            String sql = "SELECT c_name, " +
                "(SELECT CONCAT(p_compony, ' ', p_name) FROM Printers " +
                "WHERE Printers.printer_Id = Cartridges.for_printer) AS Printer" +
                "c_color, " +
                "storage_num, " +
                "warehouse_num " +
                "FROM Cartridges";

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cartridgesList.Add(new Cartridge()
                    {
                        Title = reader.GetString(4),
                        Printer = reader.GetString(4),
                        C_color = reader.GetString(4),
                        Storage_num = reader.GetInt32(0),
                        Warehouse_nume = reader.GetInt32(0)
                    });
                }
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

        // 
    }
}
