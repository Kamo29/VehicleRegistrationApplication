using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ExerciseWindowsForms
{
    public class VehicleDB
    {
        private string connectionString = "Server=YOUR_SERVER;Database=VehicleDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;";

        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                Console.WriteLine("Connected to VehicleDB");
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Connection Error: " + ex.Message);
            }
            return conn;
        }

        // Insert vehicle
        public void InsertVehicle(Vehicle vehicle)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"INSERT INTO Vehicles 
                                (Name, Price, Outstanding, Service, Milage, VehicleType)
                                VALUES (@Name, @Price, @Outstanding, @Service, @Milage, @VehicleType)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", vehicle.Name);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(vehicle.Price.Replace("R ", "")));
                    cmd.Parameters.AddWithValue("@Outstanding", decimal.Parse(vehicle.Outstanding.Replace("R ", "")));
                    cmd.Parameters.AddWithValue("@Service", DateTime.Parse(vehicle.Service));
                    cmd.Parameters.AddWithValue("@Milage", vehicle.Milage);
                    cmd.Parameters.AddWithValue("@VehicleType", vehicle is Cars ? "Car" : "Bus");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Get all vehicles
        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Vehicles";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vehicle v;
                        if (reader["VehicleType"].ToString() == "Car")
                            v = new Cars();
                        else
                            v = new Busses();

                        v.Id = Convert.ToInt32(reader["VehicleId"]);
                        v.Name = reader["Name"].ToString();
                        v.Price = "R " + reader["Price"].ToString();
                        v.Outstanding = "R " + reader["Outstanding"].ToString();
                        v.Service = Convert.ToDateTime(reader["Service"]).ToString("yyyy/MM/dd");
                        v.Milage = Convert.ToInt32(reader["Milage"]);

                        vehicleList.Add(v);
                    }
                }
            }
            return vehicleList;
        }
    }
}
