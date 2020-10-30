// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CensusAnalyserException.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace IndianStatesCensusAnalyserProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Custom Exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CensusAnalyserException : Exception
    {
        public Exception exception;

        public enum Exception
        {
            FILE_NOT_FOUND, 
            INVALID_FILE_TYPE, 
            INCORRECT_HEADER,
            NO_SUCH_COUNTRY,
            INCORRECT_DELIMITER
        }

        public CensusAnalyserException(string message, Exception exception) : base(message)
        {
            this.exception = exception;
        }
    }
}
