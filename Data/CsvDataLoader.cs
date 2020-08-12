using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using OSDUR2WellsConnector.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OSDUR2WellsConnector.Data
{
    public static class CsvDataLoader
    {
        public static List<Well> LoadPartsFromCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<WellMap>();
                return new List<Well>(csv.GetRecords<Well>());
            }
        }
    }


    public class WellMap : ClassMap<Well>
    {
        public WellMap()
        {
            Map(m => m.UWI);
            Map(m => m.CountryID);
            Map(m => m.DataSourceOrganisationID);
            Map(m => m.DefaultVerticalMeasurementID);
            Map(m => m.FacilityEvent);
            Map(m => m.FacilityName);
            Map(m => m.Lat);
            Map(m => m.Lon);
            Map(m => m.OperatingEnvironmentID);
            Map(m => m.QuadrantID);
            Map(m => m.ResourceID);
            Map(m => m.ResourceSecurityClassification);
            Map(m => m.ResourceTypeID);
            Map(m => m.SpudDate);
            Map(m => m.StateProvinceID);
            Map(m => m.WellName);
        }
    }
}