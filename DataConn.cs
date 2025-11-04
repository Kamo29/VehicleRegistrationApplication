using System;
using System.Data;
using System.Data.SqlClient;

namespace VehicleRegistration
{
    class Database
    {
        private string connectionString = "Server=YOUR_SERVER;Database=(Vehicle DB);User Id=YOUR_USER;Password=YOUR_PASSWORD;";

        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Connected to VehicleDB successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to DB: " + ex.Message);
            }
            return conn;
        }

        // Example: Insert Vehicle
        public void InsertVehicle(string regNumber, string ownerName, string vehicleType)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO Vehicles (RegNumber, OwnerName, VehicleType) VALUES (@RegNumber, @OwnerName, @VehicleType)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RegNumber", regNumber);
                    cmd.Parameters.AddWithValue("@OwnerName", ownerName);
                    cmd.Parameters.AddWithValue("@VehicleType", vehicleType);

                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rows} vehicle inserted.");
                }
            }
        }

        // Example: Retrieve Vehicles
        public void GetVehicles()
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Vehicles";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["VehicleId"]}: {reader["RegNumber"]} - {reader["OwnerName"]} - {reader["VehicleType"]}");
                    }
                }
            }
        }
    }
}
