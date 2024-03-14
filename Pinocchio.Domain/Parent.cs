using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pinocchio.Domain;

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
public enum TelegramState {not_set = 0, read_child_name = 1, read_student_file = 2};

public class Parent{
    [Key]
    [Required]
    public required long ChatId{get; set;}
    
    public required string UserName{get; set;}

    public ISet<Child> Children {get;} = new HashSet<Child>();

    /// <summary>
    /// Состояние бота 
    /// </summary>
    /// <value></value>
    public TelegramState TelegramState {get;set;}

    public DateTimeOffset? LastActivityDateTime {get; set;}
}

