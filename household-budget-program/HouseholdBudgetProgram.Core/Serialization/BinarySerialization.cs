using HouseholdBudgetProgram.Core.Serialization.Base;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HouseholdBudgetProgram.Core.Serialization
{
    public class BinarySerialization : ISerialization
    {
        private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

        public bool Serialize(string fileName, object obj)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                binaryFormatter.Serialize(fileStream, obj);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                fileStream?.Close();
            }
        }

        public object Deserialize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                return binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
