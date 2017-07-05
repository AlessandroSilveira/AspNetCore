namespace CursoAspNetCore.Application.App
{
    public class AppEnderecoRepository : IEnderecoAppRepository
    {
        private readonly IEndereco _IEndereco;

        public AppEnderecoRepository(IEndereco IEndereco)
        {
            _IEndereco = IEndereco;
        }


        public void Add(Endereco Entitie)
        {
            _IEndereco.Add(Entitie);
        }

        public void Delete(int Id)
        {
            _IEndereco.Delete(Id);
        }

        public Endereco GetForId(int id)
        {
            return _IEndereco.GetForId(id);
        }

        public List<Endereco> List()
        {
            return _IEndereco.List();
        }

        public void Update(Endereco Entitie)
        {
            _IEndereco.Update(Entitie);
        }
    }
}