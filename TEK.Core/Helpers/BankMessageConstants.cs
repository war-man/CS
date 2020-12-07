namespace TEK.Core.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class BankMessageConstants
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="bank_message">The bank message.</param>
        /// <returns></returns>
        public static string GetMessage(string code, string bank_message)
        {
            var result = bank_message;
            switch (code)
            {
                case "INVALID_USER_MOBILE":
                    result = "Số điện thoại không hợp lệ";
                    break;

                case "INVALID_USER_PIN":
                    result = "Mã pin không hợp lệ";
                    break;

                case "INVALID_USER_ID":
                    result = "Mã tài khoản ngân hàng không hợp lệ";
                    break;

                case "INVALID_USER":
                    result = "Thông tin user không đúng";
                    break;

                case "INVALID_ORDER":
                    result = "Mã hóa đơn không tồn tại";
                    break;

                case "INVALID_CURRENCY":
                    result = "Mã tiền tệ không hợp lệ";
                    break;

                case "INVALID_TOKEN_NUMBER":
                    result = "Mã token không hợp lệ";
                    break;

                case "INVALID_OTP":
                    result = "Mã otp không hợp lệ";
                    break;

                case "AUTHORIZATION_EXPIRED":
                    result = "Yêu cầu xác thực hết hạn";
                    break;

                case "OTP_VERIFICATION_FAILURE":
                    result = "Xác thực otp thất bại";
                    break;

                case "INSTRUMENT_EXISTED":
                    result = "Thẻ này đã được kích hoạt. Vui lòng sử dụng thẻ khác";
                    break;

                case "DO_NOT_HONOR":
                    result = "Giao dịch không thành công: thẻ không hợp lệ";
                    break;

                case "INSUFFICIENT_FUNDS":
                    result = "Không đủ tiền trong thẻ";
                    break;

                case "S5":
                    result = "Số điện thoại chưa được kích hoạt sms otp";
                    break;

                case "P1":
                    result = "Sai thông tin đăng ký thẻ\n Vui nhập đúng"; // Body Request
                    break;

                case "P2":
                    result = "Tài khoản chưa đăng ký";
                    break;

                case "P3":
                    result = "Thẻ chưa đăng ký";
                    break;

                case "LIMIT_EXCEEDED":
                    result = "Vượt quá số lượt thanh toán trong ngày";
                    break;

                case "UNMATCH_DATA":
                    result = "Dữ liệu không đúng";
                    break;
            }

            return result;
        }
    }
}
