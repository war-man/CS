// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ErrorMessages.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace CS.Common.Common
{
    /// <summary>
    /// Class ErrorMessages.
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// The not enough balance message
        /// </summary>
        public const string NotEnoughBalanceMessage = "Số tiền không đủ";
        /// <summary>
        /// The not enough balance message
        /// </summary>
        public const string EnoughBalanceMessage = "Số tiền đủ";
        /// <summary>
        /// The not enough in patient balance message
        /// </summary>
        public const string NotEnoughInPatientBalanceMessage = "Số dư bệnh nhân là 0 đồng. Vui lòng nạp tiền trước khi thanh toán.";
        /// <summary>
        /// The have not provided card number
        /// </summary>
        public const string HaveNotProvidedCardNumber = "Bệnh nhân chưa được cấp thẻ.";
        /// <summary>
        /// The not found card number
        /// </summary>
        public const string NotFoundCardNumber = "Thẻ Tekmedi không tìm thấy.";
        /// <summary>
        /// The not found card number
        /// </summary>
        public const string NotMatchCardNumber = "Thẻ Tekmedi không khớp với bệnh nhân.";
        /// <summary>
        /// The not found patient code
        /// </summary>
        public const string NotFoundPatientCode = "Mã bệnh nhân không tồn tại.";
        /// <summary>
        /// The not found clinic
        /// </summary>
        public const string NotFoundClinic = "Bệnh nhân chưa được đăng ký khám.";
        /// <summary>
        /// The holded clinic
        /// </summary>
        public const string HoldedClinic = "Công khám này đã được tạm ứng.";
        /// <summary>
        /// The not found temporary patient code
        /// </summary>
        public const string NotFoundTempPatientCode = "Mã bệnh nhân tạm không tồn tại.";
        /// <summary>
        /// The not found card number mapping with patient
        /// </summary>
        public const string NotFoundCardNumberMappingWithPatient = "Không tìm thấy thông tin bệnh nhân tương ứng với thẻ.";
        /// <summary>
        /// The not use card number
        /// </summary>
        public const string NotUseCardNumber = "Thẻ tekmedi chưa được sử dụng.";
        /// <summary>
        /// The not hold clinic
        /// </summary>
        public const string NotHoldClinic = "CLS này chưa được tạm ứng.";
        /// <summary>
        /// The paid clinic
        /// </summary>
        public const string PaidClinic = "CLS này đã được tất toán.";
        /// <summary>
        /// The not found queue number
        /// </summary>
        public const string NotFoundQueueNumber = "Không tìm thấy số thứ tự trong phòng này.";
        /// <summary>
        /// The existed queue number
        /// </summary>
        public const string ExistedQueueNumber = "Số thứ tự này đã được thêm vào danh sách.";
        /// <summary>
        /// The finished queue number temporary
        /// </summary>
        public const string FinishedQueueNumberTemp = "Số thứ tự này đã kết thúc.";
        /// <summary>
        /// The cancel clinic success message
        /// </summary>
        public const string CancelClinicSuccessMessage = "Hủy thành công.";
        /// <summary>
        /// The not correctly table code
        /// </summary>
        public const string NotCorrectlyTableCode = "Bệnh nhân đăng ký sai quầy nhận thuốc.";
        /// <summary>
        /// The not found finally clinic
        /// </summary>
        public const string NotFoundFinallyClinic = "Không tìm thấy dữ liệu tất toán";
        /// <summary>
        /// The not found table
        /// </summary>
        public const string NotFoundTable = "Không tìm thấy quầy";
        /// <summary>
        /// The not found document
        /// </summary>
        public const string NotFoundDocument = "Không có dữ liệu để tải lên";
        /// <summary>
        /// The not found employee code
        /// </summary>
        public const string NotFoundEmployeeCode = "Mã nhân viên không tại";
        /// <summary>
        /// The cancel clinic success message
        /// </summary>
        public const string CancelledFinallyInformationData = "Không tìm thấy chi phí tất toán. Hủy các chi phí tạm ứng thành công.";
        /// <summary>
        /// The cancelled transaction
        /// </summary>
        public const string CancelledTransaction = "Hủy giao dịch.";
        /// <summary>
        /// The registered code is paid
        /// </summary>
        public const string RegisteredCodeIsPaid = "Số tiếp nhận đã được tất toán.";
        /// <summary>
        /// The not statisfy condition to cancel
        /// </summary>
        public const string NotStatisfyConditionToCancel = "Giao dịch không đủ điều kiển để hủy.";
        /// <summary>
        /// The not statisfy hold condition to cancel
        /// </summary>
        public const string NotStatisfyHoldConditionToCancel = "Tồn tại ít nhất một dịch vụ không thuộc trạng thái hold.";
        /// <summary>
        /// The not statisfy no finish condition to cancel
        /// </summary>
        public const string NotStatisfyNoFinishConditionToCancel = "Tồn tại ít nhất một dịch vụ đã thực hiện.";

        /// <summary>
        /// The nagative price
        /// </summary>
        public const string NagativePrice = "Số tiền phải là số dương";

        /// <summary>
        /// The zero price
        /// </summary>
        public const string ZeroPrice = "Số dư của bệnh nhân là không. Vui lòng nạp tiền trước khi thanh toán.";

        /// <summary>
        /// The patient registered tekmedi card
        /// </summary>
        public const string PatientRegisteredTekmediCard = "Bệnh nhân đã phát thẻ";

        /// <summary>
        /// The invalid card number
        /// </summary>
        public const string InvalidCardNumber = "Mã thẻ không hợp lệ";

        /// <summary>
        /// The registered tekmedi card
        /// </summary>
        public const string RegisteredTekmediCard = "Thẻ đã được gán cho bệnh nhân khác";

        /// <summary>
        /// The not found history
        /// </summary>
        public const string NotFoundHistory = "Không tìm thấy lịch sử";

        /// <summary>
        /// The cancelled history
        /// </summary>
        public const string CancelledHistory = "Giao dịch đã được hủy";

        /// <summary>
        /// The condition withdraw
        /// </summary>
        public const string ConditionWithdraw = "Không thể rút số tiền lớn hơn số tiền trong thẻ";
        /// <summary>
        /// The not found new patient
        /// </summary>
        public const string NotFoundNewPatient = "Đã hết số thứ tự trong phòng này.";

        /// <summary>
        /// The not found clinic list
        /// </summary>
        public const string NotFoundClinicList = "Không tìm thấy dữ liệu.";

        /// <summary>
        /// The not found paiding
        /// </summary>
        public const string NotFoundPaiding = "Không tìm thấy thông tin tất toán.";

        /// <summary>
        /// Limit sync paid waiting
        /// </summary>
        public const string LimitSyncPaidWaiting = "Không thể đồng bộ hơn {0} ngày.";

        /// <summary>
        /// The minimum balance
        /// </summary>
        public const string MinBalance = "Số tiền còn lại trong thẻ tối thiểu là {0}.";

        /// <summary>
        /// The not found transaction identifier
        /// </summary>
        public const string NotFoundTransactionId = "Không tìm thấy mã giao dịch.";

        /// <summary>
        /// The not found reception number
        /// </summary>
        public const string NotFoundReceptionNumber = "Không tìm thấy số tiếp nhận.";

        /// <summary>
        /// The not found clinic data
        /// </summary>
        public const string NotFoundClinicData = "Không tìm thấy dữ liệu công khám.";

        /// <summary>
        /// The refund clinic success message
        /// </summary>
        public const string RefundClinicSuccessMessage = "Hoàn tiền thành công.";

        /// <summary>
        /// The refund transaction success message
        /// </summary>
        public const string RefundTransactionSuccessMessage = "Hoàn giao dịch thành công.";

        /// <summary>
        /// The not found paiding waiting
        /// </summary>
        public const string NotFoundPaidingWaiting = "Không tìm thấy";

        /// <summary>
        /// The not found store code
        /// </summary>
        public const string NotFoundStoreCode = "Không tìm thấy quầy";
        /// <summary>
        /// The not found card number
        /// </summary>
        public const string InCorrectlyAccountBalance = "Vui lòng thanh toán nợ trước khi thực hiện thao tác tiếp theo.";
        /// <summary>
        /// The not found card number
        /// </summary>
        public const string ErrorTransaction = "Giao dịch bị lỗi.";

        /// <summary>
        /// The not yet register bank account
        /// </summary>
        public const string NotYetRegisterBankAccount = "Bệnh nhân chưa đăng ký thẻ ngân hàng";

        /// <summary>
        /// The not found linked bank account
        /// </summary>
        public const string NotFoundLinkedBankAccount = "Tài khoản ngân hàng chưa liên kết thẻ";

        /// <summary>
        /// The create token failed message
        /// </summary>
        public const string CreateTokenFailedMessage = "Xảy ra lỗi khi tạo token";

        /// <summary>
        /// The wrong phone or password
        /// </summary>
        public const string WrongPhoneOrPassword = "Số điện thoại hoặc mật khẩu không đúng.";
        /// <summary>
        /// The identity card number is registered bank
        /// </summary>
        public const string IdentityCardNumberIsRegisteredBank = "CMND này đã được đăng ký.";

        /// <summary>
        /// The not found registered bank account
        /// </summary>
        public const string NotFoundRegisteredBankAccount = "Tài khoản ngân hàng chưa đăng ký";

        /// <summary>
        /// The patient linked bank account
        /// </summary>
        public const string PatientLinkedBankAccount = "Tài khoản này đã được đăng ký với bệnh nhân này";

        /// <summary>
        /// The not found identity card nubmber
        /// </summary>
        public const string NotFoundIdentityCardNumber = "CMND chưa được đăng ký";

        /// <summary>
        /// The transaction is paid
        /// </summary>
        public const string TransactionIsPaid = "Giao dịch đã thanh toán";

        /// <summary>
        /// The not found device
        /// </summary>
        public const string NotFoundDevice = "Không tìm thấy device";

        /// <summary>
        /// The not found application
        /// </summary>
        public const string NotFoundApplication = "Không tìm thấy ứng dụng";

        /// <summary>
        /// The package name have exist
        /// </summary>
        public const string PackageNameHaveExist = "Tên gói đã tồn tại";

        /// <summary>
        /// The not found device configuration
        /// </summary>
        public const string NotFoundDeviceConfig = "Không tìm cài đặt";

        /// <summary>
        /// The device configuration have exist
        /// </summary>
        public const string DeviceConfigHaveExist = "Đã tồn tại cài đặt này";

        /// <summary>
        /// The application not map with version
        /// </summary>
        public const string AppNotMapWithVersion = "Ứng dụng hiện tại chưa được gắn với phiên bản.";

        /// <summary>
        /// The not linked hospital and bank
        /// </summary>
        public const string NotLinkedHospitalAndBank = "Thẻ này chưa được liên kết với mã bệnh nhân ở BV";

        /// <summary>
        /// The not active bank account
        /// </summary>
        public const string NotActiveBankAccount = "Thẻ này chưa được kích hoạt";

        /// <summary>
        /// The authorization bank
        /// </summary>
        public const string AuthorizationBank = "Đang chờ xác nhận OTP";

        /// <summary>
        /// The not authorization success
        /// </summary>
        public const string NotAuthorizationSuccess = "Xác thực không thành công";

        /// <summary>
        /// The update failed his
        /// </summary>
        public const string UpdateFailedHIS = "Cập nhật HIS thất bại";

        /// <summary>
        /// The api not available
        /// </summary>
        public const string ApiAvailable = "Api chưa hoạt động";

        /// <summary>
        /// The can not delete device
        /// </summary>
        public const string CanNotDeleteDevice = "Không thể xóa thiết bị, tồn tại ít nhất một cài đặt với thiết bị này!";

        /// <summary>
        /// The can not delete application
        /// </summary>
        public const string CanNotDeleteApplication = "Không thể xóa ứng dụng, tồn tại ít nhất một cài đặt với ứng dụng này!";

        /// <summary>
        /// The can not delete version
        /// </summary>
        public const string CanNotDeleteVersion = "Không thể xóa phiên bản, tồn tại ít nhất một cài đặt với phiên bản này!";

        /// The wrong phone or password
        /// </summary>
        public const string NotFoundUserNameOrPhone = "Số điện thoại hoặc mật khẩu không đúng.";

        /// <summary>
        /// The patient had exist queue number
        /// </summary>
        public const string PatientHadExistQueueNumber = "Bệnh nhân đã có số thứ tự trong phòng này.";

        /// <summary>
        /// The invalid time remove queue
        /// </summary>
        public const string InvalidTimeRemoveQueue = "Thời gian xóa số thứ tự không chính xác.";

        /// <summary>
        /// The verify code faild
        /// </summary>
        public const string VerifyCodeFaild = "Mã xác nhận không chính xác.";

        /// <summary>
        /// The not found extend value
        /// </summary>
        public const string NotFoundExtendValue = "Mã phòng không tồn tại.";

        /// <summary>
        /// The invalid format email
        /// </summary>
        public const string InvalidFormatEmail = "Địa chỉ email không đúng định dạng.";

        /// <summary>
        /// The not found email setting
        /// </summary>
        public const string NotFoundEmailSetting = "Không tìm thấy cài đặt email.";

        /// <summary>
        /// The invalid mail type
        /// </summary>
        public const string InvalidMailType = "Loại hình gửi mail không chính xác.";

        /// <summary>
        /// The table not exist
        /// </summary>
        public const string TableNotExist = "Không tồn tại bàn này";
        /// <summary>
        /// The patient has not taken number
        /// </summary>
        public const string PatientHasNotTakenNumber = "Bệnh nhân này chưa lấy số";
        /// <summary>
        /// The queue number is not turn
        /// </summary>
        public const string QueueNumberIsNotTurn = "Số thứ tự chưa đến lượt";
        /// <summary>
        /// The invalid amount
        /// </summary>
        public const string InvalidAmount = "Số tiền phải lớn hơn 0.";
        /// <summary>
        /// The not found service
        /// </summary>
        public const string NotFoundService = "Không tim thấy mã dịch vụ {0}.";
        /// <summary>
        /// The not found patient with code
        /// </summary>
        public const string NotFoundPatientWithCode = "Không tìm thấy bệnh nhân có mã {0}.";
        /// <summary>
        /// The invalid examination type
        /// </summary>
        public const string InvalidExaminationType = "Loại hình bệnh nhân không đúng.";
        /// <summary>
        /// The not found doctor
        /// </summary>
        public const string NotFoundDoctor = "Mã bác sĩ không tồn tại.";
        /// <summary>
        /// The invalid format datetime
        /// </summary>
        public const string InvalidFormatDatetime = "Định dạng ngày giờ không đúng.";
        /// <summary>
        /// The unknow error
        /// </summary>
        public const string UnknowError = "Lỗi không xác định.";

        /// <summary>
        /// The not found phone number
        /// </summary>
        public const string NotFoundPhoneNumber = "Không tìm thấy thông tin bệnh nhân với số điện thoại này.";

        /// <summary>
        /// The not found queue number register
        /// </summary>
        public const string NotFoundQueueNumberRegister = "Không tìm thấy số thứ tự";

        /// <summary>
        /// The not found hospital code
        /// </summary>
        public const string NotFoundHospitalCode = "Không tìm thấy mã bệnh viện";

        /// <summary>
        /// The invalid phone number
        /// </summary>
        public const string InvalidPhoneNumber = "Số điện thoại không hợp lệ.";

        /// <summary>
        /// The patient has registerd
        /// </summary>
        public const string PatientHasRegisterd = "Bệnh nhân đã đăng ký số thứ tự ở bệnh viện này.";

        /// <summary>
        /// The invalid registered date
        /// </summary>
        public const string InvalidRegisteredDate = "Ngày đăng ký khám phải lớn hơn ngày hiện tại.";

        /// <summary>
        /// The can not update temporary patient
        /// </summary>
        public const string CanNotUpdateTempPatient = "Không thể cập nhật thông tin, vì ngày đăng ký khám đã quá hạn.";

        /// <summary>
        /// The not found pharmacy
        /// </summary>
        public const string NotFoundPharmacy = "Mã thuốc không tồn tại.";

        /// <summary>
        /// The not found medicine
        /// </summary>
        public const string NotFoundMedicine = "Mã dược không tồn tại.";
        /// <summary>
        /// The not found extend value
        /// </summary>
        public const string NotFoundListValue = "Không tìm thấy dữ liệu.";

        /// <summary>
        /// The not found list value type
        /// </summary>
        public const string NotFoundListValueType = "Không tìm thấy dữ liệu.";

        /// <summary>
        /// The invalid next call time
        /// </summary>
        public const string InvalidNextCallTime = "Chưa đủ thời gian cho lần gọi tiếp theo.";

        /// <summary>
        /// The patient has been called into the room
        /// </summary>
        public const string PatientHasBeenCalledIntoTheRoom = "Bệnh nhân này đã được gọi vào phòng";

        /// <summary>
        /// The table type incorrect
        /// </summary>
        public const string TableTypeIncorrect = "Loại bàn không đúng";

        /// <summary>
        /// The exsited paid transaction
        /// </summary>
        public const string ExsitedPaidTransaction = "Tồn tại ít nhất một dịch vụ đã được tất toán.";
        /// <summary>
        /// The exsited paid transaction
        /// </summary>
        public const string InvalidFileApk = "Định dạng apk file không đúng.";
        public const string FunctionTimeOut = "Chức năng bị tạm dừng vì vượt quá thời gian cho phép. Vui lòng thử lại sau.";
        public const string NotFoundVersion = "Không tìm thấy phiên bản";
        public const string NotFounDeviceOrApp = "Không tìm thấy thiết bị hoặc ứng dụng";
    }

    /// <summary>
    /// Class ErrorMessages.
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// The not enough balance message
        /// </summary>
        public const string Success = "Thành công.";

        /// <summary>
        /// The waiting
        /// </summary>
        public const string Waiting = "Đang xử lý.";

        /// <summary>
        /// The new
        /// </summary>
        public const string New = "Mới.";

        /// <summary>
        /// The approved
        /// </summary>
        public const string Approved = "Thanh toán thành công.";

        /// <summary>
        /// The approved
        /// </summary>
        public const string Failed = "Có lỗi xảy ra. Vui lòng thử lại.";

    }

    public static class MessagesCode
    {
        /// <summary>
        /// The not found patient with code
        /// </summary>
        public const string NotFoundPatientWithCode = "NotFoundPatientWithCode";
        /// <summary>
        /// The invalid amount
        /// </summary>
        public const string InvalidAmount = "InvalidAmount";
        /// <summary>
        /// The not found medicine
        /// </summary>
        public const string NotFoundMedicine = "NotFoundMedicine";
        /// <summary>
        /// The not found service
        /// </summary>
        public const string NotFoundService = "NotFoundService";
        /// <summary>
        /// The not enough balance
        /// </summary>
        public const string NotEnoughBalance = "NotEnoughBalanceMessage";
        /// <summary>
        /// The not found card number
        /// </summary>
        public const string NotFoundCardNumber = "NotFoundCardNumber";
        /// <summary>
        /// The have not provided card number
        /// </summary>
        public const string HaveNotProvidedCardNumber = "HaveNotProvidedCardNumber";
        /// <summary>
        /// The table not exist
        /// </summary>
        public const string TableNotExist = "TableNotExist";
        /// <summary>
        /// The patient has not taken number
        /// </summary>
        public const string PatientHasNotTakenNumber = "PatientHasNotTakenNumber";
        /// <summary>
        /// The finished queue number temporary
        /// </summary>
        public const string FinishedQueueNumberTemp = "FinishedQueueNumberTemp";
        /// <summary>
        /// The queue number is not turn
        /// </summary>
        public const string QueueNumberIsNotTurn = "QueueNumberIsNotTurn";
        /// <summary>
        /// The invalid examination type
        /// </summary>
        public const string InvalidExaminationType = "InvalidExaminationType";
        /// <summary>
        /// The not found doctor
        /// </summary>
        public const string NotFoundDoctor = "NotFoundDoctor";
        /// <summary>
        /// The invalid format datetime
        /// </summary>
        public const string InvalidFormatDatetime = "InvalidFormatDatetime";
        /// <summary>
        /// The unknow error
        /// </summary>
        public const string UnknowError = "UnknowError";
    }
}
