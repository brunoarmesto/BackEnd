using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Infra.Entidade;

namespace WebApi.Infra.Entity.Contact
{
    [Table("tbc_address", Schema = "public")]
    public class AddressEntity
    {
        [Key]
        [Column("idaddress")]
        public int idaddress { get; set; }
        

       
        [Column("country")] 
        public string Country { get; set; }

        [Column("state")] 
        public string State { get; set; }
      
        [Column("city")] 
        public string City { get; set; }
     
        [Column("address")] 
        public string Address { get; set; }

        [Column("complement")]
        public string Complement { get; set; }

        [Column("number")]
        public int Number { get; set; }
        
        [Column("zipcode")]

        public string ZipCode { get; set; }
        
        [Column("idcontact")]
        public int idcontact { get; set; }

    }
}
