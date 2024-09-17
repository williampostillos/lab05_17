using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Lab05
{
    public partial class Eliminar : Window
    {
        string connectionString = "Server=LAB1507-18\\SQLEXPRESS03; Database=Neptuno; User Id=userPostillos; Password=123456";

        public Eliminar()
        {
            InitializeComponent();
        }

        // Evento del botón "Eliminar"
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdCliente.Text))
                {
                    MessageBox.Show("Por favor, ingrese un ID de cliente.");
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Asignar el valor de txtIdCliente al parámetro del query
                    cmd.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);

                    // Ejecutar el comando SQL
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente eliminado exitosamente.");
                        this.Close();  // Cerrar la ventana después de eliminar
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente con ese ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
