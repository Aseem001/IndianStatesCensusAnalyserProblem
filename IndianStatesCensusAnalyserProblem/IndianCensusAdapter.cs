// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndianCensusAdapter.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace IndianStatesCensusAnalyserProblem
{
    using IndianStatesCensusAnalyserProblem.DataDAO;
    using IndianStatesCensusAnalyserProblem.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// IndianCensusAdapter class targetting the data of INDIA
    /// </summary>
    /// <seealso cref="IndianStatesCensusAnalyserProblem.CensusAdapter" />
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> datamap;

        /// <summary>
        /// Loads the census data and returns dictionary containing data of CSV file requested
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyserException">File Containers Wrong Delimiter</exception>
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, CensusDTO>();
            /// Loads the data into the string by reading all lines from the CSV file
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                /// Throwing an exception if the delimeter is incorrect in the requested file
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.Exception.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    /// Add the data into the dictionary with key as population and value as a DTO object
                    datamap.Add(column[1], new CensusDTO(new IndianStateCodeDataDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    /// Add the data into the dictionary with key as state name and value as a DTO object
                    datamap.Add(column[1], new CensusDTO(new IndiaStateCensusDataDAO(column[0], column[1], column[2], column[3])));
            }
            return datamap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}