using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Infrastructure.DAL
{
    class CommandDataSource : DataSource, Core.DataSource.ICommandDataSource
    {
        public CommandDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {

        }

        private async Task<AppCore.Result<Core.Model.Command>> ModifyAsync(bool isNewRecord, Core.Model.Command model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.ModifyCommandAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _parentID: model.ParentID,
                    _node: model.Node,
                    _applicationID: _requestInfo.ApplicationId,
                    _name: model.Name,
                    _fullName: model.FullName,
                    _title: model.Title,
                    _type: (byte)model.Type,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.Command>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.Command>> CreateAsync(Core.Model.Command model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.Command>> UpdateAsync(Core.Model.Command model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.DeleteCommandAsync(
                        _id: id,
                        _applicationID: _requestInfo.ApplicationId,
                        _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Command>>> ListAsync(Core.Model.CommandListVM model)
        {
            try
            {
                var result = (await _dbORG.GetCommandsAsync(
                        _applicationID: _requestInfo.ApplicationId,
                        _parentID: model.ParentID,
                        _roleID: model.RoleID,
                        _name: model.Name,
                        _title: model.Title,
                        _type: (byte)model.Type
                    )).ToListActionResult<Core.Model.Command>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.Command>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetCommandAsync(
                    _id: id
                    )).ToActionResult<Core.Model.Command>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
