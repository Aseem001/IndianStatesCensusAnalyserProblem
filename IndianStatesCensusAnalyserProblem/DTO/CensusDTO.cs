using IndianStatesCensusAnalyserProblem.DataDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyserProblem.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;        

        public CensusDTO(IndianStateCodeDataDAO indianStateCodeDataDAO)
        {
            this.serialNumber = indianStateCodeDataDAO.serialNumber;
            this.stateName = indianStateCodeDataDAO.stateName;
            this.tin = indianStateCodeDataDAO.tin;
            this.stateCode = indianStateCodeDataDAO.stateCode;
        }

        public CensusDTO(IndiaStateCensusDataDAO indiaStateCensusDataDAO)
        {
            this.state = indiaStateCensusDataDAO.state;
            this.population = indiaStateCensusDataDAO.population;
            this.area = indiaStateCensusDataDAO.area;
            this.density = indiaStateCensusDataDAO.density;
        }
    }
}
