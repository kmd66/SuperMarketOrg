using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Organization.Domain
{
    using model = Core.Model;

    class CommandService : Service<Core.DataSource.ICommandDataSource>, Core.Service.ICommandService
    {
        public CommandService(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<Core.Model.Command>> AddAsync(Core.Model.Command model)
        {
            var validateResult = await _ValidateAsync(model);
            if (!validateResult.Success)
                return validateResult;

            var nameResult = await _CreateFullName(model);
            if (!nameResult.Success)
                return nameResult;
            model = nameResult.Data;

            model.ID = Guid.NewGuid();
            return await _dataSource.CreateAsync(model, null);
        }

        public async Task<AppCore.Result<Core.Model.Command>> EditAsync(Core.Model.Command model)
        {
            var validateResult = await _ValidateAsync(model);
            if (!validateResult.Success)
                return validateResult;

            var nameResult = await _CreateFullName(model);
            if (!nameResult.Success)
                return nameResult;
            model = nameResult.Data;

            return await _dataSource.UpdateAsync(model, null);
        }

        public Task<AppCore.Result> DeleteAsync(Guid id)
        {
            return _dataSource.DeleteAsync(id, null);
        }

        public Task<AppCore.Result<IEnumerable<model.Command>>> ListAsync(Core.Model.CommandListVM model)
            => _dataSource.ListAsync(model);

        public Task<AppCore.Result<model.Command>> GetAsync(Guid id)
            => _dataSource.GetAsync(id);

        private async Task<AppCore.Result<Core.Model.Command>> _ValidateAsync(Core.Model.Command model)
        {
            if (model.ParentID != Guid.Empty && model.ParentID == model.ID)
                return AppCore.Result<Core.Model.Command>.Failure(message: "مقدار وارد شده برای فیلد پدر مورد قبول نیست");

            if (model.ID != Guid.Empty)
            {
                var commandListVM = new Core.Model.CommandListVM();
                commandListVM.ParentID = model.ID;
                var listResult = await ListAsync(commandListVM);
                if (!listResult.Success)
                    return AppCore.Result<Core.Model.Command>.Failure(message: "خطا در بازیابی اطلاعات");
                if (listResult.Data.Count(x => x.ID == model.ParentID) > 0)
                    return AppCore.Result<Core.Model.Command>.Failure(message: "مقدار وارد شده در فیلد پدر مورد قبول نیست");
            }

            return AppCore.Result<Core.Model.Command>.Successful();
        }

        private async Task<AppCore.Result<Core.Model.Command>> _CreateFullName(Core.Model.Command model)
        {
            if (model.Type == Core.Model.CommandType.App
                || model.Type == Core.Model.CommandType.Menu
                || model.Type == Core.Model.CommandType.Page
                )
            {
                model.FullName = model.Name;
            }
            else
            {
                var listResult = await ListAsync(new model.CommandListVM { });
                if (!listResult.Success)
                    return AppCore.Result<Core.Model.Command>.Failure(message: "خطا در بازیابی اطلاعات");

                var parents = listResult.Data
                    .Where(p => p.Type != Core.Model.CommandType.App && p.Type != Core.Model.CommandType.Menu && model.ParentNode.Contains(p.Node))
                    .OrderBy(p => p.Node)
                    .ToList();

                var fullName = "";
                foreach (var parent in parents)
                {
                    if (parent.Type == Core.Model.CommandType.Page)
                        fullName = parent.Name;
                    else
                        fullName += parent.Name;
                }

                model.FullName = fullName + model.Name;
            }

            return AppCore.Result<Core.Model.Command>.Successful(data: model);
        }

    }
}
