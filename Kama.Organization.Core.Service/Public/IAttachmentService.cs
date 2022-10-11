using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kama.Organization.Core.Service
{
    public interface IAttachmentService : IService
    {
        Task<AppCore.Result<Model.Attachment>> AddAsync(Model.Attachment model);

        Task<AppCore.Result<Model.Attachment>> EditAsync(Model.Attachment model);

        Task<AppCore.Result> DeleteAsync(Model.Attachment model);

        Task<AppCore.Result<Model.Attachment>> GetAsync(Guid id);

        Task<AppCore.Result<IEnumerable<Model.Attachment>>> ListAsync(Guid parentId);
    }
}
