using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infra.Data.Data;
using WebApi.Infra.Entity.Contact;

namespace WebApi.Repository.Data
{
    public class AddressRepository : IAddressRepository
    {
        private DataContext _context;
        public AddressRepository(DataContext context)
        {
            _context = context;
        }


        public void Insert(AddressEntity model)
        {
            try
            {
                _context.address.Add(model);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insert(List<AddressEntity> model)
        {
            try
            {
                _context.address.AddRange(model);
                this._context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AddressEntity>> GetById(int id)
        {
            try
            {
                return await this._context.address.AsNoTracking().Where(x => x.idaddress == id).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AddressEntity>> GetByIdAddress(int id)
        {
            try
            {
                return await this._context.address.AsNoTracking().Where(x => x.idcontact == id).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AddressEntity>> GetAll()
        {
            try
            {
                return await this._context.address.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(AddressEntity model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                var result = this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(List<AddressEntity> model)
        {
            try
            {
                foreach (var item in model)
                {
                    _context.Entry(item).State = EntityState.Modified;
                    this._context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(AddressEntity model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Deleted;
                var result = this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(List<AddressEntity> model)
        {
            try
            {
                foreach (var item in model)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                    this._context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
