﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GameManager.Models;

public partial class GameType
{
    public int PkGameTypeId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}