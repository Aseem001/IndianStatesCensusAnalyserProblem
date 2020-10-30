// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSVAdapterFactory.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace IndianStatesCensusAnalyserProblem
{
    using IndianStatesCensusAnalyserProblem.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// CSV Adapter factory to load proper CSV file of a particular COUNTRY
    /// </summary>
    public class CSVAdapterFactory
    {
        /// <summary>
        /// Loads the CSV data by the help of the country adapter of the requested country
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyserException">No Such Country</exception>
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                /// When indian census data is to be loaded indianCensusAdapter is requested
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);                
                default:
                    /// If country name entered is different then those declared in censusAnalyser throw exception
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.Exception.NO_SUCH_COUNTRY);
            }
        }
    }
}