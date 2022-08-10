using FluentValidation.TestHelper;
using PatchesAndAreas.Boundary.Request;
using PatchesAndAreas.Boundary.Request.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hackney.Shared.PatchesAndAreas.Tests.Boundary.Validation
{
    public class GetByIdRequestValidatorTests
    {
        private readonly GetByIdRequestValidator _classUnderTest;

        public GetByIdRequestValidatorTests()
        {
            _classUnderTest = new GetByIdRequestValidator();
        }

        [Fact]
        public void RequestShouldErrorWithNullId()
        {
            //Arrange
            var query = new PatchesQueryObject();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyId()
        {
            //Arrange
            var query = new PatchesQueryObject() { Id = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
