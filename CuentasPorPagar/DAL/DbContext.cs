using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

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


        #region Dynamic implementation
        public int Add<T>(T element) where T : new()
        {
            Open();

            var strCommand = GenerateInsert(element);

            using (var cmd = new SqlCommand(strCommand, _sqlConnection))
            {
                 var result  = cmd.ExecuteNonQuery();
                Close();

                return result;
            }
        }

        private string GenerateInsert<T>(T element) where T: new() {
            var type = element.GetType();
            var properties = type.GetProperties();

            var last = properties.LastOrDefault();
            

            var baseCommand = $"Insert into {type.Name} (";

            foreach (var property in properties) {

                if (property.Name == "Id") continue;

                if(property == last)
                    baseCommand += property.Name + ")";
                else 
                baseCommand += property.Name + ",";
            }

            baseCommand = $"{baseCommand} values (";

            foreach (var property in properties)
            {

                if (property.Name == "Id") continue;

                var value = GenerateSqlValue(property, element);

                if (property == last)
                    baseCommand += value  + ")";
                else
                    baseCommand += value + ",";
            }


            return baseCommand;
        }


        private string GenerateSqlValue<T>(PropertyInfo property, T element ) where T : new()
        {
            var value = property.GetValue(element, null);


            if (property.PropertyType == typeof(string)) {
                return !string.IsNullOrEmpty(value?.ToString()) ? $"'{value}'": "''";
            }

            return "''";
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
