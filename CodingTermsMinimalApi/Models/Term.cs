using CodingTermsMinimalApi.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTermsMinimalApi.Models
{
    [Table("Terms", Schema = "entity")]
    public class Term : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
