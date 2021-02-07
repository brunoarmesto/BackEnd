using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infra.Entity.Contact;

namespace WebApi.Infra.Interface
{
    public interface IAddress
    {
        void Insert(AddressEntity model, int idPerson);

        void Insert(List<AddressEntity> model, int idPerson);
        Task<List<AddressEntity>> GetById(int id);
        Task<List<AddressEntity>> GetByIdAddress(int idcontact); 
        Task<List<AddressEntity>> GetAll();
        void Update(AddressEntity model);

        void Update(List<AddressEntity> model);

        void Delete(List<AddressEntity> model);
        void Delete(AddressEntity model);
    }
}
