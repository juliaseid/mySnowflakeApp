using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Extensions.Configuration;
using mySnowflakeApp.Models;

namespace mySnowflakeApp.Services 
{
  public class CustomerService
  {
    private readonly IDbConnection _conn;
    private readonly IConfiguration _configuration;
    public CustomerService (IDbConnection conn, IConfiguration configuration)
    {
      this._conn = conn;
      this._configuration = configuration;
    }
    public IEnumerable<Customer> GetAll(string command)
    {
      IDataReader reader = null;
      try {          
          this._conn.ConnectionString = this._configuration.GetConnectionString("SnowflakeConnection");
          this._conn.Open();

          var query = this._conn.CreateCommand();
          query.CommandText = command;
          reader = query.ExecuteReader();
        }
        catch (Exception exception) {
          Console.WriteLine("Uh oh! Database FAIL!" + exception.ToString()); 
          this._conn.Close();
          yield break;
        }
            while (reader.Read())
            {
              foreach (IDataRecord record in reader as IEnumerable<Customer>)
              { 
                var data = Customer.Create(record);
                Console.WriteLine("I'm returning data!! There are this many records!");
                yield return data;
              }
            }
            this._conn.Close();
    }

    public List<Customer> GetCustomers()
    {
      string selectAllCommand = "select * from CUSTOMER_DEMOGRAPHICS";
      List<Customer> results = GetAll(selectAllCommand).ToList<Customer>();
      return results;
    }
    
  }
}