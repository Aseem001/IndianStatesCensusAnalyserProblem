// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndiaStateCensusDataDAO.cs" company="Bridgelabz">
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
    /// UC 2 : Ability to load indian state code information from a given CSV file
    /// </summary>
    public class IndiaStateCensusDataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;

        public IndiaStateCensusDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}
