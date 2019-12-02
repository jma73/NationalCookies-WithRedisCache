using System;
using BridgeUuid;
using Xunit;

namespace XUnitTestProject1.TestData
{
    public class TcMappingUuid : IClassFixture<MappingUuidFixture>
    {
        public TcMappingUuid(MappingUuidFixture fixture)
        {
            
        }


        [Fact]
        public void GetUuid_VerifyCorrectResult()
        {
            // Arrange
            
            IMappingUuid sut = new MappingUuid();       // todo: Den skal vel ikke new'es???
            // Assert.IsIn(IMappingUuid);

            // Act
            string key = "SagJournalpostRolleJournalnotat";     // SagJournalpostRolleJournalnotat  -->  1281739d-93ea-486c-8950-607a4263bef0
            Guid uuid = sut.GetUuid(key);

            // Assert
            Assert.Equal("1281739d-93ea-486c-8950-607a4263bef0", uuid.ToString());
        }
    }
}
