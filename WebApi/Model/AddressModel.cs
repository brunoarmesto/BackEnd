namespace WebApi.Model
{
    public class AddressModel
    {
        public int idaddress { get; set; }
        public int idcontact { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }

        public string ZipCode { get; set; }

    }
}
