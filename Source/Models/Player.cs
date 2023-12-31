﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GameManager.Models;

public partial class Player
{
    public int PkPlayerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<PlayerSessionKey> PlayerSessionKeys { get; set; } = new List<PlayerSessionKey>();
}