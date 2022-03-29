using AppDevWorkShop.Models;
using Oracle.ManagedDataAccess.Client;

namespace AppDevWorkShop.Services
{
    public class BikeService
    {
        // connection string for the database
        string constr = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=APP_DEV;PASSWORD=APP_DEV;";

        // method to Add Bike in database
        public void AddBike(Bike bike)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("INSERT INTO Bike (BikeName, Company, Horsepower) " +
                            "VALUES ('{0}','{1}', {2})",
                            bike.BikeName,
                            bike.Company,
                            bike.Horsepower);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // method to delete Bike from database
        public void DeleteBike(int id)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("DELETE from Bike WHERE Bike_ID = " + id); ;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to update data in bike table
        public void EditBike(Bike bike)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(constr))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = String.Format("UPDATE Bike SET BikeName = '{1}', Company = '{2}', Horsepower = {3} WHERE Bike_ID = {0}",
                            bike.Bike_ID,
                            bike.BikeName,
                            bike.Company,
                            bike.Horsepower);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        // function to get all data in bike table
        public IEnumerable<Bike> GetAllBike()
        {
            List<Bike> bikes = new List<Bike>();
            using (OracleConnection connection = new OracleConnection(constr))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT Bike_ID, BikeName, Company, Horsepower FROM Bike";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Bike bike = new Bike
                        {
                            Bike_ID = Convert.ToInt32(dataReader["Bike_ID"]),
                            BikeName = dataReader["BikeName"].ToString(),
                            Company = dataReader["Company"].ToString(),
                            Horsepower = Convert.ToInt32(dataReader["Horsepower"])
                        };
                        bikes.Add(bike);
                    }
                }
            }
            return bikes;
        }

        public Bike GetBikeById(int id)
        {
            Bike bike = new Bike();
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "SELECT Bike_ID, BikeName, Company, Horsepower FROM Bike WHERE Bike_ID = " + id;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        bike.Bike_ID = Convert.ToInt32(rdr["Bike_ID"]);
                        bike.BikeName = rdr["BikeName"].ToString();
                        bike.Company = rdr["Company"].ToString();
                        bike.Horsepower = Convert.ToInt32(rdr["Horsepower"]);
                    }
                }
            }
            return bike;
        }
    }
}