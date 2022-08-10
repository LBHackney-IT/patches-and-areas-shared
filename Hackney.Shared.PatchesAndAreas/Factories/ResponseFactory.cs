using System.Collections.Generic;
using System.Linq;
using PatchesAndAreas.Boundary.Response;
using PatchesAndAreas.Domain;
using PatchesAndAreas.Infrastructure;

namespace PatchesAndAreas.Factories
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
                ResponsibleEntities = domain.ResponsibleEntities.ToListOrEmpty()
            };
        }

        public static List<PatchesResponseObject> ToResponse(this IEnumerable<PatchEntity> domainList)
        {
            if (null == domainList) return new List<PatchesResponseObject>();

            return domainList.Select(domain => domain.ToResponse()).ToList();
        }
    }
}
