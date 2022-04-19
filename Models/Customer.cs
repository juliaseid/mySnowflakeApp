using System;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace mySnowflakeApp.Models
{
  public class Customer
  {
      public int CustomerID { get; set; }
      public string Gender { get; set; }
      public string MaritalStatus {get; set;}
      public string  EducationStatus {get; set;}
      public int PurchaseEstimate {get; set;}
      public string CreditRating {get; set;}
      public int DependentCount {get; set;}
      public int DependentEmployedCount {get; set;}
      public int DependentCollegeCount {get; set;}
      public static Customer Create(IDataRecord record)
      {
        return new Customer
        {
          CustomerID = int.Parse(record["CD_DEMO_SK"].ToString()),
          Gender = (record["CD_GENDER"].ToString()),
          MaritalStatus = (record["CD_MARITAL_STATUS"].ToString()),
        };
      }
  }
}
