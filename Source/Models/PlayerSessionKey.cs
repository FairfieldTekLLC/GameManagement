﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GameManager.Models;

public partial class PlayerSessionKey
{
    public int FkPlayerId { get; set; }

    public Guid SessionKey { get; set; }

    public DateTime IssueDt { get; set; }

    public virtual Player FkPlayer { get; set; }
}