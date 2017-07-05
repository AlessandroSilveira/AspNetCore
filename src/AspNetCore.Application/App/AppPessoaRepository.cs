namespace CursoAspNetCore.Application.App
{
    public class AppPessoaRepository : IPessoaAppRepository
    {
        private readonly IPessoa _IPessoa;

        public AppPessoaRepository(IPessoa IPessoa)
        {
            _IPessoa = IPessoa;
        }


        public void Add(Produto Entitie)
        {
            _IPessoa.Add(Entitie);
        }

        public void Delete(int Id)
        {
            _IPessoa.Delete(Id);
        }

        public Produto GetForId(int id)
        {
            return _IPessoa.GetForId(id);
        }

        public List<Produto> List()
        {
            return _IPessoa.List();
        }

        public void Update(Produto Entitie)
        {
            _IPessoa.Update(Entitie);
        }
    }
}