// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace IndianStatesCensusAnalyserProblem
{
    using IndianStatesCensusAnalyserProblem.DTO;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The main class which is used to access the csv file based on country name,csv file path,data headers
    /// </summary>
    public class CensusAnalyser
    {
        public enum Country
        {
            /// Country names for which we have to generate the analyser
            INDIA, 
            US
        }

        /// <summary>
        /// The dictionary to store the data contained in the loaded CSV file
        /// </summary>
        public Dictionary<string, CensusDTO> datamap;

        /// <summary>
        /// Loads the census data according to the file path provided
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            /// Returns the data according to the csv File path provided
            datamap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return datamap;
        }
    }
}
