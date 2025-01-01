using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CW18.Db
{
    public static class DbConfig
    {
        public static string ConnectionString { get; set; }
        static DbConfig()
        {
            ConnectionString = @"Server=DESKTOP-G8DPHTL;Database=Bank22;Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}
