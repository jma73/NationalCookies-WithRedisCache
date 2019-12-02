using System;
using System.Collections;
using System.Collections.Generic;
using BridgeUuid;
using BridgeUuid.TestData;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitTestProject1.TestData
{
    public class SutMappingListUuidTestData
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SutMappingListUuidTestData(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1_JustGettingStarted_ReadingCSVfile()
        {
            // this is not a UnitTest! (we use a file)

            // Arrange
            ITestOutputHelper logger = new TestOutputHelper();
            bool firstLine = true;

            IMappingListUuidTestData target = new MappingListUuidTestData();

            string filename = @"C:\jad\source\Pluralsight\NationalCookies-WithCache\BridgeUuid\TestData\mapnigsliste-uuid-jad.csv";
            var result = target.GetMappingList(filename);
            
            IDictionary<string, Guid> cacheDictionary = new Dictionary<string, Guid>();
            // List<UuidCacheKey>

            
            foreach (string line in result)
            {
                _testOutputHelper.WriteLine(line);

                // skift first line
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                if (!String.IsNullOrEmpty(line) ||line != ";;;;")
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
                    catch (FormatException e)
                    {
                        Console.WriteLine(e);
                        _testOutputHelper.WriteLine("Skipping ... {line}");
                        // throw;
                    }
                }


            }
        }


        [Fact]
        public void GetCacheStub()
        {
            // this is not a UnitTest! (we use a file)

            // Arrange
            IMappingListUuidTestData target = new MappingListUuidTestData();
            //string filename = @"C:\jad\source\Pluralsight\NationalCookies-WithCache\BridgeUuid\TestData\mapnigsliste-uuid-jad.csv";
            string filename = @"TestData\mapnigsliste-uuid-jad.csv";    // it works!
            


            // Act
            IDictionary<string, Guid> result = target.GetCacheStub(filename);

            // Assert 
            foreach (KeyValuePair<string, Guid> keyValuePair in result)
            {
                _testOutputHelper.WriteLine($" {keyValuePair.Key}  -->  {keyValuePair.Value} ");
            }
            
        }

    }
}
