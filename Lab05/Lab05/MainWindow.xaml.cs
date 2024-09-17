using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Lab05
{
    public partial class MainWindow : Window
    {
        string connectionString = "Server=LAB1507-18\\SQLEXPRESS03; Database=Neptuno; User Id=userPostillos; Password=123456";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Navegar a la ventana de "Insertar"
        private void Insertar_Click(object sender, RoutedEventArgs e)
        {
            Insertar insertarWindow = new Insertar();
            insertarWindow.Show();
        }

        // Navegar a la ventana de "Actualizar"
        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar actualizarWindow = new Actualizar();
            actualizarWindow.Show();
        }

        // Navegar a la ventana de "Eliminar"
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar eliminarWindow = new Eliminar();
            eliminarWindow.Show();
        }

        // Listar los clientes en el DataGrid
        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Clientes", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    listGrid.ItemsSource = dt.DefaultView;  // Mostrar los datos en el DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}