using System;
using System.Collections.Generic;

namespace PatchesAndAreas.Domain
{
    public class PatchEntity
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public PatchType PatchType { get; set; }
        public string Domain { get; set; }
        public IEnumerable<ResponsibleEntities> ResponsibleEntities { get; set; }
        public int? VersionNumber { get; set; }

    }
}
