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
        public void EntitiesShouldBeEqualIfIdsAndNamesMatch()
        {
            var testId = Guid.NewGuid();
            var testName = "TEST_first TEST_last";
            var ResEnt1 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .With(resEnt => resEnt.Name, testName)
                .Create();
            var ResEnt2 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .With(resEnt => resEnt.Name, testName)
                .Create();

            ResEnt1.Should().BeEquivalentTo(ResEnt2);
        }

        [Fact]
        public void ResponsibleEntityListsShouldBeEqualIfIdsAndNamesMatch()
        {
            var testId = Guid.NewGuid();
            var testName = "TEST_first TEST_last";
            var ResEnt1 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .With(resEnt => resEnt.Name, testName)
                .Create();
            var ResEnt2 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .With(resEnt => resEnt.Name, testName)
                .Create();
            var ResEnts1 = new List<ResponsibleEntities> { ResEnt1 };
            var ResEnts2 = new List<ResponsibleEntities> { ResEnt2 };

            ResEnts1.FirstOrDefault().Should().BeEquivalentTo(ResEnts2.FirstOrDefault());
            ResEnts2.FirstOrDefault().Should().BeEquivalentTo(ResEnts1.FirstOrDefault());
            ResEnts1.Should().BeEquivalentTo(ResEnts2);

        }
        [Fact]
        public void ResponsibleEntityListsShouldNotBeEqualIfIdsDoNotMatch()
        {
            var testId = Guid.NewGuid();
            var testid2 = Guid.NewGuid();
            var testName = "TEST_first TEST_last";
            var ResEnt1 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .With(resEnt => resEnt.Name, testName)
                .Create();
            var ResEnt2 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testid2)
                .With(resEnt => resEnt.Name, testName)
                .Create();
            var ResEnts1 = new List<ResponsibleEntities> { ResEnt1 };

            var ResEnts2 = new List<ResponsibleEntities> { ResEnt2 };

            ResEnts1.FirstOrDefault().Should().NotBeEquivalentTo(ResEnts2.FirstOrDefault());
            ResEnts2.FirstOrDefault().Should().NotBeEquivalentTo(ResEnts1.FirstOrDefault());
            ResEnts1.Should().NotBeEquivalentTo(ResEnts2);
        }

        [Fact]
        public void ResponsibleEntityListsShouldNotBeEqualIfNamesDoNotMatch()
        {
            var testId = Guid.NewGuid();
            var testName1 = "TEST_first TEST_last";
            var testName2 = "TEST_first TEST_last2";
            var ResEnt1 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .With(resEnt => resEnt.Name, testName1)
                .Create();

            var ResEnt2 = _fixture.Build<ResponsibleEntities>()
                .With(resEnt => resEnt.Id, testId)
                .With(resEnt => resEnt.Name, testName2)
                .Create();

            var ResEnts1 = new List<ResponsibleEntities> { ResEnt1 };
            var ResEnts2 = new List<ResponsibleEntities> { ResEnt2 };

            ResEnts1.FirstOrDefault().Should().NotBeEquivalentTo(ResEnts2.FirstOrDefault());
            ResEnts2.FirstOrDefault().Should().NotBeEquivalentTo(ResEnts1.FirstOrDefault());
            ResEnts1.Should().NotBeEquivalentTo(ResEnts2);
        }
    }
}