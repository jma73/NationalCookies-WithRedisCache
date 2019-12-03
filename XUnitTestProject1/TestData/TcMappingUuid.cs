using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BridgeUuid;
using BridgeUuid.TestData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using Xunit;

namespace XUnitTestProject1.TestData
{
    public class TcMappingUuid : IClassFixture<MappingUuidFixture>
    {
        public IServiceProvider ServiceProvider { get; set; }

        public TcMappingUuid(MappingUuidFixture fixture)
        {
            
        }

        /*
         * Mark Seemann:
         *          CreateSut()...
         *          .
         *
         *
         *
         */



        [Fact]
        public void GetUuid_VerifyCorrectResult()
        {
            // Arrange
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMappingListUuidTestData, MappingListUuidTestData>();
            ServiceProvider = serviceCollection.BuildServiceProvider();


            //Container = serviceCollection.BuildServiceProvider().GetRequiredService<IMappingListUuidTestData>();
            IMappingListUuidTestData mappingListUuidTestData = serviceCollection.BuildServiceProvider().GetRequiredService<IMappingListUuidTestData>();
            
            IMappingUuid sut = new MappingUuid(mappingListUuidTestData);       // todo: Den skal vel ikke new'es??? eller det er vel mere IMappingListUuidTestData - der skal blive injected.. 
            // Assert.IsIn(IMappingUuid);

            // Act
            string key = "SagJournalpostRolleJournalnotat";     // SagJournalpostRolleJournalnotat  -->  1281739d-93ea-486c-8950-607a4263bef0
            Guid uuid = sut.GetUuid(key);

            // Assert
            Assert.Equal("1281739d-93ea-486c-8950-607a4263bef0", uuid.ToString());
        }

        [Fact]
        public void GetUuid_VerifyCorrectResult_WithoutTestFile_TryoutMock()
        {
            // Arrange
            string key = "SagJournalpostRolleJournalnotat";     // SagJournalpostRolleJournalnotat  -->  1281739d-93ea-486c-8950-607a4263bef0
            Guid value = new Guid("1281739d-93ea-486c-8950-607a4263bef0");

            var myMappingListUuidMock = new Mock<IMappingListUuidTestData>();
            KeyValuePair<string, Guid> keyValuePair = new KeyValuePair<string, Guid>(key, value);
            IDictionary<string, Guid> expected = new Dictionary<string, Guid>();// { keyValuePair};
            expected.Add(keyValuePair);
            //IDictionary<string, Guid> valueFunction = new Dictionary<string, Guid>() { new KeyValuePair<string, Guid>(key, value)};
            string filename = @"TestData\mapnigsliste-uuid-jad.csv";    // virker med filnavn... men problem at vi skal indsætte den...
            myMappingListUuidMock.Setup(s => s.GetCacheStub(filename)).Returns(expected);
            //myMappingListUuidMock.Setup(s => s.GetCacheStub(It.IsAny<string>)).Returns(expected);

            IMappingUuid sut = new MappingUuid(myMappingListUuidMock.Object);
            //Assert.IsType<MappingUuid>(sut);
            
            // Act
            Guid uuid = sut.GetUuid(key);

            // Assert
            Assert.Equal("1281739d-93ea-486c-8950-607a4263bef0", uuid.ToString());
        }
    }
}
