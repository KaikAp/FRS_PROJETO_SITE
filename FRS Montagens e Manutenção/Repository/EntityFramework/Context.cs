using FRS_Montagens_e_Manutenção.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Repository.EntityFramework
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){ }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pedido> Pedidos {  get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Statu> status { get; set; }
        public DbSet<Topico> Topicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Criação do banco de dados
            modelBuilder.Entity<Pessoa>(
                t =>
                {
                    t.ToTable("Pessoas");
                    t.Property(t => t.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                    t.HasKey(t => t.Id);
                    t.Property(t => t.Login).HasColumnType("varchar(50)").IsRequired();
                    t.Property(t => t.Senha).HasColumnType("varchar(50)").IsRequired();
                    t.Property(t => t.Nome).HasColumnType("varchar(50)").IsRequired();
                    t.Property(t => t.Email).HasColumnType("varchar(50)").IsRequired();
                    t.Property(t => t.DataNascimento).HasColumnType("time");
                    t.Property(t => t.Uf).HasColumnType("char(2)").IsRequired();
                    t.Property(t => t.Cidade).HasColumnType("varchar(20)").IsRequired();
                    t.Property(t => t.Bairro).HasColumnType("varchar(30)").IsRequired();
                    t.Property(t => t.Rua).HasColumnType("varchar(100)").IsRequired();
                    t.Property(t => t.NResidencia).HasColumnType("varchar(10)").IsRequired();
                    t.Property(t => t.Cep).HasColumnType("varchar(10)").IsRequired();
                    t.Property(t => t.Ativo).HasColumnType("boolean").HasDefaultValue("true");
                    t.Property(t => t.DataCadastro).HasColumnType("time").HasDefaultValue("getdate()");
                }    
                );
            modelBuilder.Entity<Cliente>(
                t =>
                {
                    t.ToTable("Clientes");
                    t.Property(t => t.Cnpj).HasColumnType("varchar(20)").IsRequired();
                    t.HasOne(t => t.IdPessoa).WithOne(t => t.clientes.First()).OnDelete(DeleteBehavior.NoAction).IsRequired();
                    t.HasOne(t => t.IdFuncionario).WithOne(t => t.clientes.First()).OnDelete(DeleteBehavior.NoAction).IsRequired();
                }
                );
        }
    }
}
