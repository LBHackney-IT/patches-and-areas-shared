using FluentValidation.TestHelper;
using PatchesAndAreas.Boundary.Request;
using PatchesAndAreas.Boundary.Request.Validation;
using PatchesAndAreas.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PatchesAndAreas.Tests.Boundary.Validation
{
    public class UpdatePatchResponsibilityRequestValidatorTests
    {
        private readonly UpdatePatchResponsibilityRequestValidator _classUnderTest;

        public UpdatePatchResponsibilityRequestValidatorTests()
        {
            _classUnderTest = new UpdatePatchResponsibilityRequestValidator();
        }

        private const string StringWithTags = "Some string with <tag> in it.";

        [Fact]
        public void RequestShouldErrorWithTagsInName()
        {
            //Arrange
            var model = new UpdatePatchesResponsibilitiesRequestObject() { Name = StringWithTags };
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
            var model = new UpdatePatchesResponsibilitiesRequestObject() { Name = name };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }
    }
}
