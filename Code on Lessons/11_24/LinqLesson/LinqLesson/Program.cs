using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace LinqLesson
{
    class Program
    {
        public int MyProperty { get; set; }
        static async Task Main(string[] args)
        {
            SqlConnection sql = new SqlConnection("Server=PC-ALES\\SQLEXPRESS;Database=SqlPracticeDB;" +
                "Integrated Security=SSPI; Encrypt=true; TrustServerCertificate=True");
            sql.Open();

            SqlCommand command = new SqlCommand("select * from persons " +
                "join Addresses on persons.AddressId = Addresses.Id", sql);
            var exec = await command.ExecuteReaderAsync();

            while(await exec.ReadAsync())
            {
                var name = await exec.GetFieldValueAsync<string>("Name");
                var age = await exec.GetFieldValueAsync<int>("Age");
                var country = await exec.GetFieldValueAsync<string>("Country");
                var city = await exec.GetFieldValueAsync<string>("City");
                Console.WriteLine($"Name: {name}, Age: {age} Country: {country} City: {city}");
            }
                

            
            sql.Close();
        }
    }
    class Student : Person
    {

    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AddressId { get; set; }
    }
    class Adress
    {

    }
}
