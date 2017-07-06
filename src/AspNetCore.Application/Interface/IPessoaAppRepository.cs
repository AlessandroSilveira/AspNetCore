using AspNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Application.Interface
{
    public interface IPessoaAppRepository : IAppRepository<Pessoa>
    {
    }
}
