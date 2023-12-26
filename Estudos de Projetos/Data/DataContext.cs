using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaCadastroProjeto.Models;

namespace SistemaCadastroProjeto.Data
{

    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Financiamento> Financiamento { get; set; }

        public virtual DbSet<GerenciaGeral> GerenciaGeral { get; set; }

        public virtual DbSet<Gerencia> Gerencia { get; set; }

        public virtual DbSet<Objetivo> Objetivo { get; set; }

        public virtual DbSet<Projeto> Projeto { get; set; }

        public virtual DbSet<Tema> Tema { get; set; }

        public virtual DbSet<TipoFuncao> TipoFuncao { get; set; }

        public virtual DbSet<TipoCargo> TipoCargo { get; set; }

        public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<UsuarioProjeto> UsuarioProjeto { get; set; }

        public virtual DbSet<Arquivo> Arquivo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Projeto_DB;Integrated Security=True").UseLazyLoadingProxies().EnableDetailedErrors();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Financiamento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_Financiamento_pk");

                entity.ToTable("Financiamento");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GerenciaGeral>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_GerenciaGeral_pk");

                entity.ToTable("GerenciaGeral");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gerencia>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_Gerencia_pk");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.IdGerenciaGeral).HasColumnName("Id_GerenciaGeral");
                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGerenciaGeralNavigation).WithMany(p => p.Gerencia)
                    .HasForeignKey(d => d.IdGerenciaGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_GerenciaGeral_fk");
            });

            modelBuilder.Entity<Arquivo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_Arquivo_pk");
                entity.Property(e => e.IdProjeto).HasColumnName("Id_Projeto");
                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProjetoNavigation).WithMany(p => p.LstArquivo)
                   .HasForeignKey(d => d.IdProjeto)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("Id_ArquivoProjeto_fk");
            });

            modelBuilder.Entity<Objetivo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_Objetivo_pk");

                entity.ToTable("Objetivo");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_Projeto_pk");

                entity.ToTable("Projeto");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DataAbertura).HasColumnType("date");
                entity.Property(e => e.IdFinanciamento).HasColumnName("Id_Financiamento");
                entity.Property(e => e.IdObjetivo).HasColumnName("Id_Objetivo");
                entity.Property(e => e.IdTema).HasColumnName("Id_Tema");
                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFinanciamentoNavigation).WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdFinanciamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Financiamento_fk");

                ;

                entity.HasOne(d => d.IdObjetivoNavigation).WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdObjetivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Objetivo_fk");

                entity.HasOne(d => d.IdTemaNavigation).WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Tema_fk");

            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_Tema_pk");

                entity.ToTable("Tema");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoFuncao>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_TipoFuncao_pk");

                entity.ToTable("TipoFuncao");

                entity.Property(e => e.Funcao)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCargo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_TipoCargo_pk");

                entity.ToTable("TipoCargo");
                entity.Property(e => e.Ativo);
                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Id_Usuario_pk");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdTipoCargo).HasColumnName("Id_TipoCargo");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.IdGerencia).HasColumnName("Id_Gerencia");
                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Telefone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGerenciaNavigation).WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGerencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_Gerencia_fk");

                entity.HasOne(d => d.IdTipoCargoNavigation).WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Id_TipoCargo_fk");
            });

            modelBuilder.Entity<UsuarioProjeto>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdProjeto, e.IdTipoFuncao });

                entity.ToTable("UsuarioProjeto");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
                entity.Property(e => e.IdProjeto).HasColumnName("Id_Projeto");
                entity.Property(e => e.IdTipoFuncao).HasColumnName("Id_TipoFuncao");

                entity.HasOne(d => d.IdProjetoNavigation).WithMany(p => p.UsuarioProjetos)
                    .HasForeignKey(d => d.IdProjeto);


                entity.HasOne(d => d.IdTipoFuncaoNavigation).WithMany(p => p.UsuarioProjetos)
                    .HasForeignKey(d => d.IdTipoFuncao);

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioProjetos)
                .HasForeignKey(d => d.IdUsuario);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }  
}
