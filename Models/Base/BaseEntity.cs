using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTermsMinimalApi.Models.Base
{
    public abstract class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Timestamp] public byte[] TimeStamp { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        [Display(Name = "IS ACTIVE")]
        public bool IsActive { get; set; }

    }
}
