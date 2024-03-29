using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackney.Shared.PatchesAndAreas.Domain
{
    public class ResponsibleEntities
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ResponsibleType ResponsibleType { get; set; }
        public ResponsibleEntityContactDetails ContactDetails { get; set; }
    }
}
