using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infra.Entidade;

namespace WebApi.Infra.Interface
{
    public interface IContact
    {
        void Insert(ContactEntity model);
        Task<ContactEntity> GetById(int id);
        Task<List<ContactEntity>> GetAll();
        void Update(ContactEntity model);
        void Delete(int id); 
    }
}
