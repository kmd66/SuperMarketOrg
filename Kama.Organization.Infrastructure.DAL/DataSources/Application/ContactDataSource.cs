using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBERROR = Kama.Organization.Core.ErrorKey.General.Database;
using Kama.AppCore;

namespace Kama.Organization.Infrastructure.DAL.DataSources
{
    using model = Core.Model;

    class ContactDataSource : DataSource, Core.DataSource.IContactDataSource
    {
        public ContactDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<AppCore.Result<model.Contact>> CreateAsync(model.Contact contact, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.ModifyContactAsync(
                    _id: contact.ID,
                    _applicationID: _requestInfo.ApplicationId,
                    _name: contact.Name,
                    _email: contact.Email,
                    _tel: contact.Tel,
                    _title: contact.Title,
                    _nationalCode: contact.NationalCode,
                    _content: contact.Content,
                    _log: log?.Value
                    )).ToActionResult<model.Contact>();

                if (result.Success)
                    return await this.GetAsync(contact.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<model.Contact>> SetArchiveAsync(Guid id, bool archived, AppCore.IActivityLog log)
        {
            try
            {
                int archive = archived ? 1 : 2;

                var result = (await _dbAPP.SetArchiveAsync(
                    _id: id,
                  _archiveType: byte.Parse(archive.ToString()),
                    _log: log?.Value
                    )).ToActionResult<model.Contact>();

                if (result.Success)
                    return await this.GetAsync(id);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<model.Contact>> SetNoteAsync(model.Contact contact, AppCore.IActivityLog log)
        {
            try
            {
                var result = (await _dbAPP.SetNoteAsync(
                        _id: contact.ID,
                        _note: contact.Note,
                        _log: log?.Value
                    )).ToActionResult<model.Contact>();

                if (result.Success)
                    return await this.GetAsync(contact.ID);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<IEnumerable<model.Contact>>> ListAsync(model.ContactListVM model)
        {
            try
            {
                var result = (await _dbAPP.GetContactsAsync(
                    _applicationID: _requestInfo.ApplicationId,
                    _title: model.Title,
                    _content: model.Content,
                    _creationDateFrom: model.CreationDateFrom,
                    _creationDateTo: model.CreationDateTo,
                    _archivedType:(byte)model.ArchivedType,
                    _note:model.Note,
                    _pageIndex: model.PageIndex,
                    _pageSize: model.PageSize, 
                    _sortExp: model.SortExp.ToSortExpString()
                )).ToListActionResult<model.Contact>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AppCore.Result<model.Contact>> GetAsync(Guid? Id)
        {
            try
            {
                var result = (await _dbAPP.GetContactAsync(
                        _id: Id
                    )).ToActionResult<model.Contact>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

