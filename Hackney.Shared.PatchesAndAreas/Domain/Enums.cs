using System.Text.Json.Serialization;

namespace Hackney.Shared.PatchesAndAreas.Domain
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PatchType
    {
        patch,
        area,
        tmoPatch
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResponsibleType
    {
        HousingOfficer,
        HousingAreaManager,
        TMO,
        TmoManager
    }
}
