using FluentValidation.TestHelper;
using PatchesAndAreas.Boundary.Request.Validation;
using PatchesAndAreas.Domain;
using PatchesAndAreas.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hackney.Shared.PatchesAndAreas.Tests.Boundary.Validation
{
    public class ResponsibleEntitiesValidatorTests
    {
        private readonly ResponsibleEntitiesValidator _classUnderTest;

        public ResponsibleEntitiesValidatorTests()
        {
            _classUnderTest = new ResponsibleEntitiesValidator();
        }

        private const string StringWithTags = "Some string with <tag> in it.";

        [Fact]
        public void RequestShouldErrorWithTagsInName()
        {
            //Arrange
            var model = new ResponsibleEntities() { Name = StringWithTags };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                  .WithErrorCode(ErrorCodes.XssCheckFailure);
        }

        [Fact]
        public void RequestShouldNotErrorWithValidName()
        {
            //Arrange
            string name = "name12345";
            var model = new ResponsibleEntities() { Name = name };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }
    }
}
