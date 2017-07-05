using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interface;


namespace AspNetCore.Infra.Data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoa
    {
        
    }
}