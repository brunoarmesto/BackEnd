using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infra.Data.Data;
using WebApi.Infra.Entidade;
using WebApi.Infra.Entity.Contact;

namespace WebApi.Repository.Data
{
    public class ContactRepository : IContactRepository
    {
        private DataContext _context;
        public ContactRepository(DataContext context)
        {
            _context = context;
        }


        public int Insert(ContactEntity model)
        {
            try
            {
                _context.contact.Add(model);
                this._context.SaveChanges();
                return model.idcontact;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContactEntity> GetById(int id)
        {
            try
            {
                return (from contact in this._context.contact
                        where contact.idcontact == id
                        select new ContactEntity
                        {
                            idcontact = contact.idcontact,
                            Name = contact.Name,
                            FantasyName = contact.FantasyName,
                            AlterDate = contact.AlterDate,
                            CreateDate = contact.CreateDate,
                            DateBirth = contact.DateBirth,
                            Document = contact.Document,
                            GenderPerson = contact.GenderPerson,
                            Addresses = (from f in this._context.QueryAddress
                                         where f.idcontact == contact.idcontact
                                         select f).ToList()
                        }).First();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ContactEntity>> GetAll()
        {
            try
            {

                return (from contact in this._context.contact
                        select new ContactEntity
                        {
                            idcontact = contact.idcontact,
                            Name = contact.Name,
                            FantasyName = contact.FantasyName,
                            AlterDate = contact.AlterDate,
                            CreateDate = contact.CreateDate,
                            DateBirth = contact.DateBirth,
                            Document = contact.Document,
                            GenderPerson = contact.GenderPerson,
                            Addresses = (from f in this._context.QueryAddress
                                         where f.idcontact == contact.idcontact
                                         select f).ToList()
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(ContactEntity model)
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

        public void Delete(int id, ContactEntity model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Deleted;
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<ContactEntity>> GetByName(string name)
        {
            try
            {
                return await this._context.contact.AsNoTracking().Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
