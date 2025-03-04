using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities;

public class Employee
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "İsim Alanı Zorunludur")]
    [StringLength(100, ErrorMessage = "İsim En Fazla 100 Karakter Olabilir")]
    public string Name { get; set; }
    
    [StringLength(100, ErrorMessage = "Email Alanı En Fazla 100 Karakter Olabilir")]
    [EmailAddress(ErrorMessage = "Email Formatını Doğru Giriniz")]
    [Required(ErrorMessage = "Email Alanı Zorunludur")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Şifre Alanı Zorunludur")]
    public string Password { get; set; }
    
    [StringLength(100, ErrorMessage = "Telefon Numarası En Fazla 100 Karakter Olabilir")]
    public string PhoneNumber { get; set; }
} 