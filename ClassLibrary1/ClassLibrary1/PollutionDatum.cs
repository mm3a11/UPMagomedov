using System;
using System.Collections.Generic;

namespace ClassLibrary1;

public partial class PollutionDatum
{
    public int PollutionId { get; set; }

    public int? SensorId { get; set; }

    public string PollutantType { get; set; } = null!;

    public double Value { get; set; }

    public DateOnly? MeasurementDateTime { get; set; }

    public int? LocationId { get; set; }

    public virtual Location? Location { get; set; }

    public virtual Sensor? Sensor { get; set; }
}
