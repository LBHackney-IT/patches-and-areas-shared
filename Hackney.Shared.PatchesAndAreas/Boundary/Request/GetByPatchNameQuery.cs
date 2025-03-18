using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackney.Shared.PatchesAndAreas.Boundary.Request
{
    public class GetByPatchNameQuery
    {
        [FromQuery(Name = "patchName")]
        public string patchName { get; set; }
    }
}
