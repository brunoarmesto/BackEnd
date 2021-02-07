using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infra.Entity.Contact;

namespace WebApi.Repository.Data
{
    public interface IAddressRepository
    {
        void Insert(AddressEntity model);
        void Insert(List<AddressEntity> model);
        void Update(AddressEntity model);
        void Update(List<AddressEntity> model);
        void Delete(AddressEntity model);
        void Delete(List<AddressEntity> model);
        Task<List<AddressEntity>> GetAll();
        Task<List<AddressEntity>> GetById(int id);
        Task<List<AddressEntity>> GetByIdAddress(int idcontact);
    }
}
