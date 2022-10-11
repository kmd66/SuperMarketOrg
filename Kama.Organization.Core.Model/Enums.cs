namespace Kama.Organization.Core.Model
{

    public enum EnableState : byte
    {
        Unknown = 0,

        غیر_فعال = 1,
        فعال = 2,
    }

    public enum DynamicReportFieldType : byte
    {
        Unknown = 0,
        عدد = 1,
        رشته = 2,
        چند_مقدار = 3,
        تاریخ = 4,
    }

    public enum DynamicPermissionDetailType : byte
    {
        Unknown = 0,

        ParentDepartment = 1,
        Department = 2,
        Province = 3,
        DepartmentType = 4,
        //DepartmentSubType = 5,
        //OrganType = 6,
        //COFOG = 7,
        //CouncilType=8,
        PositionType = 9,
        Position = 10
    }

    public enum LoginType : byte
    {
        Unknown = 0,

        نام_کاربری_و_کلمه_عبور = 1,
        تلفن_همراه_و_کلمه_عبور = 2,
        تلفن_همراه_و_کد_امنیتی = 3,
        ایمیل_و_کلمه_عبور = 4,
        ایمیل_و_کد_امنیتی = 5,
    }

    public enum ContactDetailType : byte
    {
        Unknown = 0,

        تلفن = 1,
        موبایل = 2,
        نمابر = 3,
        ایمیل = 4,
        آدرس = 5,
        کد_پستی = 6
    }

    public enum OrganLawType : byte
    {
        Unknown = 0,
        مشمول_قانون_مدیریت_خدمات_کشوری = 1,
        غیر_مشمول_قانون_مدیریت_خدمات_کشوری = 2,
        ترکیبی = 3
    }



    public enum EmploymentRegulationsType : byte
    {
        Unknown = 0,
        مشمول_قانون_مدیریت_خدمات_کشوری = 1,
        تابع_ضوابط_و_مقررات_قانون_مدیریت_خدمات_کشوری = 2,
        مشمول_قانون_کار = 3,
        مشمول_آیین_نامه_استخدامی_هیات_امنایی_تابع_وزارت_علوم = 4,
        مشمول_آیین_نامه_استخدامی_هیات_امنایی_تابع_وزارت_بهداشت = 5,
        نهاد_عمومی_غیر_دولتی = 6,
        مشمول_آیین_نامه_استخدامی_فرهنگستان_های_کشور = 7,
        مشمول_قوانین_و_مقررات_خاص = 8,
        مشمول_مقررات_استخدامی_شهرداری_ها = 9,
        قوانین_و_مقررات_استخدامی_ترکیبی = 10,
        مشمول_قوانین_و_مقررات_خاص_قوه_مقننه = 11,
        مشمول_قانون_استخدام_کشوری = 12,
    }

    public enum ClientType : byte
    {
        Unknown = 0,

        JavaScript = 1,
        Native = 2
    }

    public enum CommandType : byte
    {
        Unknown = 0,

        App = 1,
        Menu = 2,
        Page = 3,
        State = 7,
        Tab = 10,
        Element = 20,
    }

    public enum AnnouncementType : byte
    {
        Unknown = 0,

        اخبار = 1,
        اطلاعیه = 2
    }

    public enum AnnouncementPriorityType : byte
    {
        Unknown = 0,

        زیاد = 1,
        متوسط = 2,
        پایین = 3
    }

    public enum EnableOrDisable : byte
    {
        Unknown = 0,

        غیر_فعال = 1,
        فعال = 2
    }
    public enum ArchivedType : byte
    {
        Unknown = 0,

        NotArchived = 1,
        Archived = 2
    }
    public enum OrganizationAttachmentType : byte
    {
        Unknown = 0,
        فایل_پیوست_اعلان = 1,
        تصویر_اعلان = 2,
        تصویر_کاربر = 3
    }

    public enum DepartmentType : byte
    {
        Unknown = 0,
        سازمان = 1,
        //دفاتر عمران شمال
        دفتر_املاک = 20,    
        محله = 30
    }

    public enum UserType : byte
    {
        Unknown = 0,
        کاربر_درون_سازمانی = 1,
        کاربر_برون_سازمانی = 2
    }

    public enum ApplicationStatus
    {
        Unknown = 0,
        فعال = 1,
        غیر_فعال = 2
    }

    public enum PlaceType : byte
    {
        Unknown = 0,
        قاره = 1,
        کشور = 2,
        استان = 3,
        شهرستان = 4,
        بخش = 5,
        شهر = 6,
        دهستان = 7,
        روستا = 8
    }

    public enum PositionType : byte
    {
        Unknown = 0,

        راهبر = 100
    }

    public enum AgreementPositionType : byte
    {
        Unknown = 0,
        کاربر_استان = 1,
        کارشناس_توافقات = 5,
        مدیر_کل_توافقات = 10,
        مدیر_بخش = 15,

        راهبر = 100
    }

    public enum EvaluationPositionType : byte
    {
        Unknown = 0,
        کاربر_استان = 1,
        کارشناس_طرح_و_برنامه = 10,
        کارشناس_تحقیق_و_استرداد = 20,
        راهبر = 100
    }

    public enum OmranShomalPositionType : byte
    {
        Unknown = 0,

        کارشناس = 1,

        راهبر = 100

    }

    public enum SendMessageType : byte
    {
        Unknown = 0,

        Email = 1,
        Sms = 2
    }

    public enum UserNotificationType : byte
    {
        Unknown = 0,

        Email = 1,
        Sms = 2,
        Notification = 3
    }

    public enum UserNotificationTemplate : byte
    {
        Unknown = 0,
        ForgotPassword = 1,
        ResetPassword = 2,
        VerifyCellphone = 3,
        VerifyEmail = 4,
        UserAdded = 5,
        PasswordChanged = 6,
        UserInNewPosition = 7,
        SendForgotPasswordLinkByEmail = 8
    }

    public enum SendMessageReasonType : byte
    {
        Unknown = 0,

        ForgotPassword = 1,
        ResetPassword = 2,
        VerifyCellphone = 3,
        VerifyEmail = 4,
        UserAdded = 5,
        ActivateUser = 6
    }

    public enum NotificationPriority : byte
    {
        زیاد = 1,
        متوسط = 2,
        کم = 3
    }

    public enum NotificationType : byte
    {
        Unknown = 0,

        اخبار = 1,
        اطلاعیه_ها = 2

    }

    public enum NotificationState : byte
    {
        Unknown = 0,
        ارسال_نشده = 1,
        ارسال_شده = 2,
        آرشیو_شده = 3,
        حذف_شده = 4
    }

    public enum NotificationSenderType : byte
    {
        Unknown = 0,
        سامانه = 1,
        کاربر = 2
    }

    public enum ApplicationSurveyQuestionType : byte
    {
        Unknown = 0,
        بله_یا_خیر = 1,
        تک_انتخابی = 2,
        چند_انتخابی = 3,
        متن_کوتاه = 4,
        متن_بلند = 5
    }

    public enum AttachmentType : short
    {
        تصویر_امضا_کاربر = 50,
    }

    public enum TicketAnswerState : byte
    {
        نامشخص = 0,
        پاسخ_داده_شده = 1,
        پاسخ_داده_نشده = 2
    }

    public enum TicketScore : byte
    {
        Unknown = 0,
        خوب = 1,
        متوسط = 2,
        ضعیف = 3
    }

    public enum TicketState : byte
    {
        Unknown = 0,
        باز_است = 1,
        بسته_شود = 2,
        در_دست_اقدام_می_باشد = 3,
    }

    public enum TicketReportState : byte
    {
        Unknown = 0,
        باز = 1,
        بسته_شده = 2,
        در_دست_اقدام = 3,
    }

    public enum SurveyAnswerType : byte
    {
        Unknown = 0,
        خیلی_خوب = 1,
        خوب = 2,
        متوسط = 3,
        بد = 4,
        خیلی_بد = 5,
    }
    public enum ZoneType : byte
    {
        Unknown = 0,
        اینترانت = 1,
        اینترنت = 2,
    }
    public enum BonyadPositionType : byte
    {
        Unknown = 0,
        کاربر_استان = 1,

        کارشناس = 5,

        راهبر = 100
    }
}