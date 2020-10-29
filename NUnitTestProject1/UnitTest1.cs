using IndianStatesCensusAnalyserProblem;
using IndianStatesCensusAnalyserProblem.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        // File paths
        public static string indianStateCensusFilePath = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCensusData.csv";
        public static string indianStateCodeFilePath = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.csv";

        // Headers String
        public static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";                

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        
        [SetUp]
        /// <summary>
        /// Setups this instance.
        /// </summary>
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC 1.1 : Given the indian state census data file when read should return census data count.
        /// </summary>
        [Test]      
        public void GivenIndianStateCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
    }
}