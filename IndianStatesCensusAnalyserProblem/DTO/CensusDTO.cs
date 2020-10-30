// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CensusDTO.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace IndianStatesCensusAnalyserProblem.DTO
{
    using IndianStatesCensusAnalyserProblem.DataDAO;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// CensusDTO class to access any of the two DAO classes
    /// </summary>
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

        /// <summary>
        /// UC 1 : Initializes a new instance of the <see cref="CensusDTO"/> class.
        /// </summary>
        /// <param name="indiaStateCensusDataDAO">The india state census data DAO.</param>
        public CensusDTO(IndiaStateCensusDataDAO indiaStateCensusDataDAO)
        {
            this.state = indiaStateCensusDataDAO.state;
            this.population = indiaStateCensusDataDAO.population;
            this.area = indiaStateCensusDataDAO.area;
            this.density = indiaStateCensusDataDAO.density;
        }

        /// <summary>
        /// UC 2 : Initializes a new instance of the <see cref="CensusDTO"/> class.
        /// </summary>
        /// <param name="indianStateCodeDataDAO">The indian state code data DAO.</param>
        public CensusDTO(IndianStateCodeDataDAO indianStateCodeDataDAO)
        {
            this.serialNumber = indianStateCodeDataDAO.serialNumber;
            this.stateName = indianStateCodeDataDAO.stateName;
            this.tin = indianStateCodeDataDAO.tin;
            this.stateCode = indianStateCodeDataDAO.stateCode;
        }        
    }
}
