using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Kama.AppCore;
using Kama.Organization.Core.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Kama.Library.Helper;

namespace Kama.Organization.Domain
{
    internal class PositionService : Service<Core.DataSource.IPositionDataSource>, Core.Service.IPositionService
    {
        public PositionService(
            AppCore.IOC.IContainer container,
            Core.DataSource.IRoleDataSource roleDataSource,
            Core.DataSource.IPositionTypeDataSource positionTypeDataSource,
            Core.DataSource.IDepartmentDataSource departmentDataSource,
            Core.DataSource.IPositionHistoryDataSource positionHistoryDataSource,
            Core.DataSource.IPositionDepartmentMappingDataSource positionDepartmentMappingDataSource)
            : base(container)
        {
            _positionTypeDataSource = positionTypeDataSource;
            _roleDataSource = roleDataSource;
            _departmentDataSource = departmentDataSource;
            _positionHistoryDataSource = positionHistoryDataSource;
            _positionDepartmentMappingDataSource = positionDepartmentMappingDataSource;
        }

        readonly Core.DataSource.IPositionTypeDataSource _positionTypeDataSource;
        readonly Core.DataSource.IRoleDataSource _roleDataSource;
        readonly Core.DataSource.IDepartmentDataSource _departmentDataSource;
        readonly Core.DataSource.IPositionHistoryDataSource _positionHistoryDataSource;
        readonly Core.DataSource.IPositionDepartmentMappingDataSource _positionDepartmentMappingDataSource;

        public async Task<AppCore.Result<Core.Model.Position>> AddAsync(Core.Model.Position model)
        {
            var validationResult = await _ValidateForSave(model);
            if (!validationResult.Success)
                return AppCore.Result<Position>.Failure(message: validationResult.Message);

            var getRolesResult = await _positionTypeDataSource.GetRolesAsync(model.Type);
            if (!getRolesResult.Success)
                return AppCore.Result<Core.Model.Position>.Failure(message: getRolesResult.Message);

            if (model.UserID != null && _requestInfo.UserId != null && model.UserType == UserType.کاربر_درون_سازمانی )
            {
                var positionHistory = await _positionHistoryDataSource.CreateAsync(new PositionHistory { ID = Guid.NewGuid(), PositionID = model.ID, UserID = (Guid)model.UserID }, null);
                if (!positionHistory.Success)
                    return AppCore.Result<Position>.Failure(message: positionHistory.Message);
            }

            model.Roles = getRolesResult.Data.ToList();
            return await _dataSource.CreateAsync(model, null);
        }

        public async Task<AppCore.Result<Core.Model.Position>> EditAsync(Core.Model.Position model)
        {
            var validationResult = await _ValidateForSave(model);
            if (!validationResult.Success)
                return AppCore.Result<Position>.Failure(message: validationResult.Message);
            
            if (model.UserID != null && model.UserType == UserType.کاربر_درون_سازمانی)
            {
                var positionHistory = await _positionHistoryDataSource.CreateAsync(new PositionHistory { ID = Guid.NewGuid(), PositionID = model.ID, UserID = (Guid)model.UserID }, null);
                if (!positionHistory.Success)
                    return AppCore.Result<Position>.Failure(message: positionHistory.Message);
            }

            return await _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result> SetDefaultAsync(Guid positionId)
        {
            return _dataSource.SetDefaultAsync(positionId, null);
        }

        public Task<AppCore.Result> RemoveUserAsync(Guid id)
        {
            return _dataSource.RemoveUserAsync(id, null);
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Position<T>>>> ListAsync<T>(Core.Model.PositionListVM model)
        {
            var listModel = await _dataSource.ListAsync<T>(_requestInfo.ApplicationId ?? model.ApplicationID, model);
            if (listModel.Data.Count() > 0)
            {
                if (model.FilterUserNull)
                {
                    listModel.Data = listModel.Data.Where(x => x.UserID != null);
                }
                if (model.ProvinceId != Guid.Empty && model.ProvinceId != null)
                {
                    listModel.Data = listModel.Data.Where(x => x.ProvinceID == model.ProvinceId);
                }
            }
            return listModel;
        }

        public Task<AppCore.Result<IEnumerable<Core.Model.Position<T>>>> ListCurrentUserPositionsAsync<T>()
            => _dataSource.ListAsync<T>(_requestInfo.ApplicationId, new PositionListVM { UserID = _requestInfo.UserId});

        public Task<AppCore.Result<IEnumerable<Core.Model.Position<T>>>> ListInAllApplicationsAsync<T>(Core.Model.PositionListVM model)
            => _dataSource.ListAsync<T>(null, model);

        public async Task<AppCore.Result<Core.Model.Position>> GetAsync(Guid id)
        {
            var async = new
            {
                getAsync = _dataSource.GetAsync(id),
                roleAsync = _roleDataSource.ListAsync(new Core.Model.RoleListVM { PositionID = id })
            };

            var getResult = await async.getAsync;
            if (!getResult.Success)
                return getResult;

            var roleResult = await async.roleAsync;
            if (!roleResult.Success)
                return Result<Position>.Failure(message: roleResult.Message);

            getResult.Data.Roles = roleResult.Data.ToList();
            return getResult;
        }

        public Task<AppCore.Result<Core.Model.GetOnlineUsersAndPositionsCountVM>> GetOnlineCountAsync()
            => _dataSource.GetOnlineCountAsync();

        public async Task<AppCore.Result<Core.Model.Position<Core.Model.PositionType>>> GetDefaultPosition(Guid applicationId, Guid userId)
        {
            var listResult = await this.ListAsync<Core.Model.PositionType>(new Core.Model.PositionListVM { ApplicationID = applicationId, UserID = userId });
            if (!listResult.Success)
                return AppCore.Result<Core.Model.Position<Core.Model.PositionType>>.Failure(message: "دریافت اطلاعات با خطا مواجه شد.");

            var positions = listResult.Data.Where(x => x.UserEnabled); //x.Enabled &&
            if (positions == null || !positions.Any())
                return AppCore.Result<Core.Model.Position<Core.Model.PositionType>>.Failure(message: "شما مجوز ورود به این سامانه را ندارید.");

            var defaultPositions = positions.Where(p => p.Default == true).ToList();
            Core.Model.Position<Core.Model.PositionType> defaultPosition = null;

            if (defaultPositions.Count() == 1)
                defaultPosition = defaultPositions.First();
            else
            {
                if (defaultPositions.Count() == 0)
                    defaultPosition = positions.FirstOrDefault();
                else
                    defaultPosition = defaultPositions.FirstOrDefault();

                var setDefaultPositionResult = await this.SetDefaultAsync(defaultPosition.ID);
                if (!setDefaultPositionResult.Success)
                    return AppCore.Result<Core.Model.Position<Core.Model.PositionType>>.Failure(message: "عملیات با خطا مواجه شد.");
            }

            await _dataSource.SetDefaultAsync(defaultPosition.ID, null);

            return AppCore.Result<Core.Model.Position<Core.Model.PositionType>>.Successful(data: defaultPosition);

        }

        public async Task<AppCore.Result<IEnumerable<object>>> GetPermissionsAsync(Guid positionId)
        { 
            var listResult = await _dataSource.GetPermissionsAsync(positionId, null);
            if (!listResult.Success)
                return AppCore.Result<IEnumerable<object>>.Failure(message: listResult.Message);

            var list = listResult.Data
                        .Where(p => p.Type != CommandType.State || !listResult.Data.Any(pp => pp.Type == CommandType.State && p.FullName != pp.FullName && pp.Node.Contains(p.Node)))   // only the last chil state to be selected in states
                        .Select(p => new { Name = p.PermissionName })
                        .ToList();

            return AppCore.Result<IEnumerable<object>>.Successful(data: list);
        }

        public async Task<AppCore.Result<byte[]>> ListExcelAsync<T>(Core.Model.PositionListVM model)
        {
            try
            {
                model.PageIndex = 0;
                var result = await this.ListAsync<T>(model);
                if (!result.Success)
                    return AppCore.Result<byte[]>.Failure(message: "دریافت گزارش درخواست ها با خطا مواجه شد");

                byte[] bytes = null;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet sheet = excelPackage.Workbook.Worksheets.Add("sheet1");
                    sheet.View.RightToLeft = true;

                    var rowIndex = 1;
                    var colIndex = 1;

                    sheet.Cells[1, 1, 6, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Cells[1, 1, 6, 15].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightYellow);
                    //sheet.Cells[1, 1, 1, 15].Value = "سامانه استخدام و بکارگیری نیروی انسانی";
                    //sheet.Cells[1, 1, 2, 15].Merge = true;
                    sheet.Cells[3, 1, 3, 15].Value = "گزارش لیست‌ درخواست ها";
                    sheet.Cells[3, 1, 4, 15].Merge = true;
                    sheet.Cells[5, 1, 5, 15].Value = $@"تاریخ گزارش: { DateTime.Now.ToJalaliDateTime()}";
                    sheet.Cells[5, 1, 6, 15].Merge = true;
                    sheet.Cells[6, 1, 6, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Cells[6, 1, 6, 15].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Wheat);

                    rowIndex = 7;
                    sheet.Cells[rowIndex, colIndex++].Value = "ردیف";
                    sheet.Cells[rowIndex, colIndex++].Value = "دستگاه اجرایی";
                    sheet.Cells[rowIndex, colIndex++].Value = "کد ملی";
                    sheet.Cells[rowIndex, colIndex++].Value = "نام";
                    sheet.Cells[rowIndex, colIndex++].Value = "نام خانوادگی";
                    sheet.Cells[rowIndex, colIndex++].Value = "سمت";
                    sheet.Cells[rowIndex, colIndex++].Value = "نام کاربری";
                    rowIndex++;

                    foreach (var reportItem in result.Data)
                    {
                        colIndex = 1;

                        sheet.Cells[rowIndex, colIndex++].Value = rowIndex - 7;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.DepartmentName;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.NationalCode;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.FirstName;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.LastName;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.Type.ToString().Replace("_", " ");
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.Username;
                    }

                    using (ExcelRange range = sheet.Cells)
                    {
                        range.Style.Font.SetFromFont(new System.Drawing.Font("Tahoma", 9));
                        range.Style.Font.Bold = true;
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        range.Style.ReadingOrder = ExcelReadingOrder.RightToLeft;
                    }

                    const double minWidth = 0.00;
                    const double maxWidth = 50.00;
                    sheet.Cells.AutoFitColumns(minWidth, maxWidth);

                    bytes = excelPackage.GetAsByteArray();

                }

                return AppCore.Result<byte[]>.Successful(data: bytes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AppCore.Result<byte[]>> ListExcelWithRolesAsync<T>(Core.Model.PositionListVM model)
        {
            try
            {
                model.PageIndex = 0;
                var result = await _dataSource.ListWithRolesAsync<T>(model);
                if (!result.Success)
                    return AppCore.Result<byte[]>.Failure(message: "دریافت گزارش درخواست ها با خطا مواجه شد");

                byte[] bytes = null;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet sheet = excelPackage.Workbook.Worksheets.Add("sheet1");
                    sheet.View.RightToLeft = true;

                    var rowIndex = 1;
                    var colIndex = 1;

                    sheet.Cells[1, 1, 6, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Cells[1, 1, 6, 15].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightYellow);
                    //sheet.Cells[1, 1, 1, 15].Value = "سامانه استخدام و بکارگیری نیروی انسانی";
                    //sheet.Cells[1, 1, 2, 15].Merge = true;
                    sheet.Cells[3, 1, 3, 15].Value = "گزارش لیست‌ درخواست ها";
                    sheet.Cells[3, 1, 4, 15].Merge = true;
                    sheet.Cells[5, 1, 5, 15].Value = $@"تاریخ گزارش: { DateTime.Now.ToJalaliDateTime()}";
                    sheet.Cells[5, 1, 6, 15].Merge = true;
                    sheet.Cells[6, 1, 6, 15].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Cells[6, 1, 6, 15].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Wheat);

                    rowIndex = 7;
                    sheet.Cells[rowIndex, colIndex++].Value = "ردیف";
                    sheet.Cells[rowIndex, colIndex++].Value = "دستگاه اجرایی";
                    sheet.Cells[rowIndex, colIndex++].Value = "کد ملی";
                    sheet.Cells[rowIndex, colIndex++].Value = "نام";
                    sheet.Cells[rowIndex, colIndex++].Value = "نام خانوادگی";
                    sheet.Cells[rowIndex, colIndex++].Value = "سمت";
                    sheet.Cells[rowIndex, colIndex++].Value = "نام کاربری";
                    sheet.Cells[rowIndex, colIndex++].Value = "نقش";
                    rowIndex++;

                    foreach (var reportItem in result.Data)
                    {
                        colIndex = 1;

                        sheet.Cells[rowIndex, colIndex++].Value = rowIndex - 7;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.DepartmentName;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.NationalCode;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.FirstName;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.LastName;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.Type.ToString().Replace("_", " ");
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.Username;
                        sheet.Cells[rowIndex, colIndex++].Value = reportItem.RoleName;
                    }

                    using (ExcelRange range = sheet.Cells)
                    {
                        range.Style.Font.SetFromFont(new System.Drawing.Font("Tahoma", 9));
                        range.Style.Font.Bold = true;
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        range.Style.ReadingOrder = ExcelReadingOrder.RightToLeft;
                    }

                    const double minWidth = 0.00;
                    const double maxWidth = 50.00;
                    sheet.Cells.AutoFitColumns(minWidth, maxWidth);

                    bytes = excelPackage.GetAsByteArray();

                }

                return AppCore.Result<byte[]>.Successful(data: bytes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<AppCore.Result<bool>> CheckPermission(Guid commandId)
        {
            var listResult = await _dataSource.GetPermissionsAsync((Guid)_requestInfo.PositionId, commandId);
            if (!listResult.Success)
                return AppCore.Result<bool>.Failure(message: listResult.Message);

            return AppCore.Result<bool>.Successful(data: listResult.Data.Any());
        }

        private async Task<AppCore.Result> _ValidateForSave(Position model)
        {
            var positionType = (int)model.Type;
            if (positionType != 20 && positionType != 21)
            {
                var departmentGetResult = await _departmentDataSource.GetAsync(model.DepartmentID);
                if (!departmentGetResult.Success)
                    return AppCore.Result.Failure(message: departmentGetResult.Message);
                if (departmentGetResult.Data == null)
                    return AppCore.Result.Failure(message: "محل خدمت مورد نظر یافت نشد");
            }
            //var mappingResult = await _positionDepartmentMappingDataSource.ListAsync(new PositionDepartmentMappingListVM { PositionType = model.Type, DepartmentType = departmentGetResult.Data.Type });
            //if (!mappingResult.Success)
            //    return AppCore.Result.Failure(message: mappingResult.Message);

            //if(mappingResult.Data.Any())
            //    return AppCore.Result.Failure(message: "ثبت سمت انتخاب شده برای این محل خدمت امکان پذیر نیست");

            return AppCore.Result.Successful();
        }

    }
}