﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Domain;

/// <summary>
/// Ученик
/// </summary>
public sealed class Pupil 
{
    public int Id { get; init; }
    public Class Class { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string MiddleName { get; set; }
    public bool IsDeleted { get; set; }
}