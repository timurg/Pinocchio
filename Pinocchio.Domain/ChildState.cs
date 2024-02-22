using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinocchio.Domain;

public enum ChildState {present = 1, not_present = 0};

public class DateChildState
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id {get;set;}

    public required DateOnly StateDate {get; set;}

    public required Child Child {get; set;}

    public ChildState ChildState {get; set;} = ChildState.present;
}
