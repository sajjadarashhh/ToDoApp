using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SajjadArash.ToDoApp.Infrastructure.Common.Exceptions;
using SajjadArash.ToDoApp.Infrastructure.Common.Interfaces;
using SajjadArash.ToDoApp.Infrastructure.ModelSuperBase;
using System.Runtime.CompilerServices;

namespace SajjadArash.ToDoApp.Model
{
    public class ToDoDb : DbContext
    {
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (ChangeTracker.HasChanges())
            {
                var entries = ChangeTracker.Entries().Where(a => a.State != EntityState.Unchanged && a.State != EntityState.Detached);
                var user = this.GetService<ICurrentUser>();
                if (user is null)
                    throw new NotAccessException();
                foreach (var item in entries)
                {
                    var model = (ModelBase)item.Entity;
                    switch (item.State)
                    {
                        case EntityState.Deleted:
                            model.DeletedDate = DateTime.Now;
                            model.DeletedUserId = user.Id;
                            break;
                        case EntityState.Modified:
                            model.UpdatedDate = DateTime.Now;
                            model.UpdatedUserId = user.Id;
                            break;
                        case EntityState.Added:
                            model.CreatedDate = DateTime.Now;
                            model.CreatedUserId = user.Id;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            if (ChangeTracker.HasChanges())
            {
                var entries = ChangeTracker.Entries().Where(a => a.State != EntityState.Unchanged && a.State != EntityState.Detached);
                var user = this.GetService<ICurrentUser>();
                if (user is null)
                    throw new NotAccessException();
                foreach (var item in entries)
                {
                    var model = (ModelBase)item.Entity;
                    switch (item.State)
                    {
                        case EntityState.Deleted:
                            model.DeletedDate = DateTime.Now;
                            model.DeletedUserId = user.Id;
                            break;
                        case EntityState.Modified:
                            model.UpdatedDate = DateTime.Now;
                            model.UpdatedUserId = user.Id;
                            break;
                        case EntityState.Added:
                            model.CreatedDate = DateTime.Now;
                            model.CreatedUserId = user.Id;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
