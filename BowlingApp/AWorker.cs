using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BowlingLib.model;

namespace BowlingApp
{
    public class AWorker
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public AWorker()
        {
        }

        public void Start()
        {
            //var allPersons = GetAllPersons();
            //Console.WriteLine("ALLE: " + string.Join(',', allPersons));


            //var p = GetPersonByPhoneNo("22334455");
            //Console.WriteLine("22334455: " + p);

            //Person nyp = new Person("33445566", "Anders", 41);
            //Person ny = AddPerson(nyp);
            //Console.WriteLine("NY person : " + ny);
            //Console.ReadKey();

            //nyp.ShoeSize = 40;
            //var updatePerson = UpdatePerson("33445566", nyp);
            //Console.WriteLine("Updated " + updatePerson);
            //Console.ReadKey();

            //Person slet = DeletePersonByPhoneNo("33445566");
            //Console.WriteLine("Slettet " + slet);
            //Console.ReadKey();
            try
            {
                TimeSpan time = new TimeSpan(10, 0, 0);
                Booking nybooking = new Booking(4, DateTime.Now, time, "11223344", 4);
                Booking retur = AddBooking(nybooking);
                Console.WriteLine("Booking  " + retur);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fejl:: " + e.Message);
            }
        }


        private List<Person> GetAllPersons()
        {
            List<Person> personer = new List<Person>();

            string queryString = "select * from Person";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person p = ReadPerson(reader);
                    personer.Add(p);
                }
            }


            return personer;
        }

        

        private Person GetPersonByPhoneNo(string phone)
        {
            Person person = new Person();

            string queryString = "select * from Person where Phone =  @Phone";
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@Phone", phone);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    person = ReadPerson(reader);
                }
            }

            return person;
        }

        private Person AddPerson(Person person)
        {
            string queryString = "insert into Person Values(@Phone,@PName,@Size)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@Phone", person.Phone);
                command.Parameters.AddWithValue("@PName", person.Pname);
                command.Parameters.AddWithValue("@Size", person.ShoeSize);


                int rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Person er ikke oprettet");
                }

                return GetPersonByPhoneNo(person.Phone);
            }

        }

        private Person DeletePersonByPhoneNo(string phone)
        {
            Person p = GetPersonByPhoneNo(phone);

            string queryString = "Delete from Person where Phone = @Phone";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@Phone", phone);
                
                int rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Person er ikke slettet");
                }

                return p;
            }
        }

        private bool UpdatePerson(string phone, Person person)
        {
            string queryString = "Update Person set Phone = @Phone, PName = @PName, ShoeSize = @Size where Phone = @UpdatePhone";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@UpdatePhone", phone);
                command.Parameters.AddWithValue("@Phone", person.Phone);
                command.Parameters.AddWithValue("@PName", person.Pname);
                command.Parameters.AddWithValue("@Size", person.ShoeSize);

                int rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    return false;
                }

                return true;
            }
        }

        private Person ReadPerson(SqlDataReader reader)
        {
            Person p = new Person();

            p.Phone = reader.GetString(0);
            p.Pname = reader.GetString(1);
            p.ShoeSize = reader.GetInt32(2);

            return p;
        }



        private Booking AddBooking(Booking booking)
        {
            string queryString = "insert into Booking (BookingDate,BookingTime,PersonPhone,BowlingAlley) Values(@Date,@Time,@Phone,@Alley)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@Date", booking.BookingDate);
                command.Parameters.AddWithValue("@Time", booking.BookingTime);
                command.Parameters.AddWithValue("@Phone", booking.PersonPhone);
                command.Parameters.AddWithValue("@Alley", booking.BowlingAlley);


                int rows = command.ExecuteNonQuery();
                if (rows != 1)
                {
                    throw new ArgumentException("Person er ikke oprettet");
                }


                string queryString2 = "select * from Booking where PersonPhone=@GetPhone AND BowlingAlley=@GetAlley";
                
                SqlCommand command2 = new SqlCommand(queryString2, connection);
                //command.Connection.Open();
                command2.Parameters.AddWithValue("@GetPhone", booking.PersonPhone);
                command2.Parameters.AddWithValue("@GetAlley", booking.BowlingAlley);

                SqlDataReader reader = command2.ExecuteReader();

                while (reader.Read())
                {
                    Booking b = new Booking();

                    b.Id = reader.GetInt32(0);
                    b.BookingDate = reader.GetDateTime(1);
                    b.BookingTime = reader.GetTimeSpan(2);
                    b.PersonPhone = reader.GetString(3);
                    b.BowlingAlley = reader.GetInt32(4);

                    return b;
                }


                return null;


            }

        }
    }
}