using System;
using System.Text;
using Data.Config;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading;

namespace Data.Repositorio
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        public readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                try
                {
                    await data.Set<T>().AddAsync(Objeto);
                    await data.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    throw;
                }
                
            }
        }


      

        public async Task Delete(T Objeto)
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    data.Set<T>().Remove(Objeto);
                    await data.SaveChangesAsync();
                }
            } catch (Exception e) 
            {
                throw;
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    return await data.Set<T>().FindAsync(Id);
                }
            } catch (Exception e) 
            {
                throw;
            }
        }

        public async Task<List<T>> List()
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    return await data.Set<T>().AsNoTracking().ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(T Objeto)
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    data.Set<T>().Update(Objeto);
                    await data.SaveChangesAsync();
                }
            } catch (Exception e) 
            {
                throw;
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion



    }
}
