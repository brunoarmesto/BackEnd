using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infra.Entity.Contact;
using WebApi.Infra.Interface;
using WebApi.Repository.Data;

namespace WebApi.Domain.BLL
{
    public class AddressBLL : IAddress
    {
        private IAddressRepository _repository;
        public AddressBLL(IAddressRepository repository)
        {
            _repository = repository;
        }

        public Task<List<AddressEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<List<AddressEntity>> GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Task<List<AddressEntity>> GetByIdAddress(int id)
        {
            return _repository.GetByIdAddress(id);
        }
        public void Insert(AddressEntity model, int idPerson)
        {
            if (idPerson == 0)
                throw new System.Exception("It is not possible to add an address without a contact!");

            model.idcontact = idPerson;
            _repository.Insert(model);

        }

        public void Insert(List<AddressEntity> model, int idPerson)
        {
            if (idPerson == 0)
                throw new System.Exception("It is not possible to add an address without a contact!");

            model.ForEach(x => x.idcontact = idPerson);

            _repository.Insert(model);
        }
        public void Update(AddressEntity model)
        {
            _repository.Update(model);
        }

        public void Update(List<AddressEntity> model)
        {
            _repository.Update(model);
        }

        public void Delete(AddressEntity model)
        {
            _repository.Delete(model);
        }

        public void Delete(List<AddressEntity> model)
        {
            _repository.Delete(model);
        }
    }
}
