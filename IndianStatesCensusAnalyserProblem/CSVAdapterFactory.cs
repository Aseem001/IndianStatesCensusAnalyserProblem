﻿using IndianStatesCensusAnalyserProblem.DTO;
using System.Collections.Generic;

namespace IndianStatesCensusAnalyserProblem
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);                
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.Exception.NO_SUCH_COUNTRY);

            }
        }
    }
}