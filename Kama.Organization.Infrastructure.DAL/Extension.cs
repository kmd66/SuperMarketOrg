﻿//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Kama.Organization.Infrastructure.DAL
//{
//    internal static class Extension
//    {
//        public static int ToInt(this string s)
//        {
//            int result = 0;
//            int.TryParse(s.Trim(), out result);
//            return result;
//        }

//        public static int DbErrorCode(this DatabaseModel.ResultSet result)
//             => result.ReturnValue >= 0 ? result.ReturnValue : $"-10{Math.Abs(result.ReturnValue)}".ToInt();

//        public static bool DbSucceed(this DatabaseModel.ResultSet result)
//            => result.ReturnValue >= 0;

//        public static AppCore.Result ToActionResult(this DatabaseModel.ResultSet result, string message = "")
//            => AppCore.Result.Set(success: result.ReturnValue >= 0, code: Math.Abs(result.ReturnValue), message: message);

//        public static AppCore.Result<T> ToActionResult<T>(this DatabaseModel.ResultSet result, string message = "")
//            where T : class, new()
//            => AppCore.Result<T>.Set(success: result.ReturnValue >= 0, code: Math.Abs(result.ReturnValue), data: result.GetModels<T>().FirstOrDefault(), message: message);

//        public static AppCore.Result<IEnumerable<T>> ToListActionResult<T>(this DatabaseModel.ResultSet result, string message = "")
//            where T : class, new()
//            => AppCore.Result<IEnumerable<T>>.Set(success: result.ReturnValue >= 0, code: Math.Abs(result.ReturnValue), data: result.GetModels<T>(), message: message);
//    }
//}