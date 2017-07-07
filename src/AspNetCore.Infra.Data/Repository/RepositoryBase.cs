using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Domain.Interface;
using AspNetCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Infra.Data.Repository {
    public class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class {
        private readonly DbContextOptionsBuilder<AspNetCoreContext> _optionsBuilder;

        public RepositoryBase () {
                _optionsBuilder = new DbContextOptionsBuilder<AspNetCoreContext> ();
            }

            ~RepositoryBase () {
                Dispose (false);
            }

        public void Add (TEntity entitie) {
            using (var banco = new AspNetCoreContext(_optionsBuilder.Options)) {
                banco.Add (entitie);
                banco.SaveChanges ();
            }
        }

        public void Delete (Guid id) {
            using (var banco = new AspNetCoreContext(_optionsBuilder.Options)) {
                var objeto = banco.Set<TEntity> ().Find (id);
                banco.Remove (objeto);
                banco.SaveChanges ();
            }
        }

        public List<TEntity> List () {
            using (var banco = new AspNetCoreContext(_optionsBuilder.Options)) {
                return banco.Set<TEntity> ().ToList ();
            }
        }

        public void Update (TEntity entitie) {
            using (var banco = new AspNetCoreContext(_optionsBuilder.Options)) {
                banco.Update (entitie);
                banco.SaveChanges ();
            }
        }

        public TEntity GetForId (Guid id) {
            using (var banco = new AspNetCoreContext(_optionsBuilder.Options)) {
                return banco.Set<TEntity> ().Find (id);
            }
        }

        public void Dispose () {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        private static void Dispose (bool status) {
            if (!status)
			{
			}
		}

    }
}