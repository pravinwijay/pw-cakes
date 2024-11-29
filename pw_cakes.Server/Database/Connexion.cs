using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer;

namespace pw_cakes.Server.Database
{
    static public class Connexion
    {
        static private SqlConnection objConnex;
    }
}
