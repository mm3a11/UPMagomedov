using System;
using System.Collections.Generic;

namespace APIMag.Models;

public partial class Measurement
{
    public int MeasurementId { get; set; }

    public int? SensorId { get; set; }

    public string Parameter { get; set; } = null!;

    public double Value { get; set; }

    public string? UnitOfMeasurement { get; set; }

    public DateOnly? MeasurementDateTime { get; set; }

    public int? ReportId { get; set; }

    public virtual Report? Report { get; set; }

    public virtual Sensor? Sensor { get; set; }
}
