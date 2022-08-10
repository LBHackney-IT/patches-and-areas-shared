using FluentValidation.TestHelper;
using PatchesAndAreas.Boundary.Request;
using PatchesAndAreas.Boundary.Request.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PatchesAndAreas.Tests.Boundary.Validation
{
    public class UpdatePatchQueryValidatorTests
    {
        private readonly UpdatePatchQueryValidator _classUnderTest;

        public UpdatePatchQueryValidatorTests()
        {
            _classUnderTest = new UpdatePatchQueryValidator();
        }

        [Fact]
        public void RequestShouldErrorWithNullId()
        {
            //Arrange
            var query = new UpdatePatchesResponsibilityRequest();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyId()
        {
            //Arrange
            var query = new UpdatePatchesResponsibilityRequest() { Id = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithNullResponsibilityId()
        {
            //Arrange
            var query = new UpdatePatchesResponsibilityRequest();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ResponsibileEntityId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyResponsbilityId()
        {
            //Arrange
            var query = new UpdatePatchesResponsibilityRequest() { ResponsibileEntityId = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ResponsibileEntityId);
        }
    }
}
