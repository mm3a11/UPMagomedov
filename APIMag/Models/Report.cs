using System;
using System.Collections.Generic;

namespace APIMag.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public string ReportingPeriod { get; set; } = null!;

    public string Parameter { get; set; } = null!;

    public double? AverageValue { get; set; }

    public double? MaximumValue { get; set; }

    public double? MinimumValue { get; set; }

    public int MeasurementCount { get; set; }

    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
}
