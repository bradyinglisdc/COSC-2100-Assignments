/*
 * Title: BasicFileIO.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-11-15
 * Purpose: Static class to provide basic file input and output methods
 */

#region Namespaces Used

using System.IO;
using System.Text;
using System.Windows;

#endregion


#region Namespace Definition

namespace Assignment4
{

    /// <summary>
    /// Provides various basic file input and output operations
    /// </summary>
    public static class BasicFileIO
    {

        /// <summary>
        /// Takes a directory path, and iterates through each file in the directory,
        /// appending the content of each to a byte array to be returned. Each file content is separated by a '|'
        /// </summary>
        /// <param name="filePath">The file path to read from</param>
        /// <returns>All files as a single byte array</returns>
        public static byte[] ReadDirectoryIntoByteArray(string filePath)
        {
            try
            {
                // If the dir path doesn't exist, create it
                if (!Directory.Exists(filePath)) { Directory.CreateDirectory(filePath); }

                // Concat each file to the string
                string fileContent = string.Empty;
                foreach (string file in Directory.GetFiles(filePath))
                {
                    fileContent += Encoding.UTF8.GetString(ReadFileIntoByteArray(file)) + '|';
                }

                // Return as a byte array
                return Encoding.UTF8.GetBytes(fileContent);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Takes a file path, and simply reads the file as a byte array.
        /// If an error, a new exception is thrown indicating the problem
        /// </summary>
        /// <param name="filePath">The file path to read from</param>
        /// <returns>The file as a byte array</returns>
        public static byte[] ReadFileIntoByteArray(string filePath)
        {
            try
            {
                byte[] file = File.ReadAllBytes(filePath);
                return file;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        /// <summary>
        /// Takes a file path and byte array, then writes the byte array into the file
        /// </summary>
        /// <param name="byteArray">The byte array to read from</param>
        /// <param name="filePath">The file path to write to</param>
        public static void WriteByteArrayIntoFile(string filePath, byte[] byteArray)
        {
            try
            {
                File.WriteAllBytes(filePath, byteArray);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the file if it exists
        /// </summary>
        /// <param name="filePath">The file to delete</param>
        public static void DeleteFile(string filePath)
        {
            try
            {
                
                    File.Delete(filePath);
                    
                
                
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
 
        }

    }
}

#endregion