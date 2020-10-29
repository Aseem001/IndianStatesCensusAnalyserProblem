using IndianStatesCensusAnalyserProblem.DataDAO;
using IndianStatesCensusAnalyserProblem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndianStatesCensusAnalyserProblem
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> datamap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.Exception.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    datamap.Add(column[1], new CensusDTO(new IndianStateCodeDataDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    datamap.Add(column[1], new CensusDTO(new IndiaStateCensusDataDAO(column[0], column[1], column[2], column[3])));
            }
            return datamap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}