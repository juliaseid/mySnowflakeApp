using System;

namespace mySnowflakeApp.Models 
{
  public class SnowflakeDBSettings 
        {
            public string ConnectionString { get; set; } = null!;

            public string SchemaName {get; set; } = null!;

            public string TableName {get; set;} = null!;

        }
}

