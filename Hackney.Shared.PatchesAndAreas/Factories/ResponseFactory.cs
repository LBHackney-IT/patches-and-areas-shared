using System.Collections.Generic;
using System.Linq;
using Hackney.Shared.PatchesAndAreas.Boundary.Response;
using Hackney.Shared.PatchesAndAreas.Domain;
using Hackney.Shared.PatchesAndAreas.Infrastructure;

namespace Hackney.Shared.PatchesAndAreas.Factories
{
    public static class ResponseFactory
    {
        public static PatchesResponseObject ToResponse(this PatchEntity domain)
        {
            return new PatchesResponseObject
            {
                Id = domain.Id,
                ParentId = domain.ParentId,
                Name = domain.Name,
                Domain = domain.Domain,
                PatchType = domain.PatchType,
                ResponsibleEntities = domain.ResponsibleEntities.ToListOrEmpty(),
                VersionNumber = domain.VersionNumber
            };
        }

        public static List<PatchesResponseObject> ToResponse(this IEnumerable<PatchEntity> domainList)
        {
            if (null == domainList) return new List<PatchesResponseObject>();

            return domainList.Select(domain => domain.ToResponse()).ToList();
        }
    }
}
