using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.Library.Helper;

namespace Kama.Organization.Infrastructure.DAL
{
    internal class PlaceDataSource : DataSource, Core.DataSource.IPlaceDataSource
    {
        public PlaceDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        private async Task<AppCore.Result<Core.Model.Place>> ModifyAsync(bool isNewRecord, Core.Model.Place model, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.ModifyPlaceAsync(
                    _isNewRecord: isNewRecord,
                    _id: model.ID,
                    _parentID: model.ParentID,
                    _node: model.Node,
                    _type: (byte)model.Type,
                    _name: model.Name,
                    _code: model.Code,
                    _latinName: model.LatinName,
                    _log: log?.Value
                    )).ToActionResult<Core.Model.Place>();

                if (result.Success)
                    return await GetAsync(model.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<AppCore.Result<Core.Model.Place>> CreateAsync(Core.Model.Place model, AppCore.IActivityLog log)
            => ModifyAsync(true, model, log);

        public Task<AppCore.Result<Core.Model.Place>> UpdateAsync(Core.Model.Place model, AppCore.IActivityLog log)
            => ModifyAsync(false, model, log);

        public async Task<AppCore.Result> DeleteAsync(Guid id, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbORG.DeletePlaceAsync(
                    _id: id, 
                    _log: log?.Value
                    )).ToActionResult();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<Core.Model.Place>>> ListAsync(Core.Model.PlaceListVM model)
        {
            try
            {
                var result = (await _dbORG.GetPlacesAsync(
                        _iDs: _objSerializer.Serialize(model.IDs),
                        _parentID: model.ParentID,
                        _type: (byte)model.Type, 
                        _name: model.Name, 
                        _ancestorLevel: model.AncestorLevel
                    )).ToListActionResult<Core.Model.Place>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<Core.Model.Place>> GetAsync(Guid id)
        {
            try
            {
                var result = (await _dbORG.GetPlaceAsync(
                        _id: id
                    )).ToActionResult<Core.Model.Place>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}