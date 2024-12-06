/*
 * Title: DatabaseAccess.cs
 * Name: Brady Inglis(100926284)
 * Date: 2024-12-05
 * Purpose: To provide generic static methods to aid in writing, reading, and updating data from the VideoGameReviews database
*/

#region Namespaces Used

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

#endregion

#region Namespace Definition

namespace Assignment5.DBAL
{
    static class DatabaseAccess
    {
        #region Command Execution

        /// <summary>
        /// Abstracts away database connection and non-query execution.
        /// </summary>
        /// <param name="command">The command, as a string to execute.</param>
        /// <returns>The number of effected rows.</returns>
        public static int ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                // Close connection on completion
                using (SqlConnection connection = OpenConnection())
                {
                    command.Connection = connection;
                    return command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw new Exception($"Error executing non query: {ex.Message}");
            }
        }

        /// <summary>
        /// Executes a query, returning the result as a reader. Note that connection
        /// must be specified externally such that it can be closed.
        /// </summary>
        /// <param name="query">The query to execute as an SqlCommand.</param>
        /// <param name="connection">The connection string for the specified database.</param>
        /// <returns>The results of the query.</returns>
        public static SqlDataReader ExecuteQuery(SqlConnection connection, SqlCommand query)
        {
            query.Connection = connection;
            return query.ExecuteReader();
        }

        /// <summary>
        /// Executes a query, returning the result as a reader. Note that connection
        /// must be specified externally such that it can be closed.
        /// </summary>
        /// <param name="query">The query to execute as an string.</param>
        /// <param name="connection">The connection string for the specified database.</param>
        /// <returns>The results of the query.</returns>
        public static SqlDataReader ExecuteQuery(SqlConnection connection, string query)
        {
            SqlCommand command = new SqlCommand(query);
            return ExecuteQuery(connection, command);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Uses a provided stored procedure to delete a record associated with a primary key.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure to run.</param>
        /// <param name="primaryKeyName">The primary key name.</param>
        /// <param name="primaryKeyValue">The primary key value.</param>
        /// <returns>The number of rows affected.</returns>
        public static int DeleteRecord(string storedProcedure, string primaryKeyName, int primaryKeyValue)
        {
            try
            {
                SqlCommand command = CreateStoredProcedure(storedProcedure);
                command.Parameters.AddWithValue(primaryKeyName, primaryKeyValue);
                int rowsAffected = ExecuteNonQuery(command);

                // Throw an error if no rows were affected - the record doesn't exist
                if (rowsAffected == 0) { throw new Exception("Record does not exist."); }
                return rowsAffected;
            }

            catch (Exception ex)
            {
                throw new Exception($"A problem occured with record deletion. {ex.Message}");
            }

        }

        #endregion

        #region Connection

        /// <summary>
        /// Opens the sql connection, based on a connection string stored in Properties.Resources.CONNECTION_STRING.
        /// </summary>
        /// <returns>The established connection.</returns>
        public static SqlConnection OpenConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Resources.CONNECTION_STRING);
                connection.Open();
                return connection;
            }

            catch (Exception)
            {
                throw new Exception($"Database connection could not be established at connection string {Properties.Resources.CONNECTION_STRING}");
            }

        }

        #endregion

        #region General

        /// <summary>
        /// Creates an sql command of type stored procedure.
        /// </summary>
        /// <param name="procedure">The name of the stored procedure.</param>
        /// <returns>An SqlCommand of type stored procedure. </returns>
        public static SqlCommand CreateStoredProcedure(string procedure)
        {
            return new SqlCommand(procedure) { CommandType = CommandType.StoredProcedure };
        }

        #endregion

    }
}

#endregion
