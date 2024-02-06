using System;
using System.Data;
using System.Data.OleDb;

class Program
{
    static void Main(string[] args)
    {
        // Ruta del archivo Excel
        string archivoExcel = @"C:\Users\kevin\OneDrive\Escritorio\Boca.xlsx";

        // Cadena de conexión 
        string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={archivoExcel};Extended Properties='Excel 12.0 XML';";

        // Consulta para eliminar datos
        string eliminarQuery = "DELETE FROM [Hoja1$] WHERE Nombre = @nombre";

        // Datos para insertar
        string jugadorEliminado = "Lionel";

        // Ejecutar inserciones
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand command = new OleDbCommand(eliminarQuery, connection))
            {
                //Parametros
                command.Parameters.AddWithValue("@nombre",jugadorEliminado);

                //Abrir conexión y ejecutar la inserción
                connection.Open();

                //Condicion
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    Console.WriteLine("Dato eliminado correctamente");
                }
                else
                {
                    Console.WriteLine("Dato no eliminado");
                }
            }
        }
    }
}