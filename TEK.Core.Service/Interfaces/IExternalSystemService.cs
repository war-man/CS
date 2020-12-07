// ***********************************************************************
// Assembly         : CS.Abstractions
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IExternalSystemService.cs" company="CS.Abstractions">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using CS.VM.External.Requests;
using CS.VM.PaymentModels.Requests;
using System.Threading.Tasks;

namespace TEK.Core.Service.Interfaces
{
    /// <summary>
    /// Interface IExternalSystemService
    /// </summary>
    public interface IExternalSystemService
    {
        /// <summary>
        /// Gets the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>GetClinicListResponse.</returns>
        Task<GetClinicListResponse> GetRawClinicList(GetRawClinicListRequest request);

        /// <summary>
        /// Gets the raw finally clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>GetFinallyClinicListResponse.</returns>
        Task<GetFinallyClinicListResponse> GetRawFinallyClinicList(GetRawFinallyClinicListRequest request);

        /// <summary>
        /// Gets the raw prescriptions by registered code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;GetPrescriptionResponse&gt;.</returns>
        Task<GetPrescriptionResponse> GetRawPrescriptionsByRegisteredCode(GetRawPrescriptionsByRegisteredCodeRequest request);

        /// <summary>
        /// Gets the raw finally clinic list by registered code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;GetFinallyClinicListResponse&gt;.</returns>
        Task<GetFinallyClinicListResponse> GetRawFinallyClinicListByRegisteredCode(GetRawFinallyClinicListByRegisteredCodeRequest request);

        /// <summary>
        /// Gets all waiting raw finally clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<GetAllFinallyClinicListResponse> GetAllWaitingRawFinallyClinicList(SyncPaidWaitingRequest request);

        /// <summary>
        /// Gets the raw finally clinic list by registered code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;GetFinallyClinicListResponse&gt;.</returns>
        Task<GetRawCalendarResponse> GetRawCalendar(GetRawCalendarRequest request);

        /// <summary>
        /// Posts the raw clinic registration.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PostRawClinicRegistrationResponse> PostRawClinicRegistration(PostRawClinicRegistrationRequest request);
    }
}
