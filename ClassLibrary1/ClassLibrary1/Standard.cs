using System;
using System.Collections.Generic;

namespace ClassLibrary1;

public partial class Standard
{
    public int StandardId { get; set; }

    public string Parameter { get; set; } = null!;

    public double Value { get; set; }

    public string UnitOfMeasurement { get; set; } = null!;

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
}
