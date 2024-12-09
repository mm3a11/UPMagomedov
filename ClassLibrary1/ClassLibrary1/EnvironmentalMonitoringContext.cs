using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1;

public partial class EnvironmentalMonitoringContext : DbContext
{
    public EnvironmentalMonitoringContext()
    {
    }

    public EnvironmentalMonitoringContext(DbContextOptions<EnvironmentalMonitoringContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Measurement> Measurements { get; set; }

    public virtual DbSet<PollutionDatum> PollutionData { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Sensor> Sensors { get; set; }

    public virtual DbSet<Standard> Standards { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=44-11;Database=EnvironmentalMonitoring;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA47764D4DF76");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.HasKey(e => e.MeasurementId).HasName("PK__Measurem__85599F98882BEC52");

            entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");
            entity.Property(e => e.Parameter)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.SensorId).HasColumnName("SensorID");
            entity.Property(e => e.UnitOfMeasurement)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Report).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("FK_Measurements_Reports");

            entity.HasOne(d => d.Sensor).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.SensorId)
                .HasConstraintName("FK__Measureme__Senso__3C69FB99");
        });

        modelBuilder.Entity<PollutionDatum>(entity =>
        {
            entity.HasKey(e => e.PollutionId).HasName("PK__Pollutio__A17A052D22BE214F");

            entity.Property(e => e.PollutionId).HasColumnName("PollutionID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PollutantType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SensorId).HasColumnName("SensorID");

            entity.HasOne(d => d.Location).WithMany(p => p.PollutionData)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Pollution__Locat__440B1D61");

            entity.HasOne(d => d.Sensor).WithMany(p => p.PollutionData)
                .HasForeignKey(d => d.SensorId)
                .HasConstraintName("FK__Pollution__Senso__4316F928");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__D5BD48E55B6A06D1");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.Parameter)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReportingPeriod)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.HasKey(e => e.SensorId).HasName("PK__Sensors__D809841AD976DE14");

            entity.Property(e => e.SensorId).HasColumnName("SensorID");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SensorType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StandardId).HasColumnName("StandardID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Standard).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.StandardId)
                .HasConstraintName("FK__Sensors__Standar__398D8EEE");

            entity.HasOne(d => d.User).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Sensors_Users");
        });

        modelBuilder.Entity<Standard>(entity =>
        {
            entity.HasKey(e => e.StandardId).HasName("PK__Standard__BB33D3EC824E23C2");

            entity.Property(e => e.StandardId).HasColumnName("StandardID");
            entity.Property(e => e.Parameter)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnitOfMeasurement)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
