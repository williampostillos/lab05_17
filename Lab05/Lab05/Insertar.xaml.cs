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
    public partial class Insertar : Window
    {
        string connectionString = "Server=LAB1507-18\\SQLEXPRESS03; Database=Neptuno; User Id=userPostillos; Password=123456";

        public Insertar()
        {
            InitializeComponent();
        }

        // Evento del botón "Insertar"
        private void Insertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Clientes (IdCliente, NombreCompañia, NombreContacto, CargoContacto, Direccion, Ciudad, Region, CodPostal, Pais, Telefono, Fax) " +
                                   "VALUES (@IdCliente, @NombreCompañia, @NombreContacto, @CargoContacto, @Direccion, @Ciudad, @Region, @CodPostal, @Pais, @Telefono, @Fax)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Asignar los valores de los TextBox a los parámetros del query
                    cmd.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);
                    cmd.Parameters.AddWithValue("@NombreCompañia", txtNombreCompañia.Text);
                    cmd.Parameters.AddWithValue("@NombreContacto", txtNombreContacto.Text);
                    cmd.Parameters.AddWithValue("@CargoContacto", txtCargoContacto.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                    cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                    cmd.Parameters.AddWithValue("@Pais", txtPais.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Fax", txtFax.Text);

                    // Ejecutar el comando SQL
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente insertado exitosamente.");
                        this.Close();  // Cerrar la ventana después de la inserción
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el cliente.");
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
