using SQLite;
using System.ComponentModel.DataAnnotations;

namespace PessoasApp.Models;

[Table("People")]
public class Person
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome completo")]
    [MaxLength(120, ErrorMessage = "Nome deve ter até 120 caracteres")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Telefone inválido")]
    [MaxLength(20)]
    public string? Phone { get; set; }

    [MaxLength(20)]
    public string? Document { get; set; }

    [Required(ErrorMessage = "Informe a data de nascimento")]
    public DateTime BirthDate { get; set; } = DateTime.Today;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

