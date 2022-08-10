using AutoFixture;
using Hackney.Shared.PatchesAndAreas.Domain;
using Hackney.Shared.PatchesAndAreas.Factories;
using Hackney.Shared.PatchesAndAreas.Infrastructure;
using FluentAssertions;
using Xunit;

namespace Hackney.Shared.PatchesAndAreas.Tests.Factories
{
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void CanMapADatabaseEntityToADomainObject()
        {
            //Arrange
            var databaseEntity = _fixture.Create<PatchesDb>();
            //Act
            var entity = databaseEntity.ToDomain();
            //Assert
            databaseEntity.Id.Should().Be(entity.Id);
            databaseEntity.Name.Should().Be(entity.Name);
            databaseEntity.ParentId.Should().Be(entity.ParentId);
            databaseEntity.PatchType.Should().Be(entity.PatchType);
            databaseEntity.ResponsibleEntities.Should().BeEquivalentTo(entity.ResponsibleEntities);
        }


        [Fact]
        public void CanMapADomainEntityToADatabaseObject()
        {
            //Arrange
            var entity = _fixture.Create<PatchEntity>();
            //Act
            var databaseEntity = entity.ToDatabase();
            //Assert
            entity.Id.Should().Be(databaseEntity.Id);
            entity.Name.Should().Be(databaseEntity.Name);
            entity.ParentId.Should().Be(databaseEntity.ParentId);
            entity.PatchType.Should().Be(databaseEntity.PatchType);
            entity.ResponsibleEntities.Should().BeEquivalentTo(databaseEntity.ResponsibleEntities);
        }
    }
}
