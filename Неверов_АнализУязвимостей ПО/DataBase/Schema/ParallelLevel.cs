﻿using System.ComponentModel.DataAnnotations;

namespace Неверов_АнализУязвимостей_ПО.DataBase.Schema;

public sealed class ParallelLevel
{
    [Key] public int Id { get; init; }
    public string Level { get; set; }
}