using FluentAssertions;
using PatchesAndAreas.Domain;
using PatchesAndAreas.Factories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Hackney.Shared.PatchesAndAreas.Tests.Factories
{
    public class ResponseFactoryTest
    {

        [Fact]
        public void CanMapADatabaseEntityToADomainObject()
        {
            //Arrange
            var domain = new PatchEntity();
            domain.ResponsibleEntities = new List<ResponsibleEntities>();
            //Act
            var response = domain.ToResponse();
            //Assert
            domain.Id.Should().Be(response.Id);
            domain.Name.Should().Be(response.Name);
            domain.ParentId.Should().Be(response.ParentId);
            domain.PatchType.Should().Be(response.PatchType);
            domain.ResponsibleEntities.Should().BeEquivalentTo(response.ResponsibleEntities);
        }
    }
}
