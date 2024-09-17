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
    public partial class Actualizar : Window
    {
        string connectionString = "Server=LAB1507-18\\SQLEXPRESS03; Database=Neptuno; User Id=userPostillos; Password=123456";

        public Actualizar()
        {
            InitializeComponent();
        }

        // Evento del botón "Validar"
        private void Validar_Click(object sender, RoutedEventArgs e)
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
                    string query = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Llenar los campos con los datos del cliente
                        txtNombreCompañia.Text = reader["NombreCompañia"].ToString();
                        txtNombreContacto.Text = reader["NombreContacto"].ToString();
                        txtCargoContacto.Text = reader["CargoContacto"].ToString();
                        txtDireccion.Text = reader["Direccion"].ToString();
                        txtCiudad.Text = reader["Ciudad"].ToString();
                        txtRegion.Text = reader["Region"].ToString();
                        txtCodPostal.Text = reader["CodPostal"].ToString();
                        txtPais.Text = reader["Pais"].ToString();
                        txtTelefono.Text = reader["Telefono"].ToString();
                        txtFax.Text = reader["Fax"].ToString();

                        // Habilitar los campos para edición y el botón "Actualizar"
                        HabilitarCampos(true);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente con ese ID.");
                        HabilitarCampos(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Habilitar o deshabilitar los campos de texto
        private void HabilitarCampos(bool habilitar)
        {
            txtNombreCompañia.IsEnabled = habilitar;
            txtNombreContacto.IsEnabled = habilitar;
            txtCargoContacto.IsEnabled = habilitar;
            txtDireccion.IsEnabled = habilitar;
            txtCiudad.IsEnabled = habilitar;
            txtRegion.IsEnabled = habilitar;
            txtCodPostal.IsEnabled = habilitar;
            txtPais.IsEnabled = habilitar;
            txtTelefono.IsEnabled = habilitar;
            txtFax.IsEnabled = habilitar;
            btnActualizar.IsEnabled = habilitar;
        }

        // Evento del botón "Actualizar"
        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Clientes SET NombreCompañia = @NombreCompañia, NombreContacto = @NombreContacto, CargoContacto = @CargoContacto, Direccion = @Direccion, Ciudad = @Ciudad, Region = @Region, CodPostal = @CodPostal, Pais = @Pais, Telefono = @Telefono, Fax = @Fax WHERE IdCliente = @IdCliente";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Asignar valores a los parámetros
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

                    // Ejecutar la actualización
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente actualizado exitosamente.");
                        this.Close(); // Cerrar la ventana después de actualizar
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el cliente.");
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