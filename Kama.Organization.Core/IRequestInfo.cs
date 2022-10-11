
namespace Kama.Organization.Core
{
    public interface IRequestInfo : AppCore.IRequestInfo
    {
        Model.UserType UserType { get; }

        Model.PositionType PositionType { get; }

        Model.DepartmentType DepartmentType { get; }

        ApplicationEnum Application { get; }

    }
}
