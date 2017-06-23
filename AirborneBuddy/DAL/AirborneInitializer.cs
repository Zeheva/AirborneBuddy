using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AirborneBuddy.Models;
using CsvHelper;

namespace AirborneBuddy.DAL
{
    public class AirborneInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AirborneBuddyContext>
    {
        protected override void Seed(AirborneBuddyContext context)
        {
            var airborneOperation = new List<AirborneOperation>
            {
                new AirborneOperation
                {
                    DropZone = "Luzon",
                    AircraftPlatform = "C17",
                    DateTime = DateTime.Parse("2017-09-12"),
                    PayPeriodCovered = "JAN, FEB, MAR",
                    JumpType = JumpType.AdministrativeNonTatical
                }
            };
            airborneOperation.ForEach(a => context.AirborneOperations.Add(a));
            context.SaveChanges();
        }
    }
}