using MediatR;

namespace Backend.Application.Queries;

public sealed class GetFilteredTeachersQuery : IRequest<IEnumerable<ApiModels.TeacherWithId>>
{
    public string Name { get; }
    public string SurName { get; }
    public string MiddleName { get;  }

    public GetFilteredTeachersQuery(string name, string surName, string middleName)
    {
        Name = name;
        SurName = surName;
        MiddleName = middleName;
    }
}