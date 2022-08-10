using PatchesAndAreas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackney.Shared.PatchesAndAreas.Boundary.Request
{
    public class UpdatePatchesResponsibilitiesRequestObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ResponsibleType ResponsibleType { get; set; }
    }
}
