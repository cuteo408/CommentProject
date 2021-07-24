using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace CommentProject.Logics
{
    public class CommentDA
    {
        /// <summary>
        /// Write data to a specific file 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbjson"></param>
        /// <param name="data"></param>
        public static void Write<T>(string dbjson, T data)
        {
            TextWriter writer = null;
            try
            {
                var content = JsonConvert.SerializeObject(data);
                writer = new StreamWriter(dbjson);
                writer.Write(content);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Read the data from a specific file and return a json object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbjson"></param>
        /// <returns></returns>
        public static T Read<T>(string dbjson)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(dbjson);
                var content = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(content);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}