using IndianStatesCensusAnalyserProblem;
using IndianStatesCensusAnalyserProblem.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        // Headers String
        public static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        // TC 1.1 : File paths
        public static string indianStateCensusFilePath = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCensusData.csv";
        public static string indianStateCodeFilePath = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.csv";

        // TC 1.2 : Wrong File Paths
        public static string indianStateCensusWrongFilePath = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles1\IndiaStateCensusData.csv";
        public static string indianStateCodeWrongFilePath = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles1\IndiaStateCode.csv";

        // TC 1.3 : Incorrect File type
        public static string wrongIndianStateCensusFileType = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.txt";
        public static string wrongIndianStateCodeFileType = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.txt";

        // TC 1.4 : Incorrect Delimeter Files' path
        public static string delimeterIndianStateCensusFilePath = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndiaStateCensusData.csv";
        public static string delimeterIndianStateCodeFilePath = @"C:\Users\hp\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndiaStateCode.csv";

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

        /// <summary>
        /// TC 1.2 : Given the wrong file path for indian state census data file should throw custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCensusDataFile_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusWrongFilePath, indianStateCensusHeaders));
            var stateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeWrongFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, stateCodeResult.exception);
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, indianStateCensusResult.exception);
        }

        /// <summary>
        /// TC 1.3 : Given the wrong indian census data file type should throw custom exceotion.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_ShouldThrowCustomExceotion()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, indianStateCensusResult.exception);
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, stateCodeResult.exception);            
        }

        /// <summary>
        /// TC 1.4 : Given the state census CSV file when correct but delimeter incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCensusCSVFileWhenCorrectButDelimeterIncorrect_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, indianStateCensusResult.exception);
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, stateCodeResult.exception);
        }
    }
}