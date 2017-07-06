using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AspNetCore.Domain.Interface;
using AspNetCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Infra.Data.Repository {
    public class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class {
        private DbContextOptionsBuilder<AspNetCoreContext> _OptionsBuilder;

        public RepositoryBase () {
                _OptionsBuilder = new DbContextOptionsBuilder<AspNetCoreContext> ();
            }

            ~RepositoryBase () {
                Dispose (false);
            }

        public void Add (TEntity Entitie) {
            using (var banco = new AspNetCoreContext(_OptionsBuilder.Options)) {
                banco.Add (Entitie);
                banco.SaveChanges ();
            };
        }

        public void Delete (Guid Id) {
            using (var banco = new AspNetCoreContext(_OptionsBuilder.Options)) {
                var Objeto = banco.Set<TEntity> ().Find (Id);
                banco.Remove (Objeto);
                banco.SaveChanges ();
            };
        }

        public List<TEntity> List () {
            using (var banco = new AspNetCoreContext(_OptionsBuilder.Options)) {
                return banco.Set<TEntity> ().ToList ();
            };
        }

        public void Update (TEntity Entitie) {
            using (var banco = new AspNetCoreContext(_OptionsBuilder.Options)) {
                banco.Update (Entitie);
                banco.SaveChanges ();
            };
        }

        public TEntity GetForId (Guid id) {
            using (var banco = new AspNetCoreContext(_OptionsBuilder.Options)) {
                return banco.Set<TEntity> ().Find (id);
            };
        }

        public void Dispose () {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        private void Dispose (bool Status) {
            if (!Status) return;
        }

    }
}