// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndianStateCodeDataDAO.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace IndianStatesCensusAnalyserProblem.DataDAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// UC 1 : Ability to load indian state census information from a given CSV file
    /// </summary>
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
