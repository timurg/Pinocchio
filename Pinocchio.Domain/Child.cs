namespace Pinocchio.Domain;

using System;
using System.ComponentModel.DataAnnotations;

public class Child{
    [Key]
    [Required]
    public Guid Id {get; set;}
    
    public required string ChildName {get; set;}

    public Parent? Parent {get;set;}

    public bool Active {get;set;}
}
