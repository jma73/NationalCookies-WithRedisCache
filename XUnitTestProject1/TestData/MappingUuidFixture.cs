using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BridgeUuid.TestData;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTestProject1.TestData
{
    public class MappingUuidFixture
    {
        // how ?
        // https://stackoverflow.com/questions/50921675/dependency-injection-in-xunit-project/50922017#50922017 
        // https://stackify.com/net-core-dependency-injection/
        // can I set up the container here? bootstrap?? 


        //public static IServiceProvider ProviderContainer;   // lav til get set??
        public IServiceProvider ServiceProvider { get; set; }

        public MappingUuidFixture()
        {
            ServiceCollection serviceCollection = new ServiceCollection();      // list of dependencies

            serviceCollection.AddSingleton<IMappingListUuidTestData, MappingListUuidTestData>();

            // https://www.youtube.com/watch?v=e89oghX7JXg 
            // https://youtu.be/e89oghX7JXg?t=1591 - samme video - men i minut 26:30
            // Framework.Construct<>() ?? --> Dna.Framework... 

            // Microsoft.Extensions.DependencyInjection
            // Container = serviceCollection.BuildServiceProvider();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }


    }
}
