using System;
using WebApi.Infra.Data.Data;

namespace WebApi.Uow
{
    public class BaseUow : IDisposable
    {
        private DataContext _context;

        public BaseUow(DataContext context)
        {
            _context = context;

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
