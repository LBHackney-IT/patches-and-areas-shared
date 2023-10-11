using FluentValidation.TestHelper;
using Hackney.Shared.PatchesAndAreas.Boundary.Request.Validation;
using Hackney.Shared.PatchesAndAreas.Domain;
using Hackney.Shared.PatchesAndAreas.Infrastructure.Constants;
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
            var model = new ResponsibleEntities()
            {
                Name = StringWithTags,
                ContactDetails = new ResponsibleEntityContactDetails()
            };
            
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
            var model = new ResponsibleEntities() {
                Name = name,
                ContactDetails = new ResponsibleEntityContactDetails()
            };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void RequestShouldContainAValidEmailAddress()
        {
            //Arrange
            string emailAddress = "test.test@hackney.gov.uk";
            var contactDetails = new ResponsibleEntityContactDetails()
            {
                EmailAddress = emailAddress
            };

            var respEnt = new ResponsibleEntities()
            {
                ContactDetails = contactDetails
            };

            //Act
            var result = _classUnderTest.TestValidate(respEnt);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ContactDetails.EmailAddress);
        }

        [Fact]
        public void RequestShouldFailWithInvalidEmailAddress()
        {
            //Arrange
            string emailAddress = "invalid.gov.uk";
            var contactDetails = new ResponsibleEntityContactDetails()
            {
                EmailAddress = emailAddress
            };

            var respEnt = new ResponsibleEntities()
            {
                ContactDetails = contactDetails
            };

            //Act
            var result = _classUnderTest.TestValidate(respEnt);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ContactDetails.EmailAddress);
        }
    }
}
