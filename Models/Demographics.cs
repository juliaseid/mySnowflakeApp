using System;
using System.Data;
using System.Text.Json;
using System.Collections.Generic;
using mySnowflakeApp.Models;
using mySnowflakeApp.Services;

namespace mySnowflakeApp.Models
{
  public class Demographics
  {
    public int MTotal {get; set;}
    public int UTotal {get; set;}
    public int MarriedPercentage {get; set;}
    public int UnMarriedPercentage {get; set;}
    public int PurchaseAvg {get; set;}

    public static Demographics Create(List<Customer> customers)
    {
      int MCount = 0;
      int UCount = 0;
      int allPurchases = 0;
      int purchaseAvg = 0;
      int customerCount = customers.Count;
      
      if (customerCount != 0)
      {
        foreach(Customer c in customers)
      {
        string m = c.MaritalStatus;
        int p = c.PurchaseEstimate;

        if (m == "M")
        {
          MCount ++;
        }
        else if (m == "S" | m == "D" | m == "W" | m == "U")
        {
          UCount ++;
        }
        // else if (m == "D")
        // {
        //   maritalD ++;
        // }
        // else if (m == "W")
        // {
        //   maritalW ++;
        // }
        // else if (m == "U")
        // {
        //   maritalU ++;
        // }
        allPurchases += c.PurchaseEstimate;
      }
        return new Demographics
        {
          MTotal = MCount,
          UTotal = UCount,
          MarriedPercentage = MCount / customerCount,
          UnMarriedPercentage = UCount / customers.Count,
          PurchaseAvg = purchaseAvg
        };
      }
      else 
      {
        return new Demographics
        {
          MTotal = MCount,
          UTotal = UCount,
          MarriedPercentage = 0,
          UnMarriedPercentage = 0,
          PurchaseAvg = purchaseAvg
        };
      }      
    }

    public static string GetMaritalData(Demographics data)
    {
      string jsonString = JsonSerializer.Serialize<Demographics>(data);
      Console.WriteLine ("You got serialized data!" + jsonString);
      return jsonString;
    }
  }
}