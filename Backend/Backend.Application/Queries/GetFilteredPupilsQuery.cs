using MediatR;

namespace Backend.Application.Queries;

public sealed class GetFilteredPupilsQuery : IRequest<IEnumerable<ApiModels.PupilWithId>>
{
    public string Name { get; }
    public string SurName { get; }
    public string MiddleName { get;  }

    public GetFilteredPupilsQuery(string name, string surName, string middleName)
    {
        Name = name;
        SurName = surName;
        MiddleName = middleName;
    }
}