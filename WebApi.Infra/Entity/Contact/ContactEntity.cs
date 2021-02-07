using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebApi.Infra.Entity.Contact;

namespace WebApi.Infra.Entidade
{
    [Table("tbc_contact", Schema = "public")]
    public class ContactEntity
    {
        [Key]
        [Column("idcontact")]
        public int idcontact { get; set; }
        [Column("create_date")]
        public DateTime CreateDate { get; set; }
        [Column("alter_date")]
        public DateTime AlterDate { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("document")]
        public string Document { get; set; }

        [Column("gender")]
        public string GenderPerson { get; set; }

        [Column("datebirth")]
        public DateTime DateBirth { get; set; }

        [Column("fantasyname")]
        public string FantasyName { get; set; }

        [Column("typeperson")]
        public string TypePerson { get; set; }

        public List<AddressEntity> Addresses { get; set; }

    }
}
