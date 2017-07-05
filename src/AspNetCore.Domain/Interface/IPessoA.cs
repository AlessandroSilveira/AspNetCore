using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interface;

namespace AspNetCore.Domain.Interface
{

    public interface IPessoa : IRepository<Pessoa>
    {
    }
}
