using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pinocchio.Domain;

public class Parent{
    [Key]
    [Required]
    public required string ChatId{get; set;}
    
    public required string UserName{get; set;}

    public ISet<Child> Children {get;} = new HashSet<Child>();
}

