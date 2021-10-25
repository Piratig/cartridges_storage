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
    public class Queries
    {
        private const string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Igor\Downloads\skillfactory_rds\-artridges_storage\artridges\Cartridge.mdf; Integrated Security = True";

        // Digest querie 
        internal static List<Cartridge> List_output()
        {
            List<Cartridge> cartridgesList = new List<Cartridge>();

            String sql = "SELECT Cartridges.c_name, " +
                "CONCAT(Printers.p_compony, ' ', Printers.p_name), " +
                "Cartridges.c_color, " +
                "Cartridges.storage_num, " +
                "Cartridges.warehouse_num " +
                "FROM Cartridges JOIN Printers ON Cartridges.for_printer=Printers.printer_Id ";

            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cartridgesList.Add(new Cartridge()
                    {
                        Title = reader.GetString(0),
                        Printer = reader.GetString(1),
                        CartridgeColor = reader.GetString(2),
                        StorageNum = reader.GetInt32(3),
                        WarehouseNume = reader.GetInt32(4)
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
            return cartridgesList;
        }

        // Inventory number check
        internal static List<Transaction> PrintersInventoryNumberCheck(int p_i)
        {
            List<Transaction> transaction = new List<Transaction>();
            String sql = String.Format( "SELECT order_num, " +
                "(SELECT CONCAT(c_name, '/', c_color) FROM Cartridges " +
                "WHERE Transactions.cartridge_id = Cartridges.cartridge_ID), " +
                "quantity, date " +
                "FROM Transactions " +
                "WHERE printer_inventory = '{0}'", p_i);

            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    transaction.Add(new Transaction()
                    {
                        OrderId = reader.GetInt32(0),
                        CartridgeName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                        TransactionDate = reader.GetDateTime(3),
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

            return transaction;
        }

        // Cartriges by inventory number check
        internal static List<Cartridge> CartridgesByInventoryNumberCheck(int p_i)
        {
            List<Cartridge> CartridgesList = new List<Cartridge>();
            String sql = String.Format("SELECT c_name " +
                "FROM Cartridges " +
                "WHERE for_printer = (SELECT printer_Id " +
                "FROM Printers WHERE inventory_number = {0})", p_i);

            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CartridgesList.Add(new Cartridge()
                    {
                        Title = reader.GetString(0)
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
            return CartridgesList;
        }

        // Pie filling
        internal static List<ForPie> PrintersForPie()
        {
            List<ForPie> p_com = new List<ForPie>();

            String sql = "SELECT p_compony, " +
                "COUNT(*) AS p_q " +
                "FROM Printers " +
                "GROUP BY p_compony";

            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    p_com.Add(new ForPie()
                    {
                        PrinterName = reader.GetString(0),
                        PrinterNum = reader.GetInt32(1)
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
            return p_com;
        }

        // Storage value
        internal static int StorageValue()
        {
            int a = 0;
            String sql = "SELECT SUM(storage_num) " +
                         "FROM Cartridges ";
            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    a = reader.GetInt32(0);
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
            return a;
        }

        // Warehouse value
        internal static int WarehouseValue()
        {
            int a = 0;
            String sql = "SELECT SUM(warehouse_num) " +
                         "FROM Cartridges ";
            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    a = reader.GetInt32(0);
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
            return a;
        }

    }
}
