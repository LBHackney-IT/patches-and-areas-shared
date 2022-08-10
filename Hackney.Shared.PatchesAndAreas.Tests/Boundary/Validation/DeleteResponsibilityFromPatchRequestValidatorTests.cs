using FluentValidation.TestHelper;
using Hackney.Shared.PatchesAndAreas.Boundary.Request;
using Hackney.Shared.PatchesAndAreas.Boundary.Request.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hackney.Shared.PatchesAndAreas.Tests.Boundary.Validation
{
    public class DeleteResponsibilityFromPatchRequestValidatorTests
    {
        private readonly DeleteResponsibilityFromPatchRequestValidator _classUnderTest;

        public DeleteResponsibilityFromPatchRequestValidatorTests()
        {
            _classUnderTest = new DeleteResponsibilityFromPatchRequestValidator();
        }

        [Fact]
        public void RequestShouldErrorWithNullId()
        {
            //Arrange
            var query = new DeleteResponsibilityFromPatchRequest();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyId()
        {
            //Arrange
            var query = new DeleteResponsibilityFromPatchRequest() { Id = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithNullResponsibilityId()
        {
            //Arrange
            var query = new DeleteResponsibilityFromPatchRequest();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ResponsibileEntityId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyResponsbilityId()
        {
            //Arrange
            var query = new DeleteResponsibilityFromPatchRequest() { ResponsibileEntityId = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ResponsibileEntityId);
        }
    }
}
