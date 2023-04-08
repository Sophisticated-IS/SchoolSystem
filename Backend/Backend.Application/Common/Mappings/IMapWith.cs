using AutoMapper;

namespace Backend.Application.Common.Mappings;
//todo переделать на статический класс сняв ограничение на пустой конструктор без параметров 
public interface IMapWith<T>
{
    void Mapping(Profile profile)=> profile.CreateMap(typeof(T), GetType());
}