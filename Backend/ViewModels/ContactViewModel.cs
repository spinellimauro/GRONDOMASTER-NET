using System.ComponentModel.DataAnnotations;

public class ContactViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(70)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(70)]
    public string LastName { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [Range(1000000000, 9999999999)]
    public int PhoneNumber { get; set; }

    [Required]
    [Range(1, 99999999999)]
    public int CompanyId { get; set; }
    public CompanyViewModel Company { get; set; }
}