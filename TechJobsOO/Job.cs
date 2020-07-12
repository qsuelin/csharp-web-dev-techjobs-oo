using System;
using System.Collections.Generic;

namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.
        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employer, Location location, PositionType positionType, CoreCompetency coreCompetency) : this()
        {
            Name = name;
            EmployerName = employer;
            EmployerLocation = location;
            JobType = positionType;
            JobCoreCompetency = coreCompetency;
        }

        // TODO: Generate Equals() and GetHashCode() methods.
        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            if (Name == null && EmployerName==null && EmployerLocation==null && JobType==null && JobCoreCompetency==null )
            {
                return "OOPS! This job does not seem to exist.";
            }
            else
            {
                string emptyMsg = "Data not available";

                return $"/nID: {Id}/nName: {(Name != null ? Name : emptyMsg)}/nEmployer: {(EmployerName.Value != null ? EmployerName.Value : emptyMsg)}/n" +
                    $"Location: {(EmployerLocation.Value != null ? EmployerLocation.Value : emptyMsg)}/nPosition Type: {(JobType.Value != null ? JobType.Value : emptyMsg)}/n" +
                    $"Core Compentency: {(JobCoreCompetency.Value != null ? JobCoreCompetency.Value : emptyMsg)}/n";

            }
        }

    }
}
