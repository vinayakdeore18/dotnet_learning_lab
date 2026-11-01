
using System;

public interface IOtpService
{
    void SendOtp(string mobile);
}

public class SmsOtpService : IOtpService
{
    public void SendOtp(string mobile)
    {
        Console.WriteLine($"OTP sent to {mobile} using SMS.");
    }
}

public class AccountService
{
    private readonly IOtpService _otpService;

    public AccountService(IOtpService otpService)
    {
        _otpService = otpService;
    }

    public void VerifyAccount(string mobile)
    {
        Console.WriteLine("Verifying account...");
        _otpService.SendOtp(mobile);
    }
}

public class Program
{
    public static void Main()
    {
        IOtpService otpService = new SmsOtpService();

        AccountService accountService =
            new AccountService(otpService);

        accountService.VerifyAccount("9999999999");
    }
}
