using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        private SqlDataAdapter _adapter;
        private DataTable _dataSet;

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

            using (sqlCmd = new SqlCommand(strCommand, _sqlConnection))
            {
                 var result  = sqlCmd.ExecuteNonQuery();
                Close();

                return result;
            }
        }

        public int Update<T>(T element) where T : new()
        {
            Open();

            var strCommand = GenerateUpdate(element);

            using (sqlCmd = new SqlCommand(strCommand, _sqlConnection))
            {
                var result = sqlCmd.ExecuteNonQuery();
                Close();

                return result;
            }
        }

        public T Find<T>(string query) where T: new()
        {
            var tSelected = new T();
            _sqlConnection.Open();
            var strCommand = query;
            using (sqlCmd = new SqlCommand(strCommand, _sqlConnection))
            {
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        GetReader<T>(tSelected, reader);
                        _sqlConnection.Close();
                        return tSelected;
                    }
                }
            }

            _sqlConnection.Close();
            return default(T);
        }

        public int DeleteCommand(string query) 
        {
    
            _sqlConnection.Open();
            var strCommand = query;
            using (sqlCmd = new SqlCommand(strCommand, _sqlConnection))
            {
                var result = sqlCmd.ExecuteNonQuery();
                _sqlConnection.Close();
               return result;

            }
         
        }


        public DataTable GetAll(string command)
        {
            _adapter = new SqlDataAdapter();
            var sqlCmd = new SqlCommand(command, _sqlConnection);
            Open();

            _adapter.SelectCommand = sqlCmd;
            _dataSet = new DataTable();

            _adapter.Fill(_dataSet);
            Close();
            return _dataSet;


        }

        private T GetReader<T>(T element,SqlDataReader reader ) where T: new()
        {
            var typeElement = element.GetType();


            if (!reader.HasRows) return default(T);

            foreach (var property in typeElement.GetProperties())
            {

                var type = reader[property.Name].GetType();
                var value = reader[property.Name];
                if (type == typeof(byte[]))
                    value = value.ToString();
                else if (type == typeof(bool)) {
                    value = (bool)value ? (byte)1: (byte)0;
                }
                   

                property.SetValue(element, value, null);
            }

            return  default(T);
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

        private string GenerateUpdate<T>(T element) where T: new()
        {
            var type = element.GetType();
            var properties = type.GetProperties();

            var last = properties.LastOrDefault();

            var baseCommand = $"Update {type.Name} SET ";
            var Id = "";
            
            foreach (var property in properties)
            {
                var value = GenerateSqlValue(property, element);

                if (property.Name == "Id")
                {
                    Id = GenerateSqlValue(property, element);
                    continue;
                }
                if(property.Name == "HashPassword" && value == "''")
                {
                    continue;
                }
                baseCommand += property.Name+"=";

                

                if (property == last)
                    baseCommand += value + "WHERE Id="+Id;
                else
                    baseCommand += value + ",";
            }

            return baseCommand;
        }

        private string GenerateSqlValue<T>(PropertyInfo property, T element ) where T : new()
        {
            var value = property.GetValue(element, null);


            if (property.PropertyType == typeof(string))
            {
                if (property.Name== "HashPassword")
                    return !string.IsNullOrEmpty(value?.ToString()) ? $"CONVERT(VARBINARY,'{value}')" : "''";
                return !string.IsNullOrEmpty(value?.ToString()) ? $"'{value}'" : "''";
            }
                
            
            else if (property.PropertyType == typeof(int))
                return $"{int.Parse(value.ToString())}";
            else if(property.PropertyType == typeof(byte))
                return $"{byte.Parse(value.ToString())}";

            return "''";
        }




        #endregion

        #region Singleton Implementation 
        private static DbContext _instance;
        private SqlCommand sqlCmd;

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
