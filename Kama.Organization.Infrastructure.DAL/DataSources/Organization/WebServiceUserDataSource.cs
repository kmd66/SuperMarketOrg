using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class WebServiceUserDataSource : DataSource, Core.DataSource.IWebServiceUserDataSource
    {
        public WebServiceUserDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.WebServiceUser>> ModifyAsync(bool isNewRecord, Core.Model.WebServiceUser model)
        {
            try
            {
                var result = (await _dbORG.ModifyWebServiceUserAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _userName: model.UserName,
                    _password: model.Password,
                    _organID: model.OrganID,
                    _enabled: model.Enabled,
                    _passwordExpireDate: model.PasswordExpireDate,
                    _comment: model.Comment,
                    _creatorID: _requestInfo.UserId
                    )).ToActionResult<Core.Model.WebServiceUser>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.WebServiceUser>> CreateAsync(Core.Model.WebServiceUser model)
            => ModifyAsync(true, model);

        public Task<AppCore.Result<Core.Model.WebServiceUser>> UpdateAsync(Core.Model.WebServiceUser model)
            => ModifyAsync(false, model);

        public async Task<AppCore.Result> DeleteAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.DeleteWebServiceUserAsync(
                    _id: id
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.WebServiceUser>>> ListAsync(Core.Model.WebServiceUserListVM model)
        {
            try
            {
                var result = (await _dbORG.GetWebServiceUsersAsync(
                        _userName: model.UserName,
                        _organID: model.OrganID,
                        _enableState: (byte)model.EnableState,
                        _comment: model.Comment,
                        _pageIndex: model.PageIndex,
                        _pageSize: model.PageSize,
                        _sortExp: null
                    )).ToListActionResult<Core.Model.WebServiceUser>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.WebServiceUser>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetWebServiceUserAsync(
                        _id: id
                    )).ToActionResult<Core.Model.WebServiceUser>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.WebServiceUser>> GetAsync(Core.Model.WebServiceUserGetVM model)
        {
            try
            {
                var result = (await _dbORG.GetWebServiceUserByUserPassAsync(
                        _userName: model.UserName,
                        _password: model.Password
                    )).ToActionResult<Core.Model.WebServiceUser>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}