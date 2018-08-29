using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Models;

namespace Services
{
    public class BinaryFormatterFileLoader : ILoader
    {
        [Inject(typeof(BinaryFormatterFileLoader))]
        public ISurrogatePacket SurrogatePacket { get; set; }
        [Inject] public ILogger Logger { get; set; }

        public void Load<T>(string path, Action<T> callback)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException();

                using (var stream = File.OpenRead(path))
                {
                    var binaryFormatter = new BinaryFormatter();
                    if (SurrogatePacket != null)
                    {
                        binaryFormatter.SurrogateSelector = SurrogatePacket.SurrogateSellector;
                    }

                    callback((T)binaryFormatter.Deserialize(stream));
                }
            }

            catch (InvalidCastException e)
            {
                Logger.LogError(e.Message);
                throw;
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format(@"Couldn't find file by path: ""{0}""", path));
                Logger.LogWarning(e.Message);
            }

            catch (SerializationException e)
            {
                Logger.LogError(string.Format(
                    @"Couldn't deserialize file. Reason: ""{0}""", e.Message));
                throw;
            }
        }
    }
}