using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Models;

namespace Services
{
    public class BinaryFormatterFileSaver : ISaver
    {
        [Inject(typeof(BinaryFormatterFileSaver))]
        public ISurrogatePacket SurrogatePacket { get; set; }
        [Inject] public ILogger Logger { get; set; }

        public void Save(object obj, string path)
        {
            try
            {
                if (File.Exists(path))
                    Logger.Log(string.Format(
                        @"File overriding by path: ""{0}""", path));
                else if (!File.Exists(path))
                    Logger.Log(string.Format(
                        @"New file creating and saving by path: ""{0}""", path));

                using (var stream = File.Create(path))
                {
                    var binaryFormatter = new BinaryFormatter();
                    if (SurrogatePacket != null)
                    {
                        binaryFormatter.SurrogateSelector = SurrogatePacket.SurrogateSellector;
                    }

                    binaryFormatter.Serialize(stream, obj);
                }
            }

            catch (SerializationException e)
            {
                Logger.LogError(string.Format(
                    @"Couldn't serialize file. Reason: ""{0}""", e.Message));
                throw;
            }
        }
    }
}