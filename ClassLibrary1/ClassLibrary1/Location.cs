using System;
using System.Collections.Generic;

namespace ClassLibrary1;

public partial class Location
{
    public int LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<PollutionDatum> PollutionData { get; set; } = new List<PollutionDatum>();
}
