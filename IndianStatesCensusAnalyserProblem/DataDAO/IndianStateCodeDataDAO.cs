using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyserProblem.DataDAO
{
    public class IndianStateCodeDataDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public IndianStateCodeDataDAO(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}
