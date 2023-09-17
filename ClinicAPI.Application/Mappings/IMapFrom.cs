using AutoMapper;

namespace ClinicAPI.Application.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
