using System.ComponentModel.DataAnnotations;

namespace FPT_JOBPORTAL
{
    public enum CategoryStatus
    {
        Pending,
        Active,
        Denied
    }
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryStatus Status { get; set; }
    }
}