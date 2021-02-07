using WebApi.Infra.Data.Data;
using WebApi.Infra.Interface;

namespace WebApi.Uow
{
    public class ContactUow : BaseUow
    {
        public IContact contact { get; private set; }
        public ContactUow(IContact Contact, DataContext context) : base(context)
        {
            contact = Contact;
        }
    
    }
}
