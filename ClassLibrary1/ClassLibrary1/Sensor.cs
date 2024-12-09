using System;
using System.Collections.Generic;

namespace ClassLibrary1;

public partial class Sensor
{
    public int SensorId { get; set; }

    public string SensorType { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateOnly? InstallationDate { get; set; }

    public DateOnly? CalibrationDate { get; set; }

    public string Status { get; set; } = null!;

    public int? StandardId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

    public virtual ICollection<PollutionDatum> PollutionData { get; set; } = new List<PollutionDatum>();

    public virtual Standard? Standard { get; set; }

    public virtual User? User { get; set; }
}
