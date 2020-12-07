// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IQueueNumberService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.EF.Models;
using CS.VM.PaymentModels.Responses;
using TEK.Core.UoW;

namespace TEK.Payment.Domain.Interfaces
{
    /// <summary>
    /// Interface IQueueNumberService
    /// Implements the <see cref="CS.Base.IService{CS.EF.Models.QueueNumber, CS.Base.IRepository{CS.EF.Models.QueueNumber}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{CS.EF.Models.QueueNumber, CS.Base.IRepository{CS.EF.Models.QueueNumber}}" />
    /// <seealso cref="QueueNumber" />
    public interface IOrderNumberService : IService<QueueNumber, IRepository<QueueNumber>>
    {
        /// <summary>
        /// Generates the specified patient information.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <param name="departments">The departments.</param>
        /// <returns></returns>
        Task<ICollection<QueueNumber>> Generate(Patient patientInfo, IEnumerable<string> departments);

        /// <summary>
        /// Generates the normal reception type by patient.
        /// </summary>
        /// <param name="patientInfo">The patient information.</param>
        /// <returns></returns>
        Task<ClinicListRequestResponseExtend> GenerateNormalReceptionTypeByPatient(Patient patientInfo);

        /// <summary>
        /// Adds the temporary patient asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<QueueNumber> AddTempPatientAsync(QueueNumber entity);
    }
}
