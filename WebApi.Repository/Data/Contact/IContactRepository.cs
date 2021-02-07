using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infra.Entidade;

namespace WebApi.Repository.Data
{
    public interface IContactRepository
    {
        int Insert(ContactEntity model);
        Task<ContactEntity> GetById(int id);
        Task<List<ContactEntity>> GetByName(string name);
        Task<List<ContactEntity>> GetAll();
        void Update(ContactEntity model);
        void Delete(int id, ContactEntity model);
    }
}
