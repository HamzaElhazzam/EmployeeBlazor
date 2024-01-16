using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudBlazor.Data
{
    public class Article
    {

        public int Id { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Marque { get; set; }
        [Required]
        
        public int Prix { get; set; }
    }
}
