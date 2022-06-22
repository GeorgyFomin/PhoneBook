using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesPhoneBook.Models
{
    public class Phone
    {
        const string phoneNumberPattern =
        //            @"
        //^                  # From Beginning of line
        //(?:\(?)            # Match but don't capture optional (
        //(?<AreaCode>\d{3}) # 3 digit area code
        //(?:[\).\s]?)       # Optional ) or . or space
        //(?<Prefix>\d{3})   # Prefix
        //(?:[-\.\s]?)       # optional - or . or space
        //(?<Suffix>\d{4})   # Suffix
        //(?!\d)             # Fail if eleventh number found";
        @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(30, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        [RegularExpression(phoneNumberPattern), Display(Name ="Phone Number"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(40)] 
        public string Description { get; set; } = string.Empty;
        [Range(1, 100),DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Money { get; set; }
    }
}
