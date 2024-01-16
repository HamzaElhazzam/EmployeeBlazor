using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudBlazor.Data
{
    public class Commande
    {
    
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Phone(ErrorMessage ="Quantity is number")]
        public int Quantite { get; set; }
        [Required(ErrorMessage = "Price Commande is required")]
        [Phone(ErrorMessage = "Price is number")]
        public int PrixCommande { get; set; }

        public int Id_Employee { get; set; }
        public Employee Employee { get; set; }

        public int Id_Article { get; set; }
        public Article Article { get; set; }
    }
}
