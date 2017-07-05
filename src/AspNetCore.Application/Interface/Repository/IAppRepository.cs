namespace CursoAspNetCore.Application.Interface.Repository
{
    public interface IAppRepository<TEntity> 
    {
         void Add(TEntity Entitie);

        void Update(TEntity Entitie);

        void Delete(int Id);

        List<TEntity> List();

        TEntity GetForId(int id);
    }
}