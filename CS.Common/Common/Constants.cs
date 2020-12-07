// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Constants.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using static CS.Common.Common.Constants;

namespace CS.Common.Common
{
    /// <summary>
    /// Class Constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Class EnvironmentVariables.
        /// </summary>
        public static class EnvironmentVariables
        {
            /// <summary>
            /// The aspnet core environment
            /// </summary>
            public const string AspnetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        }

        /// <summary>
        /// Class Environments.
        /// </summary>
        public static class Environments
        {
            /// <summary>
            /// The production
            /// </summary>
            public const string Production = "Production";
        }

        /// <summary>
        /// Class Systems.
        /// </summary>
        public static class Systems
        {
            /// <summary>
            /// The created by
            /// </summary>
            public const string CreatedBy = "system";
            /// <summary>
            /// The updated by
            /// </summary>
            public const string UpdatedBy = "system";
        }

        /// <summary>
        /// Class Departments.
        /// </summary>
        public static class Departments
        {
            /// <summary>
            /// The TNB
            /// </summary>
            public const string TNB = "TNB";
            /// <summary>
            /// The thuocbhyt
            /// </summary>
            public const string THUOCBHYT = "THUOCBHYT";
            /// <summary>
            /// The tattoan
            /// </summary>
            public const string TATTOAN = "TATTOAN";
            /// <summary>
            /// The KXN
            /// </summary>
            public const string KXN = "KXN";
            /// <summary>
            /// The CLSX N12
            /// </summary>
            public const string CLSXN12 = "CLS.XN12";
            /// <summary>
            /// The pay off store
            /// </summary>
            public const string PayOffStore = "Q03";

            /// <summary>
            /// The khammat
            /// </summary>
            public const string KHAMMAT = "KHAMMAT";
        }

        /// <summary>
        /// Class HealthcarePriorityCode.
        /// </summary>
        public static class HealthcarePriorityCode
        {
            /// <summary>
            /// The cc
            /// </summary>
            public const string CC = "CC";
            /// <summary>
            /// The ck
            /// </summary>
            public const string CK = "CK";
            /// <summary>
            /// The kc
            /// </summary>
            public const string KC = "KC";
        }

        /// <summary>
        /// The format date time
        /// </summary>
        public const string FormatDateTime = "yyyyMMdd";

        /// <summary>
        /// The format date time Viet nam
        /// </summary>
        public const string FormatDateTimeVN = "dd/MM/yyyy";

        /// <summary>
        /// The male identifier
        /// </summary>
        public const string MaleId = "1";
        /// <summary>
        /// The female identifier
        /// </summary>
        public const string FemaleId = "1";
        /// <summary>
        /// The enum value format
        /// </summary>
        public const string EnumValueFormat = "D";

        /// <summary>
        /// The default active
        /// </summary>
        public const bool DefaultIsActive = true;

        /// <summary>
        /// The default i deleted
        /// </summary>
        public const bool DefaultIsDeleted = false;

        /// <summary>
        /// The default active
        /// </summary>
        public const bool DefaultIsDraft = false;

        /// <summary>
        /// 
        /// </summary>
        public static class CardType
        {
            /// <summary>
            /// The local
            /// </summary>
            public const string Local = "local";

            /// <summary>
            /// The bank
            /// </summary>
            public const string VCB = "vcb";
        }

        /// <summary>
        /// Class ExternalClinicStatus.
        /// </summary>
        public static class HISErrorCode
        {
            /// <summary>
            /// The success
            /// </summary>
            public const string Success = "1";

            /// <summary>
            /// The success
            /// </summary>
            public const int NotFoundFinallyInformationData = 14;

            /// <summary>
            /// The is finished
            /// </summary>
            public const string IsFinished = "1";

            /// <summary>
            /// The not found data
            /// </summary>
            public const int NotExistedData = 20;
        }

        public static class GenderConstants
        {
            /// <summary>
            /// The female
            /// </summary>
            public const string Female = "Nữ";
            /// <summary>
            /// The male
            /// </summary>
            public const string Male = "Nam";
        }

        /// <summary>
        /// Class ExternalResponseStatus.
        /// </summary>
        public static class ExternalResponseStatus
        {
            /// <summary>
            /// The success
            /// </summary>
            public const string Success = "1";

            /// <summary>
            /// The not found data
            /// </summary>
            public const string NotFoundData = "22";
        }

        /// <summary>
        /// Class ManipulationContent.
        /// </summary>
        public static class ManipulationContent
        {
            /// <summary>
            /// The register
            /// </summary>
            public const string Register = "Ghi thẻ";
            /// <summary>
            /// The recharged
            /// </summary>
            public const string Recharged = "Nạp tiền";
            /// <summary>
            /// The return
            /// </summary>
            public const string Return = "Trả thẻ";
            /// <summary>
            /// The lost
            /// </summary>
            public const string Lost = "Mất thẻ không phát mới";
            /// <summary>
            /// The lost renew
            /// </summary>
            public const string LostRenew = "Mất thẻ phát mới";
            /// <summary>
            /// The charge
            /// </summary>
            public const string Charge = "Thanh toán tiền tạm ứng";
            /// <summary>
            /// The refund
            /// </summary>
            public const string Refund = "Hoàn tiền";
            /// <summary>
            /// The charge list
            /// </summary>
            public const string ChargeList = "Thanh toán tiền dịch vụ";
            /// <summary>
            /// The finally charge
            /// </summary>
            public const string FinallyCharge = "Tất toán";
            /// <summary>
            /// The card fee
            /// </summary>
            public const string CardFee = "Phí phát thẻ mới";
            /// <summary>
            /// The cancel
            /// </summary>
            public const string Cancel = "Hủy nạp tiền";
            /// <summary>
            /// The withdraw
            /// </summary>
            public const string Withdraw = "Rút tiền";
        }

        /// <summary>
        /// Class StatusContent.
        /// </summary>
        public static class StatusContent
        {
            /// <summary>
            /// The success
            /// </summary>
            public const string Success = "Thành công";
            /// <summary>
            /// The fail
            /// </summary>
            public const string Fail = "Thất bại";
            /// <summary>
            /// The waiting
            /// </summary>
            public const string Waiting = "Đang xử lý";
            /// <summary>
            /// The new
            /// </summary>
            public const string New = "Mới";
            /// <summary>
            /// The authorization required
            /// </summary>
            public const string AuthorizationRequired = "AuthorizationRequired";
            /// <summary>
            /// The approved
            /// </summary>
            public const string Approved = "Approved";
        }

        /// <summary>
        /// Class TransactionStatusContent.
        /// </summary>
        public static class TransactionStatusContent
        {
            /// <summary>
            /// The doing
            /// </summary>
            public const string Doing = "Chưa tạm ứng";
            /// <summary>
            /// The hold
            /// </summary>
            public const string Hold = "Tạm ứng";
            /// <summary>
            /// The paid
            /// </summary>
            public const string Paid = "Tất toán";
            /// <summary>
            /// The cancelled
            /// </summary>
            public const string Cancelled = "Hủy";

            /// <summary>
            /// Gets or sets the paid medicine.
            /// </summary>
            /// <value>
            /// The paid medicine.
            /// </value>
            public static string PaidMedicine = "Thanh toán thuốc dịch vụ";

            /// <summary>
            /// Gets or sets the return.
            /// </summary>
            /// <value>
            /// The return.
            /// </value>
            public static string Refund = "Hoàn tiền";
        }

        /// <summary>
        /// Class EnvironmentVariables.
        /// </summary>
        public static class DateTimeFormatConstants
        {
            /// <summary>
            /// The yyyymmdd
            /// </summary>
            public const string YYYYMMDD = "yyyyMMdd";
            /// <summary>
            /// The yyyymmddthhmmssz
            /// </summary>
            public const string YYYYMMDDTHHMMSSZ = "yyyyMMddTHHmmssZ";

            /// <summary>
            /// The yyyymmddthhmmssz
            /// </summary>
            public const string CustomDefault = "yyyy-MM-ddTHH:mm:ss";

            /// <summary>
            /// The ddmmyyyy
            /// </summary>
            public const string DDMMYYYY = "dd/MM/yyyy";

            /// <summary>
            /// The yyyy
            /// </summary>
            public const string YYYY = "yyyy";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class EncryptConstants
        {
            /// <summary>
            /// The empty body sh a256
            /// </summary>
            public const string EMPTY_BODY_SHA256 = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            /// <summary>
            /// The unsigned payload
            /// </summary>
            public const string UNSIGNED_PAYLOAD = "UNSIGNED-PAYLOAD";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class HeaderConstants
        {
            /// <summary>
            /// The content type
            /// </summary>
            public const string CONTENT_TYPE = "application/json";
            /// <summary>
            /// The language
            /// </summary>
            public const string LANGUAGE = "en";
            /// <summary>
            /// The request timeout
            /// </summary>
            public const string REQUEST_TIMEOUT = "900";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class NamedClientConstants
        {
            /// <summary>
            /// The VCB
            /// </summary>
            public const string VCB = "VCB";
            /// <summary>
            /// HIS
            /// </summary>
            public const string HIS = "HIS";
            /// <summary>
            /// HIS
            /// </summary>
            public const string Bank = "BANK";
            /// <summary>
            /// The internal
            /// </summary>
            public const string Internal = "INTERNAL";
            /// <summary>
            /// The SMS
            /// </summary>
            public const string Sms = "SMS";
        }

        /// <summary>
        /// Class ExternalClinicStatus.
        /// </summary>
        public static class StateConstants
        {
            /// <summary>
            /// The success
            /// </summary>
            public const string Approved = "approved";
            /// <summary>
            /// The failed
            /// </summary>
            public const string Failed = "failed";
            /// <summary>
            /// The authorization required
            /// </summary>
            public const string AuthorizationRequired = "authorization_required";
            /// <summary>
            /// The finished
            /// </summary>
            public const string Finished = "finished";
        }

        /// <summary>
        /// Class ExternalClinicStatus.
        /// </summary>
        public static class StatusServiceConstants
        {
            /// <summary>
            /// The success
            /// </summary>
            public const string Finished = "1";
            /// <summary>
            /// The failed
            /// </summary>
            public const string New = "0";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class ExaminationType
        {
            public const string IN_PATIENT = "NOI_TRU";
            public const string OUT_PATIENT = "NGOAI_TRU";
        }
    }

    public static class ValueTypeCode
    {
        public const string PositionCode = "CV";
        public const string TitleCode = "CD";
        public const string ServiceCode = "DV";
        public const string GroupServiceCode = "NDV";
        public const string DepartmentCode = "PB";
        public const string DepartmentKindCode = "LPB";
        public const string ObjectCode = "DT";
        public const string Hospital = "DSBV";
    }

    public static class ValueTypeDescription
    {
        public const string PositionDescription = "Chức vụ";
        public const string TitleDescription = "Chức danh";
        public const string ServiceDescription = "Dịch vụ";
        public const string GroupServiceDescription = "Nhóm dịch vụ";
        public const string DepartmentDescription = "Phòng ban";
        public const string DepartmentKindDescription = "Loại phòng ban";
        public const string ObjectDescription = "Đối tượng";
        public const string HospitalDescription = "Danh sách bệnh viện";
    }
    public static class DefautSetting
    {
        public const string DefautKey = "DEFAULT";
    }
}


/// <summary>
/// Icon Status
/// </summary>
public enum IconStatus
{
    /// <summary>
    /// The private
    /// </summary>
    Private,

    /// <summary>
    /// The public
    /// </summary>
    Public
}

/// <summary>
/// Gender
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Gender
{
    /// <summary>
    /// The public
    /// </summary>
    [EnumMember(Value = GenderConstants.Female)]
    Female,

    /// <summary>
    /// The Male
    /// </summary>
    [EnumMember(Value = GenderConstants.Male)]
    Male
}

/// <summary>
/// Patient Type
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PatientType
{
    /// <summary>
    /// The Normal
    /// </summary>
    [EnumMember(Value = PatientTypeConstants.Normal)]
    Normal,
    /// <summary>
    /// The priority6
    /// </summary>
    [EnumMember(Value = PatientTypeConstants.Priority6)]
    Priority6,
    /// <summary>
    /// The priority80
    /// </summary>
    [EnumMember(Value = PatientTypeConstants.Priority80)]
    Priority80,
    /// <summary>
    /// The priority code
    /// </summary>
    [EnumMember(Value = PatientTypeConstants.PriorityCode)]
    PriorityCode,
    /// <summary>
    /// The priority kt
    /// </summary>
    [EnumMember(Value = PatientTypeConstants.PriorityKT)]
    PriorityKT,
    /// <summary>
    /// The priority bn
    /// </summary>
    [EnumMember(Value = PatientTypeConstants.PriorityBN)]
    PriorityBN,
    /// <summary>
    /// The priority gt
    /// </summary>
    [EnumMember(Value = PatientTypeConstants.PriorityGT)]
    PriorityGT,
    /// <summary>
    /// The priority ct
    /// </summary>
    [EnumMember(Value = PatientTypeConstants.PriorityCT)]
    PriorityCT
}

public static class PatientTypeConstants
{
    /// <summary>
    /// The Normal
    /// </summary>
    public const string Normal = "Thường";
    /// <summary>
    /// The priority6
    /// </summary>
    public const string Priority6 = "Ưu Tiên 6";
    /// <summary>
    /// The priority80
    /// </summary>
    public const string Priority80 = "Ưu Tiên 80";
    /// <summary>
    /// The priority code
    /// </summary>
    public const string PriorityCode = "Ưu Tiên";
    /// <summary>
    /// The priority kt
    /// </summary>
    public const string PriorityKT = "Ưu Tiên KT";
    /// <summary>
    /// The priority bn
    /// </summary>
    public const string PriorityBN = "Ưu Tiên BN";
    /// <summary>
    /// The priority gt
    /// </summary>
    public const string PriorityGT = "Ưu Tiên GT";
    /// <summary>
    /// The priority ct
    /// </summary>
    public const string PriorityCT = "Ưu Tiên CT";
}

/// <summary>
/// Gender
/// </summary>
public enum PaymentStatus
{
    /// <summary>
    /// The failed
    /// </summary>
    Failed,

    /// <summary>
    /// The pending
    /// </summary>
    Pending,

    /// <summary>
    /// The success
    /// </summary>
    Success,

    /// <summary>
    /// The cancelled
    /// </summary>
    Cancelled,
}

/// <summary>
/// Gender
/// </summary>
public enum QueueNumberType
{
    /// <summary>
    /// Creates new patient.
    /// </summary>
    NotHaveFollowUpExamination = 1,

    /// <summary>
    /// The have follow up examination
    /// </summary>
    HaveFollowUpClinicNotExamination = 2,

    /// <summary>
    /// The have follow up examination not clinic
    /// </summary>
    HaveFollowUpExaminationNotClinic = 3,

    /// <summary>
    /// The have follow up examination and clinic and enough balance
    /// </summary>
    HaveFollowUpExaminationAndClinic = 4,

    /// <summary>
    /// The have follow up examination and clinic and not enough balance
    /// </summary>
    HaveFollowUpExaminationAndClinicAndNotEnoughBalance = 5
}

/// <summary>
/// Gender
/// </summary>
public enum BalanceStatus
{
    /// <summary>
    /// The public
    /// </summary>
    EnoughBalance,

    /// <summary>
    /// The Male
    /// </summary>
    NotEnoughBalance
}

/// <summary>
/// Enum PatientReceiverType
/// </summary>
public enum PatientReceiverType
{
    /// <summary>
    /// The new
    /// </summary>
    NotHaveFollowUpExamination = 1,

    /// <summary>
    /// The have follow up examination
    /// </summary>
    HaveFollowUpClinicNotExamination = 2,

    /// <summary>
    /// The have examination and clinic not card number
    /// </summary>
    HaveFollowUpExaminationNotClinic = 3,

    /// <summary>
    /// The have examination and clinic and card number
    /// </summary>
    HaveFollowUpExaminationAndClinic = 4,
}

/// <summary>
/// Transaction Status
/// </summary>
public enum TransactionStatus
{
    /// <summary>
    /// The success
    /// </summary>
    Success,

    /// <summary>
    /// The failed
    /// </summary>
    Failed,

    /// <summary>
    /// The waiting
    /// </summary>
    Waiting,

    /// <summary>
    /// The new
    /// </summary>
    New,

    /// <summary>
    /// The approved
    /// </summary>
    Approved,

    /// <summary>
    /// The authorization required
    /// </summary>
    AuthorizationRequired
}

/// <summary>
/// Transaction Status
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// The hold
    /// </summary>
    Hold,

    /// <summary>
    /// The paid
    /// </summary>
    Paid,

    /// <summary>
    /// The return
    /// </summary>
    Refund,

    /// <summary>
    /// The paid medicine
    /// </summary>
    ServiceMedicine,

    /// <summary>
    /// The cancelled
    /// </summary>
    Cancelled,

    /// <summary>
    /// The paid extra
    /// </summary>
    Extra,
}

/// <summary>
/// Clinic Status
/// </summary>
public enum ClinicStatus
{
    /// <summary>
    /// The new
    /// </summary>
    New,

    /// <summary>
    /// The hold
    /// </summary>
    Hold,

    /// <summary>
    /// The paid
    /// </summary>
    Paid,

    /// <summary>
    /// The cancelled
    /// </summary>
    Cancelled,
}

/// <summary>
/// Clinic Type
/// </summary>
public enum ClinicType
{
    /// <summary>
    /// The examination
    /// </summary>
    Examination,

    /// <summary>
    /// The clinic
    /// </summary>
    Clinic
}

/// <summary>
/// Enum TransactionReportStatus
/// </summary>
public enum TransactionReportStatus
{
    /// <summary>
    /// The doing
    /// </summary>
    Doing = 1,
    /// <summary>
    /// The paid
    /// </summary>
    Paid = 2
}

/// <summary>
/// Prescription Type
/// </summary>
public enum PrescriptionStatus
{
    /// <summary>
    /// The new
    /// </summary>
    New,

    /// <summary>
    /// The paid
    /// </summary>
    Paid,

    /// <summary>
    /// The hold
    /// </summary>
    Hold,

    /// <summary>
    /// The hold
    /// </summary>
    Cancelled
}

/// <summary>
/// Prescription Type
/// </summary>
public enum PrescriptionType
{
    /// <summary>
    /// The use with service
    /// </summary>
    UseWithService,

    /// <summary>
    /// The use by doctor
    /// </summary>
    UseByDoctor
}

/// <summary>
/// Priority Type
/// </summary>
public enum PriorityType
{
    /// <summary>
    /// The Normal
    /// </summary>
    Normal,
    /// <summary>
    /// The priority
    /// </summary>
    Priority
}

/// <summary>
/// Patient Type
/// </summary>
public enum QueueTempStatus
{
    /// <summary>
    /// The Normal
    /// </summary>
    Verified,
    /// <summary>
    /// The added
    /// </summary>
    Added
}

/// <summary>
/// 
/// </summary>
public enum ReceptionStatus
{
    /// <summary>
    /// The new
    /// </summary>
    Waiting = 8,

    /// <summary>
    /// The hold
    /// </summary>
    Failed = 9,

    /// <summary>
    /// The paid
    /// </summary>
    Success = 10
}

/// <summary>
/// 
/// </summary>
public enum ReceptionType
{
    /// <summary>
    /// The new
    /// </summary>
    New,

    /// <summary>
    /// The hold
    /// </summary>
    Hold,

    /// <summary>
    /// The paid
    /// </summary>
    Paid,

    /// <summary>
    /// The cancelled
    /// </summary>
    Cancelled
}

public enum PaidWaitingStatus
{
    /// <summary>
    /// The new
    /// </summary>
    New,

    /// <summary>
    /// The waiting
    /// </summary>
    Waiting,

    /// <summary>
    /// The finished
    /// </summary>
    Finished
}

/// <summary>
/// Clinic Status
/// </summary>
public enum BankStatus
{
    /// <summary>
    /// The new
    /// </summary>
    New,

    /// <summary>
    /// The registered
    /// </summary>
    Registered,

    /// <summary>
    /// The hold
    /// </summary>
    Approved,
}

public enum PaymentProvider
{
    /// <summary>
    /// The new
    /// </summary>
    Local,

    /// <summary>
    /// The hold
    /// </summary>
    Bank
}

/// <summary>
/// 
/// </summary>
public enum CardType
{
    /// <summary>
    /// The new
    /// </summary>
    Local,

    /// <summary>
    /// The registered
    /// </summary>
    Bank
}

/// <summary>
/// 
/// </summary>
public static class TransactionTypeConstants
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    public static string GetName(TransactionType type)
    {
        switch (type)
        {
            case TransactionType.Hold:
                return "Tạm ứng";
            case TransactionType.Paid:
                return "Tất toán";
            case TransactionType.Refund:
                return "Hoàn";
            case TransactionType.ServiceMedicine:
                return "Thanh toán thuốc dịch vụ";
            case TransactionType.Cancelled:
                return "Hủy";
            case TransactionType.Extra:
                return "Thu thêm";
        }

        return string.Empty;
    }

    /// <summary>
    /// Gets the status.
    /// </summary>
    /// <param name="status">The status.</param>
    /// <returns></returns>
    public static string GetStatus(TransactionStatus status)
    {
        switch (status)
        {
            case TransactionStatus.Success:
                return "Thành công";
            case TransactionStatus.Failed:
                return "Thất bại";
            case TransactionStatus.Waiting:
                return "Đang chờ";
            case TransactionStatus.New:
                return "Mới";
            case TransactionStatus.Approved:
                return "Đã thanh toán";
            case TransactionStatus.AuthorizationRequired:
                return "Chờ xác thực";
            default:
                break;
        }

        return string.Empty;
    }
}

/// <summary>
/// 
/// </summary>
public enum FinallyPaymentStatus
{
    /// <summary>
    /// The no action
    /// </summary>
    NoAction,

    /// <summary>
    /// The only refund
    /// </summary>
    OnlyLocalRefund,

    /// <summary>
    /// The only refund
    /// </summary>
    OnlyBankRefund,

    /// <summary>
    /// The only extra
    /// </summary>
    OnlyExtra,

    /// <summary>
    /// The local and bank refund
    /// </summary>
    LocalAndBankRefund,

    /// <summary>
    /// The extra and bank refund
    /// </summary>
    ExtraAndBankRefund,
}

/// <summary>
/// 
/// </summary>
public enum AuthorizationType
{
    /// <summary>
    /// The none
    /// </summary>
    None,

    /// <summary>
    /// The user name
    /// </summary>
    UserName,

    /// <summary>
    /// The phone
    /// </summary>
    Phone
}
public enum HistoryType
{
    Reception,
    QueueNumber,
    SyncTransaction,
    CancelTransaction
}

public enum EmailType
{
    Reception,
    QueueNumber,
    SyncTransaction,
    CancelTransaction
}
public enum TableDeviceType
{
    NORMAL,
    CPS
}

public enum DepartmentType
{
    TNB,
    ROOM,
    THUOCBHYT
}

public enum ActionCommand
{
    Normal,
    Log,
    Restart,
    RestartApp,
    On,
    Off
}



public enum BundelType
{
    APK,
    IOS,
    WINDOWS
}

public enum DeviceType
{
    KIOSK,
    ITOUCH,
    LCD
}

public enum ApplicationType
{
    HOLD,
    PAID
}