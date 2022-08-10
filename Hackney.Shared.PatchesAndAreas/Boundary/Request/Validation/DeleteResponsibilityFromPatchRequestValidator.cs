using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackney.Shared.PatchesAndAreas.Boundary.Request.Validation
{
    public class DeleteResponsibilityFromPatchRequestValidator : AbstractValidator<DeleteResponsibilityFromPatchRequest>
    {
        public DeleteResponsibilityFromPatchRequestValidator()
        {
            RuleFor(x => x.Id).NotNull()
                              .NotEqual(Guid.Empty);
            RuleFor(x => x.ResponsibileEntityId)
                              .NotNull()
                              .NotEqual(Guid.Empty);
        }
    }
}
