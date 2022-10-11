  
namespace Kama.Organization.Core.ErrorKey
{
	namespace General
	{
		public class Application
		{
			public const string ActionKey = "general_application";
			
			/// <summary>
            /// خطای سیستمی
            /// </summary>
			public const string Error = "general_application:-1";

			/// <summary>
            /// خطای سیستمی
            /// </summary>
			public const int Error_Code = -1;
		}
		public class Database
		{
			public const string ActionKey = "general_database";
			
			/// <summary>
            /// خطای دیتابیس
            /// </summary>
			public const string DatabaseModelBinderException = "general_database:-1";

			/// <summary>
            /// خطای دیتابیس
            /// </summary>
			public const int DatabaseModelBinderException_Code = -1;
		}
	}
	namespace Permission
	{
		public class RolePermission
		{
			public const string ActionKey = "permission_rolepermission";
			
			/// <summary>
            /// ساختار مجوزهای داده شده نامعتبر است.
            /// </summary>
			public const string InvalidPermission = "permission_rolepermission:-2";

			/// <summary>
            /// ساختار مجوزهای داده شده نامعتبر است.
            /// </summary>
			public const int InvalidPermission_Code = -2;
			
			/// <summary>
            /// نقش مشخص نیست.
            /// </summary>
			public const string UnknownRole = "permission_rolepermission:-3";

			/// <summary>
            /// نقش مشخص نیست.
            /// </summary>
			public const int UnknownRole_Code = -3;
		}
	}
	namespace Position
	{
		public class Modify
		{
			public const string ActionKey = "position_modify";
		}
	}
	namespace User
	{
		public class Activation
		{
			public const string ActionKey = "user_activation";
			
			/// <summary>
            /// کد فعالسازی معتبر نمی باشد
            /// </summary>
			public const string ActivationCodeIsInvalid = "user_activation:-1";

			/// <summary>
            /// کد فعالسازی معتبر نمی باشد
            /// </summary>
			public const int ActivationCodeIsInvalid_Code = -1;
		}
		public class DB_Delete
		{
			public const string ActionKey = "user_db_delete";
		}
		public class DB_Modify
		{
			public const string ActionKey = "user_db_modify";
			
			/// <summary>
            /// شناسه دپارتمان نامعتبر است.
            /// </summary>
			public const string DepartmentUndefined = "user_db_modify:-2";

			/// <summary>
            /// شناسه دپارتمان نامعتبر است.
            /// </summary>
			public const int DepartmentUndefined_Code = -2;
			
			/// <summary>
            /// شناسه کاربری تکراری می باشد.
            /// </summary>
			public const string DuplicateUsername = "user_db_modify:-3";

			/// <summary>
            /// شناسه کاربری تکراری می باشد.
            /// </summary>
			public const int DuplicateUsername_Code = -3;
			
			/// <summary>
            /// کد ملی تکراری می باشد.
            /// </summary>
			public const string DuplicateNationalCode = "user_db_modify:-4";

			/// <summary>
            /// کد ملی تکراری می باشد.
            /// </summary>
			public const int DuplicateNationalCode_Code = -4;
		}
		public class General
		{
			public const string ActionKey = "user_general";
			
			/// <summary>
            /// کلمه عبور معتبر نمی باشد
            /// </summary>
			public const string InvalidPassword = "user_general:-1";

			/// <summary>
            /// کلمه عبور معتبر نمی باشد
            /// </summary>
			public const int InvalidPassword_Code = -1;
			
			/// <summary>
            /// تکرار کلمه عبور معتبر نمی باشد
            /// </summary>
			public const string InvalidConfirmPassword = "user_general:-2";

			/// <summary>
            /// تکرار کلمه عبور معتبر نمی باشد
            /// </summary>
			public const int InvalidConfirmPassword_Code = -2;
		}
		public class Register
		{
			public const string ActionKey = "user_register";
		}
		public class Role
		{
			public const string ActionKey = "user_role";
			
			/// <summary>
            /// نقش ها نامعتبر است.
            /// </summary>
			public const string InvalidRoles = "user_role:-2";

			/// <summary>
            /// نقش ها نامعتبر است.
            /// </summary>
			public const int InvalidRoles_Code = -2;
			
			/// <summary>
            /// کاربر مشخص نیست.
            /// </summary>
			public const string UserUndefined = "user_role:-3";

			/// <summary>
            /// کاربر مشخص نیست.
            /// </summary>
			public const int UserUndefined_Code = -3;
		}
	}
}