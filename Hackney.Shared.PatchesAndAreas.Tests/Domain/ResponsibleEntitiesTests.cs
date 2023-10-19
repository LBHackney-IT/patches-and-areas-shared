using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Hackney.Shared.PatchesAndAreas.Domain;
using Xunit;

namespace Hackney.Shared.PatchesAndAreas.Tests.Domain
{
    public class ResponsibleEntitiesTests
    {
        private readonly ResponsibleEntities _classUnderTest;
        private readonly Fixture _fixture = new Fixture();

        public ResponsibleEntitiesTests()
        {
            _classUnderTest = new ResponsibleEntities();
        }

        [Fact]
        public void EntitiesShouldBeEqualIfIdsMatch()
        {
            var testId = Guid.NewGuid();
            var ResEnt1 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .Create();
            var ResEnt2 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .Create();

            ResEnt1.Should().BeEquivalentTo(ResEnt2);
        }

        [Fact]
        public void PatchResponsibleEntitiesShouldBeEqualIfIdsMatch()
        {
            var testId = Guid.NewGuid();
            var ResEnt1 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .Create();
            var ResEnt2 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .Create();
            var ResEnts1 = new List<ResponsibleEntities> { ResEnt1 };

            var ResEnts2 = new List<ResponsibleEntities> { ResEnt2 };

            ResEnts1.FirstOrDefault().Should().BeEquivalentTo(ResEnts2.FirstOrDefault());
            ResEnts2.FirstOrDefault().Should().BeEquivalentTo(ResEnts1.FirstOrDefault());
            ResEnts1.Should().BeEquivalentTo(ResEnts2);

        }
        [Fact]
        public void PatchResponsibleEntitiesShouldNotBeEqualIfIdsDoNotMatch()
        {
            var testId = Guid.NewGuid();
            var ResEnt1 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .Create();
            var ResEnt2 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, Guid.NewGuid())
                .Create();
            var ResEnts1 = new List<ResponsibleEntities> { ResEnt1 };

            var ResEnts2 = new List<ResponsibleEntities> { ResEnt2 };

            ResEnts1.FirstOrDefault().Should().NotBeEquivalentTo(ResEnts2.FirstOrDefault());
            ResEnts2.FirstOrDefault().Should().NotBeEquivalentTo(ResEnts1.FirstOrDefault());

            ResEnts1.Should().NotBeEquivalentTo(ResEnts2);

        }
    }
}