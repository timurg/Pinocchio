using System.ComponentModel.DataAnnotations;

namespace Pinocchio.Domain;

public class Parent{
    [Key]
    [Required]
    public required string ChatId{get; set;}
    
    public required string UserName{get; set;}
}

