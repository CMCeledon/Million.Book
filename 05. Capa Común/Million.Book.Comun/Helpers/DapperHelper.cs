// ***********************************************************************
// Assembly         : Million.Book.Comun
// Author           : Carlos Mario Celedón Rodelo - cmceledon
// Created          : 28-11-2019
//
// Last Modified By : Carlos Mario Celedón Rodelo - cmceledon
// Last Modified On : 28-11-2019
// ***********************************************************************
// <copyright file="DapperHelper.cs" company="Indra Colombia">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Million.Book.Comun.Helpers
{
    /// <summary>
    /// Class DapperHelper.
    /// </summary>
    public class DapperHelper
    {
        #region Singleton

        /// <summary>
        /// Clase esta instanciada.
        /// </summary>
        /// <value>The instancia.</value>
        public static DapperHelper Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new DapperHelper());
                }
            }
        }

        #endregion Singleton

        #region Propiedades Privadas y Públicas

        /// <summary>
        /// Propiedad estatica que almacena la instancia del objecto.
        /// </summary>
        private static DapperHelper _instance;

        /// <summary>
        /// Atributo para validar el estado para instanciar el objeto
        /// </summary>
        private static readonly object Padlock = new object();

        #endregion Propiedades Privadas y Públicas

        #region Métodos Públicos

        /// <summary>
        /// Ejecutar sentencia sql
        /// </summary>
        /// <typeparam name="T">Entidad para realizar el Mapeo</typeparam>
        /// <param name="cnx">The Connection String.</param>
        /// <param name="query">Quesry SQL a ejecutar.</param>
        /// <param name="filter">Condición que se debe mapear a la sentencia sql server.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        /// <exception cref="Exception">Manejo de errores</exception>
        public async Task<IEnumerable<T>> ExecuteQuerySelect<T>(string cnx, string query, object filter = null)
        {
            using (var conn = new SqlConnection(cnx))
            {
                conn.Open();
                var result = filter == null
                    ? await conn.QueryAsync<T>(query).ConfigureAwait(false)
                    : await conn.QueryAsync<T>(query, filter).ConfigureAwait(false);
                conn.Close();
                conn.Dispose();
                return result;
            }
        }

        /// <summary>
        /// Ejecutar sentencia sql y devuelve un primer registro
        /// </summary>
        /// <typeparam name="T">Entidad para realizar el Mapeo</typeparam>
        /// <param name="cnx">The Connection String.</param>
        /// <param name="query">Quesry SQL a ejecutar.</param>
        /// <param name="filter">Condición que se debe mapear a la sentencia sql server.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        /// <exception cref="Exception">Manejo de errores</exception>
        public async Task<T> ExecuteQueryFirst<T>(string cnx, string query, object filter = null)
        {
            using (var conn = new SqlConnection(cnx))
            {
                conn.Open();
                var result = filter == null
                    ? await conn.QueryFirstAsync<T>(query).ConfigureAwait(false)
                    : await conn.QueryFirstAsync<T>(query, filter).ConfigureAwait(false);
                conn.Close();
                conn.Dispose();
                return result;
            }
        }

        /// <summary>
        /// Executes the store procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cnx">The Connection String.</param>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
        public async Task<IEnumerable<T>> ExecuteStoreProcedure<T>(string cnx, string storeProcedure, object filter = null) where T : class
        {
            using (var conn = new SqlConnection(cnx))
            {
                conn.Open();
                var result = filter == null
                    ? await conn.QueryAsync<T>(storeProcedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)
                    : await conn.QueryAsync<T>(storeProcedure, filter, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                conn.Close();
                conn.Dispose();
                return result;
            }
        }

        /// <summary>
        /// Executes the query scalar.
        /// </summary>
        /// <param name="cnx">The Connection String.</param>
        /// <param name="query">The query.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>System.Int32.</returns>
        public int ExecuteQueryScalar(string cnx, string query, object filter = null)
        {
            using (var conn = new SqlConnection(cnx))
            {
                conn.Open();
                var result = conn.ExecuteScalar<int>(query, filter);
                conn.Close();
                conn.Dispose();
                return result;
            }
        }

        /// <summary>
        /// Executes the query scalar.
        /// </summary>
        /// <param name="cnx">The Connection String.</param>
        /// <param name="query">The query.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>System.Int32.</returns>
        /// <summary>

        public async Task<int> ExecuteQueryScalarAsync(string cnx, string query, object filter = null)
        {
            using (var conn = new SqlConnection(cnx))
            {
                conn.Open();
                var result = await conn.ExecuteScalarAsync<int>(query, filter).ConfigureAwait(false);
                conn.Close();
                conn.Dispose();
                return result;
            }
        }

        /// <summary>
        /// execute the query script
        /// </summary>
        public List<T> Get<T>(string query, string cnx)
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                return db.Query<T>(query) as List<T>;
            }
        }

        /// <summary>
        /// Executes the store procedure scalar.
        /// </summary>
        /// <param name="cnx">The Connection String.</param>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>System.Int32.</returns>
        public int ExecuteStoreProcedureScalar(string cnx, string storeProcedure, object filter = null)
        {
            using (var conn = new SqlConnection(cnx))
            {
                conn.Open();
                var result = filter == null
                    ? conn.ExecuteScalar<int>(storeProcedure, commandType: CommandType.StoredProcedure)
                    : conn.ExecuteScalar<int>(storeProcedure, filter, commandType: CommandType.StoredProcedure);
                conn.Close();
                conn.Dispose();
                return result;
            }
        }



        #region CombineParameters

        private static void CombineParameters(ref dynamic param, dynamic outParam = null)
        {
            if (outParam != null)
            {
                if (param != null)
                {
                    param = new DynamicParameters(param);
                    ((DynamicParameters)param).AddDynamicParams(outParam);
                }
                else
                {
                    param = outParam;
                }
            }
        }

        #endregion
        #region Query

        public static IEnumerable<dynamic> QuerySP(string storedProcedure, dynamic param = null, dynamic outParam = null, SqlTransaction transaction = null, bool buffered = true, int? commandTimeout = null, string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (SqlConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                connection.Open();
                return connection.Query(storedProcedure, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
            }
        }

        public static IEnumerable<dynamic> QuerySQL(string sql, dynamic param = null, dynamic outParam = null, SqlTransaction transaction = null, bool buffered = true, int? commandTimeout = null, string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (SqlConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                connection.Open();
                return connection.Query(sql, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
            }
        }

        public IEnumerable<T> QuerySP<T>(string storedProcedure, dynamic param = null, dynamic outParam = null, SqlTransaction transaction = null, bool buffered = true, int? commandTimeout = null, string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (SqlConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                connection.Open();
                return connection.Query<T>(storedProcedure, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
            }
        }

        public static IEnumerable<T> QuerySQL<T>(string sql, dynamic param = null, dynamic outParam = null, SqlTransaction transaction = null, bool buffered = true, int? commandTimeout = null, string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (SqlConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                connection.Open();
                return connection.Query<T>(sql, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
            }
        }

        public static IEnumerable<object> QuerySP(Type type, string storedProcedure, dynamic param = null, dynamic outParam = null, SqlTransaction transaction = null, bool buffered = true, int? commandTimeout = null, string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (SqlConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                connection.Open();
                return connection.Query(type, storedProcedure, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
            }
        }

        public static IEnumerable<object> QuerySQL(Type type, string sql, dynamic param = null, dynamic outParam = null, SqlTransaction transaction = null, bool buffered = true, int? commandTimeout = null, string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (SqlConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                connection.Open();
                return connection.Query(type, sql, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
            }
        }

        #endregion

        #region Connection String & Timeout


        public static string GetConnectionString(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
                return CommonHelpers.Instance.MillionEntitiesConnectionString;
            else
                return connectionString;
        }

        public static int ConnectionTimeout { get; set; }

        public static int GetTimeout(int? commandTimeout = null)
        {
            if (commandTimeout.HasValue)
                return commandTimeout.Value;

            return ConnectionTimeout;
        }

        #endregion

        #endregion Métodos Públicos
    }
}