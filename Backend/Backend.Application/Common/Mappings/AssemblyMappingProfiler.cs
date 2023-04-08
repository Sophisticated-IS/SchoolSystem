using System.Reflection;
using AutoMapper;

namespace Backend.Application.Common.Mappings;

internal sealed class AssemblyMappingProfiler : Profile
{
    public AssemblyMappingProfiler(Assembly assembly)
    {
        ApplyMappingFromAssembly(assembly);
    }

    private void ApplyMappingFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
                            .Where(t=>t.GetInterfaces()
                                       .Any(i=>i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(nameof(IMapWith<object>.Mapping));
            methodInfo?.Invoke(instance, new object[] { this});
        }
    } 
}