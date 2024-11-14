using System.Collections.Generic;
using System.Reflection.Emit;
using FRS_MONTAGEM_MANUTENÇÕES.Models;
using FRS_Montagens_e_Manutenção.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Topico> Topicos { get; set; }
        public DbSet<SubTopico> SubTopicos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Criação do banco de dados
            // Configuração da entidade Pessoa
            modelBuilder.Entity<Pessoa>(t =>
            {
                t.ToTable("Pessoas");

                t.Property(p => p.Id)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                t.HasKey(p => p.Id);

                t.Property(p => p.Email)
                    .HasColumnType("varchar(50)")
                    .IsRequired();
                t.HasIndex(p => p.Email).IsUnique();

                t.Property(p => p.Nome)
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                t.Property(p => p.Senha)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                t.Property(p => p.Uf)
                    .HasColumnType("char(2)");

                t.Property(p => p.Cidade)
                    .HasColumnType("varchar(30)");

                t.Property(p => p.Bairro)
                    .HasColumnType("varchar(30)");

                t.Property(p => p.Rua)
                    .HasColumnType("varchar(100)");

                t.Property(p => p.NResidencia)
                    .HasColumnType("varchar(5)");

                t.Property(p => p.Cep)
                    .HasColumnType("varchar(8)");

                t.Property(p => p.Ativo)
                    .HasColumnType("bit")
                    .HasDefaultValueSql("1");

                // Relacionamento com Clientes
                t.HasMany(p => p.Clientes)
                    .WithOne(c => c.Pessoa)
                    .HasForeignKey(c => c.PessoaId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relacionamento com Funcionarios
                t.HasMany(p => p.Funcionarios)
                    .WithOne(f => f.Pessoa)
                    .HasForeignKey(f => f.PessoaId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relacionamento com Telefones
                t.HasMany(p => p.Telefones)
                    .WithOne(tel => tel.Pessoa)
                    .HasForeignKey(tel => tel.PessoaId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
            );

            modelBuilder.Entity<Telefone>(t =>
            {
                t.ToTable("Telefones");

                // Define a chave primária composta usando PessoaId e NTelefone
                t.HasKey(tel => new { tel.PessoaId, tel.NTelefone });

                t.Property(tel => tel.PessoaId)
                    .HasColumnType("int")
                    .IsRequired();

                t.Property(tel => tel.NTelefone)
                    .HasColumnType("varchar(15)")
                    .IsRequired();

                // Relacionamento com Pessoa
                t.HasOne(tel => tel.Pessoa)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(tel => tel.PessoaId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Cliente>(t =>
            {
                t.ToTable("Clientes");

                t.Property(c => c.Id)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                t.HasKey(c => c.Id);

                t.Property(c => c.Cnpj)
                    .HasColumnType("varchar(14)")
                    .IsRequired();

                // Relacionamento com Pessoa
                t.HasOne(c => c.Pessoa)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(c => c.PessoaId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relacionamento com Pedidos
                t.HasMany(c => c.Pedidos)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey(p => p.ClienteId)
                    .OnDelete(DeleteBehavior.NoAction);

                t.HasOne(c => c.Funcionario)
                    .WithMany()
                    .HasForeignKey(c => c.FuncionarioId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Funcionario>(t =>
            {
                t.ToTable("Funcionarios");

                t.Property(f => f.Id)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                t.HasKey(f => f.Id);

                t.Property(f => f.Cpf)
                    .HasColumnType("varchar(11)")
                    .IsRequired();

                // Relacionamento com Pessoa
                t.HasOne(f => f.Pessoa)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(f => f.PessoaId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relacionamento com Pedidos
                t.HasMany(f => f.Pedidos)
                    .WithOne(p => p.Funcionario)
                    .HasForeignKey(p => p.FuncionarioId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Pedido>(t =>
            {
                t.ToTable("Pedidos");

                t.Property(p => p.Id)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                t.HasKey(p => p.Id);

                t.Property(p => p.Nome)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                t.Property(p => p.Descricao)
                    .HasColumnType("varchar(500)");

                t.Property(p => p.DataInicio)
                    .HasColumnType("date")
                    .IsRequired();

                t.Property(p => p.DataTermino)
                    .HasColumnType("date");

                // Relacionamento com Cliente
                t.HasOne(p => p.Cliente)
                    .WithMany(c => c.Pedidos)
                    .HasForeignKey(p => p.ClienteId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Relacionamento com Funcionario
                t.HasOne(p => p.Funcionario)
                    .WithMany(f => f.Pedidos)
                    .HasForeignKey(p => p.FuncionarioId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Relacionamento com Topicos
                t.HasMany(p => p.Topicos)
                    .WithOne(t => t.Pedido)
                    .HasForeignKey(t => t.PedidoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Topico>(t =>
            {
                t.ToTable("Topicos");

                t.Property(tp => tp.Id)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                t.HasKey(tp => tp.Id);

                t.Property(p => p.Nome)
                  .HasColumnType("varchar(100)")
                  .IsRequired();

                t.Property(tp => tp.DataInicio)
                    .HasColumnType("date")
                    .IsRequired();

                t.Property(tp => tp.DataTermino)
                    .HasColumnType("date");

                // Relacionamento com Pedido
                t.HasOne(tp => tp.Pedido)
                    .WithMany(p => p.Topicos)
                    .HasForeignKey(tp => tp.PedidoId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Relacionamento com SubTopicos
                t.HasMany(tp => tp.SubTopicos)
                    .WithOne(st => st.Topico)
                    .HasForeignKey(st => st.TopicoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SubTopico>(t =>
            {
                t.ToTable("SubTopicos");

                t.Property(st => st.Id)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                t.HasKey(st => st.Id);

                t.Property(p => p.Nome)
                  .HasColumnType("varchar(100)")
                  .IsRequired();

                t.Property(st => st.DataInicio)
                    .HasColumnType("date")
                    .IsRequired();

                t.Property(st => st.DataTermino)
                    .HasColumnType("date");

                // Relacionamento com Topico 
                t.HasOne(st => st.Topico)
                    .WithMany(tp => tp.SubTopicos)
                    .HasForeignKey(st => st.TopicoId)
                    .OnDelete(DeleteBehavior.NoAction);  
            });

        }
    }
}
