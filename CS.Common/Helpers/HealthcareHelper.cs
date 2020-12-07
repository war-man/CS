// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="HealthcareHelper.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using CS.Common.Common;
using static CS.Common.Common.Constants;

namespace CS.Common.Helpers
{
    /// <summary>
    /// Class HealthcareHelper.
    /// </summary>
    public static class HealthcareHelper
    {
        /// <summary>
        /// The codecc
        /// </summary>
        public const string CODECC = "CC";
        /// <summary>
        /// The codeck
        /// </summary>
        public const string CODECK = "CK";
        /// <summary>
        /// The codekc
        /// </summary>
        public const string CODEKC = "KC";
        /// <summary>
        /// The cod e06
        /// </summary>
        public const string CODE06 = "06";
        /// <summary>
        /// The cod e80
        /// </summary>
        public const string CODE80 = "80";
        /// <summary>
        /// The codekt
        /// </summary>
        public const string CODEKT = "KT";
        /// <summary>
        /// The codebn
        /// </summary>
        public const string CODEBN = "BN";
        /// <summary>
        /// The codegt
        /// </summary>
        public const string CODEGT = "GT";
        /// <summary>
        /// The codect
        /// </summary>
        public const string CODECT = "CT";
        /// <summary>
        /// The minage
        /// </summary>
        public const int MINAGE = 6;
        /// <summary>
        /// The maxage
        /// </summary>
        public const int MAXAGE = 80;


        /// <summary>
        /// The external cod e01
        /// </summary>
        public const string EXTERNAL_CODE01 = "01";
        /// <summary>
        /// The external cod e02
        /// </summary>
        public const string EXTERNAL_CODE02 = "02";
        /// <summary>
        /// The external cod e03
        /// </summary>
        public const string EXTERNAL_CODE03 = "03";
        /// <summary>
        /// The external cod e04
        /// </summary>
        public const string EXTERNAL_CODE04 = "04";
        /// <summary>
        /// The external cod e05
        /// </summary>
        public const string EXTERNAL_CODE05 = "05";

        /// <summary>
        /// The external cod e06
        /// </summary>
        public const string EXTERNAL_CODE06 = "06";

        /// <summary>
        /// Gets the type of the patient.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="birthday">The birthday.</param>
        /// <returns>PatientType.</returns>
        public static PatientType GetPatientType(string cardNumber, DateTime? birthday)
        {
            var result = PatientType.Normal;
            if (!string.IsNullOrEmpty(cardNumber))
            {
                var code = cardNumber.Substring(0, 2);

                switch (code)
                {
                    case HealthcarePriorityCode.CC:
                    case HealthcarePriorityCode.CK:
                    case HealthcarePriorityCode.KC:
                        result = PatientType.PriorityCode;
                        break;
                }
            }

            if (birthday.HasValue && (DateTime.Now.Year - birthday.Value.Year) <= MINAGE)
            {
                result = PatientType.Priority6;
            }

            if (birthday.HasValue && (DateTime.Now.Year - birthday.Value.Year) >= MAXAGE)
            {
                result = PatientType.Priority80;
            }

            return result;
        }

        /// <summary>
        /// Gets the patient type with code.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="birthday">The birthday.</param>
        /// <param name="type">The type.</param>
        /// <returns>PatientType.</returns>
        public static PatientType GetPatientTypeWithCode(string cardNumber, DateTime? birthday, string type = "")
        {
            PatientType patientType;
            switch (type)
            {
                case CODECC:
                case CODECK:
                case CODEKC:
                    patientType = PatientType.PriorityCode;
                    break;
                case CODE06:
                    patientType = PatientType.Priority6;
                    break;
                case CODE80:
                    patientType = PatientType.Priority80;
                    break;
                case CODEKT:
                    patientType = PatientType.PriorityKT;
                    break;
                case CODEBN:
                    patientType = PatientType.PriorityBN;
                    break;
                case CODEGT:
                    patientType = PatientType.PriorityGT;
                    break;
                case CODECT:
                    patientType = PatientType.PriorityCT;
                    break;
                default:
                    patientType = GetPatientType(cardNumber, birthday);
                    break;
            }

            return patientType;
        }

        /// <summary>
        /// Gets the patient type with external code.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="birthday">The birthday.</param>
        /// <param name="type">The type.</param>
        /// <returns>PatientType.</returns>
        public static PatientType GetPatientTypeWithExternalCode(string cardNumber, DateTime? birthday, string type = "")
        {
            PatientType patientType;
            switch (type)
            {
                case EXTERNAL_CODE01:
                    patientType = PatientType.Priority6;
                    break;
                case EXTERNAL_CODE02:
                    patientType = PatientType.Priority80;
                    break;
                case EXTERNAL_CODE03:
                    patientType = PatientType.PriorityCT;
                    break;
                case EXTERNAL_CODE04:
                    patientType = PatientType.PriorityKT;
                    break;
                case EXTERNAL_CODE05:
                    patientType = PatientType.PriorityCode;
                    break;
                case EXTERNAL_CODE06:
                    patientType = PatientType.PriorityCode;
                    break;
                default:
                    patientType = GetPatientType(cardNumber, birthday);
                    break;
            }

            return patientType;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="patientType">Type of the patient.</param>
        /// <returns></returns>
        public static string GetName(PatientType patientType)
        {
            string name = PatientTypeConstants.Normal;
            switch (patientType)
            {
                case PatientType.Priority6:
                    name = PatientTypeConstants.Priority6;
                    break;
                case PatientType.Priority80:
                    name = PatientTypeConstants.Priority80;
                    break;
                case PatientType.PriorityCode:
                    name = PatientTypeConstants.PriorityCode;
                    break;
                case PatientType.PriorityKT:
                    name = PatientTypeConstants.PriorityKT;
                    break;
                case PatientType.PriorityBN:
                    name = PatientTypeConstants.PriorityBN;
                    break;
                case PatientType.PriorityGT:
                    name = PatientTypeConstants.PriorityGT;
                    break;
                case PatientType.PriorityCT:
                    name = PatientTypeConstants.PriorityCT;
                    break;
            }

            return name.ToUpper();
        }
    }
}
