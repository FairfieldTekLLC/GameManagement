﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GameManager.Models;

public partial class GameManagementContext : DbContext
{
    public GameManagementContext()
    {
    }

    public GameManagementContext(DbContextOptions<GameManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DaysOfWeek> DaysOfWeeks { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GamePlayer> GamePlayers { get; set; }

    public virtual DbSet<GamePlayerStatus> GamePlayerStatuses { get; set; }

    public virtual DbSet<GameType> GameTypes { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerSessionKey> PlayerSessionKeys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=fftsql02;Initial Catalog=GameManagement;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DaysOfWeek>(entity =>
        {
            entity.HasKey(e => e.PkDayOfWeek);

            entity.ToTable("DaysOfWeek");

            entity.Property(e => e.PkDayOfWeek)
                .ValueGeneratedNever()
                .HasColumnName("pkDayOfWeek");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.PkGameId);

            entity.Property(e => e.PkGameId)
                .ValueGeneratedNever()
                .HasColumnName("pkGameId");
            entity.Property(e => e.FkDayOfWeek).HasColumnName("fkDayOfWeek");
            entity.Property(e => e.FkGameTypeId).HasColumnName("fkGameTypeId");
            entity.Property(e => e.Gm).HasColumnName("GM");

            entity.HasOne(d => d.FkDayOfWeekNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.FkDayOfWeek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_DaysOfWeek");

            entity.HasOne(d => d.FkGameType).WithMany(p => p.Games)
                .HasForeignKey(d => d.FkGameTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_GameTypes");

            entity.HasOne(d => d.GmNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.Gm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_Players");
        });

        modelBuilder.Entity<GamePlayer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GamePlayer");

            entity.Property(e => e.FkGameId).HasColumnName("fkGameId");
            entity.Property(e => e.FkGamePlayerStatusId).HasColumnName("fkGamePlayerStatusId");
            entity.Property(e => e.FkPlayerId).HasColumnName("fkPlayerId");
            entity.Property(e => e.JoinDt).HasColumnType("datetime");
            entity.Property(e => e.RequestDt).HasColumnType("datetime");

            entity.HasOne(d => d.FkGame).WithMany()
                .HasForeignKey(d => d.FkGameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GamePlayer_Games");

            entity.HasOne(d => d.FkGamePlayerStatus).WithMany()
                .HasForeignKey(d => d.FkGamePlayerStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GamePlayer_GamePlayerStatus");

            entity.HasOne(d => d.FkPlayer).WithMany()
                .HasForeignKey(d => d.FkPlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GamePlayer_Players");
        });

        modelBuilder.Entity<GamePlayerStatus>(entity =>
        {
            entity.HasKey(e => e.PkGamePlayerStatusId);

            entity.ToTable("GamePlayerStatus");

            entity.Property(e => e.PkGamePlayerStatusId)
                .ValueGeneratedNever()
                .HasColumnName("pkGamePlayerStatusId");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<GameType>(entity =>
        {
            entity.HasKey(e => e.PkGameTypeId);

            entity.Property(e => e.PkGameTypeId)
                .ValueGeneratedNever()
                .HasColumnName("pkGameTypeId");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PkPlayerId);

            entity.Property(e => e.PkPlayerId)
                .ValueGeneratedNever()
                .HasColumnName("pkPlayerId");
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<PlayerSessionKey>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FkPlayerId).HasColumnName("fkPlayerId");
            entity.Property(e => e.IssueDt)
                .HasColumnType("datetime")
                .HasColumnName("issueDt");

            entity.HasOne(d => d.FkPlayer).WithMany()
                .HasForeignKey(d => d.FkPlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerSessionKeys_Players");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}