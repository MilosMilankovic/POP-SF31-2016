using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_31.Util
{
    public class GenericSerializer
    {
        public static void Serialize<T>(string filename, ObservableCollection<T> objToSerialize) where T : class
        {
            try
            {

                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));



                using (var sw = new StreamWriter($@"../../Data/{ filename }"))
                {
                    serializer.Serialize(sw, objToSerialize);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static ObservableCollection<T> Deserialize<T>(string filename) where T : class
        {
            try
            {

                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));

                using (var sw = new StreamReader($@"../../Data/{ filename }"))
                {
                    return (ObservableCollection<T>)serializer.Deserialize(sw);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void SerializeObject<T>(string fileName, object objectToSerialize) where T : class // samo 1 objekat, 
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (var sw = new StreamWriter($@"../../Data/{fileName}"))
                {
                    serializer.Serialize(sw, objectToSerialize);
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Greska pri ispisu serijalizovanih podataka u {fileName}");
                throw;
            }
        }

        public static T DeSerializeObject<T>(string fileName) where T : class
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (var sr = new StreamReader($@"../../Data/{fileName}"))
                {
                    return (T)serializer.Deserialize(sr);
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Greska pri ucitavanju serijalizovanih podataka iz {fileName}");
                throw;
            }
        }
    }



    }

