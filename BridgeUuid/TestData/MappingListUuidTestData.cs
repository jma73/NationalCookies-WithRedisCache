using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BridgeUuid.TestData
{
    public class MappingListUuidTestData : IMappingListUuidTestData
    {
        public string[] GetMappingList(string path)
        {
            return File.ReadAllLines(path);
        }

        public IDictionary<string, Guid> GetCacheStub(string filename)
        {
            IDictionary<string, Guid> cacheDictionary = new Dictionary<string, Guid>();

            string[] lines = File.ReadAllLines(filename);
            bool firstLine = true;
            foreach (string line in lines)
            {
                // skip first line
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                if (!String.IsNullOrEmpty(line) || line != ";;;;")
                {
                    // lineStrings
                    string[] lineStrings = line.Split(";", StringSplitOptions.None);

                    string key = string.Format($"{lineStrings[0]}{lineStrings[1]}{lineStrings[2]}{lineStrings[3]}");
                    string value = lineStrings[4];

                    try
                    {

                        KeyValuePair<string, Guid> sssKeyValuePair = new KeyValuePair<string, Guid>(key, new Guid(value));
                        cacheDictionary.Add(sssKeyValuePair);

                    }
                    catch (FormatException e)   // avoid problems when not enough data. Fx. no Guid.
                    {
                        Console.WriteLine(e);
                        // throw;
                    }
                }


            }

            return cacheDictionary;
        }
    }

    /// <summary>
    /// Creates test data.
    /// </summary>
    public interface IMappingListUuidTestData
    {
        string[] GetMappingList(string path);
        
        /// <summary>
        /// Read testdata from csv file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        IDictionary<string, Guid> GetCacheStub(string filename);
    }
}
