namespace PhoneLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    public class SaveReadToFile
    {
        [STAThread]
        public static void Serialize(Object obj, string pathFile)
        {
            FileStream fs = new FileStream(pathFile, FileMode.Create);

            try
            {        
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                throw new FieldAccessException("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public static Object Deserialize(string pathFile)
        {
            FileStream fs = null;
            Object obj = new Object();
            obj = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                if (File.Exists(pathFile))
                {
                    fs = new FileStream(pathFile, FileMode.Open);
                    obj = formatter.Deserialize(fs);
                }
            }
            catch (SerializationException e)
            {
                throw new FieldAccessException("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return obj;
        }
    }
}