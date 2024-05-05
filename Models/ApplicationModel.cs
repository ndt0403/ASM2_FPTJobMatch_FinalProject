using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPT_JOBPORTAL
{       
        public enum Status
    {
        Pending,
        Accepted,
        Denied
    }
        public class Application
    {
        [Key]
         public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Education { get; set; }    
        public int JobId { get; set; }    
        public string? Resume { get; set; }
        public Status Status { get; set; }

        [ForeignKey("JobId")]
        public virtual JobModel? Job { get; set; }
    }
}