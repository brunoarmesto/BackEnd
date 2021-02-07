using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApi.Model
{
    public class ContactModel
    {
        public int idcontact { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        public string FantasyName { get; set; }
        [Required(ErrorMessage = "Document is required!")]
        public string Document { get; set; }

        [Required(ErrorMessage = "Gender is required!")]
        public string GenderPerson { get; set; }

        [Required(ErrorMessage = "Date of birth is required!")]
        public DateTime DateBirth { get; set; }

        public string TypePerson
        {
            get
            {
                var tamDocument = string.Join("", Document.ToCharArray().Where(Char.IsDigit)).Length;
                if (tamDocument > 11)
                {
                    return "L";
                }
                else
                    return "N";
            }
           
        }

        public List<AddressModel> Addresses { get; set; }
    }
}
