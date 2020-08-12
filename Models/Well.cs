// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
using Microsoft.Graph;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OSDUR2WellsConnector.Models
{
    public class Well
    {
        [Key]
        public string UWI { get; set; }
        public string CountryID { get; set; }
        public string DataSourceOrganisationID { get; set; }
        public string DefaultVerticalMeasurementID { get; set; }
        public string FacilityName { get; set; }
        public string OperatingEnvironmentID { get; set; }
        public string QuadrantID { get; set; }
        public string StateProvinceID { get; set; }
        public string FacilityEvent { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string ResourceID { get; set; }
        public string ResourceSecurityClassification { get; set; }
        public string ResourceTypeID { get; set; }
        public string SpudDate { get; set; }
        public string WellName { get; set; }


        public Properties AsExternalItemProperties()
        {
            var properties = new Properties
            {
                AdditionalData = new Dictionary<string, object>
                {
                    { "UWI", UWI },
                    { "countryID", CountryID },
                    { "dataSourceOrganisationID", DataSourceOrganisationID },
                    { "defaultVerticalMeasurementID", DefaultVerticalMeasurementID },
                    { "facilityName", FacilityName },
                    { "operatingEnvironmentID", OperatingEnvironmentID },
                    { "quadrantID", QuadrantID },
                    { "FacilityEvent", FacilityEvent },
                    { "lat", Lat },
                    { "lon", Lon },
                    { "ResourceID", ResourceID },
                    { "ResourceSecurityClassification", ResourceSecurityClassification },
                    { "ResourceTypeID", ResourceTypeID },
                    { "SpudDate", SpudDate },
                    { "WellName", WellName }

                }
            };
            return properties;
        }
    }
}