using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPT_JOBPORTAL
{
    
    public class JobModel
    {
        [Key]
        public int Id { get; set; }
        public string? NameJob { get; set; }        
        public int CategoryId { get; set; }
        public string? DescriptionJob { get; set; }
        public string? Company { get; set; }
        public DateTime? DatePost { get; set; }
        public double? Salary { get; set; }
        public string? Requirement { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryModel? Category { get; set; }
        
    }
}