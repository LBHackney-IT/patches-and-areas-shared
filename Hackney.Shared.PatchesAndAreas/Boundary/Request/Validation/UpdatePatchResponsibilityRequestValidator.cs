using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.PatchesAndAreas.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackney.Shared.PatchesAndAreas.Boundary.Request.Validation
{
    public class UpdatePatchResponsibilityRequestValidator : AbstractValidator<UpdatePatchesResponsibilitiesRequestObject>
    {
        public UpdatePatchResponsibilityRequestValidator()
        {
            RuleFor(x => x.Name).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
