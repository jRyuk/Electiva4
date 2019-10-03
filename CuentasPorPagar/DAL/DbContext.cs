using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbContext
    {
        private string _connectionString = string.Empty;
        private SqlConnection _sqlConnection;

        private DbContext() {

        }

        private void Open()
        {
            _sqlConnection.Open();
        }

        private void Close()
        {
            _sqlConnection.Close();
        }


        #region Dinamic implementation
        public void  Add<T>() where T : new()
        {
            Open();

            Close();
        }
        #endregion

        #region Singleton Implementation 
        private static DbContext _instance;

       public static DbContext Instance
        {
            get {

                _instance = _instance ?? new DbContext();

                return _instance;
            }
        }

        public void Init(string connection) {

            var connstr = ConfigurationManager.ConnectionStrings[connection];

            if (connstr == null) throw new Exception("Error no se encuentra la cadena de conexion...");
            _connectionString = connstr.ConnectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }
        #endregion
    }
}
