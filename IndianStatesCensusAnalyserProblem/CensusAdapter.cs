// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CensusAdapter.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace IndianStatesCensusAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// General/Master census adapter to check if the requested file satisfies certain required conditions
    /// </summary>
    public class CensusAdapter
    {
        /// <summary>
        /// Loads the census data from CSV file and checks for certain constraints into the file
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        public string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            /// Checks if the file exists at the path
            if (!File.Exists(csvFilePath))
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.Exception.FILE_NOT_FOUND);
            /// Checks if the file has proper extension
            if (Path.GetExtension(csvFilePath) != ".csv")
                throw new CensusAnalyserException("Invalid file type", CensusAnalyserException.Exception.INVALID_FILE_TYPE);
            /// Load all the lines from the CSV file into the array
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                /// Throw exception if the header in the file is incorect
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.Exception.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
