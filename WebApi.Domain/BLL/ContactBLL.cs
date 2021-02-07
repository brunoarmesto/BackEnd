using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infra.Entidade;
using WebApi.Infra.Interface;
using WebApi.Repository.Data;

namespace WebApi.Domain.BLL
{
    public class ContactBLL : IContact
    {
        private IContactRepository _repository;
        private IAddress _address;
        public ContactBLL(IContactRepository repository, IAddress address)
        {
            _repository = repository;
            _address = address;
        }

        public Task<List<ContactEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<ContactEntity> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(ContactEntity model)
        {

            var idperson = _repository.Insert(model);
            if (model.Addresses != null)
                _address.Insert(model.Addresses, idperson);
        }


        public void Update(ContactEntity model)
        {
            _repository.Update(model);
            if (model.Addresses != null)
                foreach (var item in model.Addresses)
                {
                    if (item.idcontact == 0)
                        _address.Insert(model.Addresses, model.idcontact);
                    else
                    { _address.Update(model.Addresses); }
                }
                
        }

        public void Delete(int id)
        {
            var model = _repository.GetById(id).Result;
            _repository.Delete(id, model);
            if (model != null)
                _address.Delete(model.Addresses);
        }

   
    }
}
