using System;

namespace Kama.Organization.Core
{
	public enum ApplicationEnum : int
	{
		Unknown = 0,
		سامانه_هیات_موضوع_ماده_251_مکرر_قانون_مالیات‌های_مستقیم = 1,
		سامانه_تشخیص_صلاحیت_حرفه_ای_حسابداران_رسمی = 2,
		سازماندهی = 3,
	}

	public static class ApplicationHelper
	{
		public static ApplicationEnum GetApplicationEnum(Guid applicationID)
		{
			switch(applicationID.ToString())
			{
				case "2ac51699-9656-4060-b632-b85e4af705ba": return ApplicationEnum.سامانه_هیات_موضوع_ماده_251_مکرر_قانون_مالیات‌های_مستقیم;
				case "67e63b1d-e423-46cc-adb2-2d6a46226141": return ApplicationEnum.سامانه_تشخیص_صلاحیت_حرفه_ای_حسابداران_رسمی;
				case "6448c892-f0c7-4002-b139-011cb2e57d14": return ApplicationEnum.سازماندهی;
				default: return ApplicationEnum.Unknown;
			}
		}
	}
}
