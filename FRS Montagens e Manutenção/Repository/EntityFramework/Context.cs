using FRS_Montagens_e_Manutenção.Models;
using Microsoft.EntityFrameworkCore;


namespace Repository.EntityFramework
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
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
                    t.Property(t => t.Id).
                    HasColumnType("int").
                    IsRequired().
                    ValueGeneratedOnAdd();
                    t.HasKey(t => t.Id);

                    t.Property(t => t.Login).
                    HasColumnType("varchar(50)").
                    IsRequired();

                    t.Property(t => t.Senha).
                    HasColumnType("varchar(50)").
                    IsRequired();

                    t.Property(t => t.Nome).
                    HasColumnType("varchar(50)").
                    IsRequired();

                    t.Property(t => t.Email).
                    HasColumnType("varchar(50)").
                    IsRequired();
                    t.HasIndex(t => t.Email).
                    IsUnique();

                    t.Property(t => t.DataNascimento).
                    HasColumnType("date");

                    t.Property(t => t.Uf).
                    HasColumnType("char(2)").
                    IsRequired();

                    t.Property(t => t.Cidade).
                    HasColumnType("varchar(20)").
                    IsRequired();

                    t.Property(t => t.Bairro).
                    HasColumnType("varchar(30)").
                    IsRequired();

                    t.Property(t => t.Rua).
                    HasColumnType("varchar(100)").
                    IsRequired();

                    t.Property(t => t.NResidencia).
                    HasColumnType("varchar(10)").
                    IsRequired();

                    t.Property(t => t.Cep).
                    HasColumnType("varchar(10)").
                    IsRequired();

                    t.Property(t => t.Ativo).
                    HasColumnType("bit").
                    HasDefaultValueSql("true");

                    t.Property(t => t.DataCadastro).
                    HasColumnType("date").
                    HasDefaultValueSql("getdate()");

                    t.HasMany(t => t.Telefones).
                    WithOne(t => t.Pessoas).
                    OnDelete(DeleteBehavior.NoAction);
                }
                );

            modelBuilder.Entity<Telefone>(
                t =>
                {
                    t.Property(t => t.Numero)
                     .HasColumnType("varchar(15)")
                     .IsRequired();
                    t.HasKey(t => new { t.Numero, t.id_pessoas });

                    t.HasOne(t => t.Pessoas)
                     .WithMany(p => p.Telefones)
                     .HasForeignKey(t => t.id_pessoas)
                     .OnDelete(DeleteBehavior.NoAction);

                    t.Property(t => t.Numero)
                     .HasColumnType("varchar(15)")
                     .IsRequired();

                    t.HasCheckConstraint("CK_N_TELEFONE", "LEN(Numero) >= 10 AND LEN(Numero) <= 15 AND Numero LIKE '[0-9]%'");
                }


            );

            modelBuilder.Entity<Cliente>(
                t =>
                {
                    t.ToTable("Clientes");
                    t.Property(t => t.Cnpj).
                    HasColumnType("varchar(14)").
                    IsRequired();
                    t.HasIndex(t => t.Cnpj).IsUnique();

                    t.HasOne(t => t.IdPessoa).
                    WithMany(t => t.ClientesPessoa).
                    OnDelete(DeleteBehavior.NoAction).
                    IsRequired();

                    t.HasOne(t => t.IdFuncionario).
                    WithMany(t => t.ClienteFuncionario).
                    OnDelete(DeleteBehavior.NoAction).
                    IsRequired();
                }
                );

            modelBuilder.Entity<Funcionario>(
                t =>
                {
                    t.ToTable("Funcionarios");
                    t.Property(t => t.Cpf).
                    HasColumnType("varchar(11)").
                    IsRequired();
                    t.HasIndex(t => t.Cpf).IsUnique();

                    t.Property(t => t.Gerente).
                    HasColumnType("bit").
                    IsRequired().
                    HasDefaultValue("false");

                    t.HasOne(t => t.IdPessoa).
                    WithMany(t => t.FuncionarioPessoa).
                    IsRequired().
                    OnDelete(DeleteBehavior.NoAction);

                }
                );

            modelBuilder.Entity<Statu>(
                t =>
                {
                    t.ToTable("Status");
                    t.Property(t => t.Id).HasColumnType("int").
                    IsRequired().
                    ValueGeneratedOnAdd();
                    t.HasKey(t => t.Id);

                    t.Property(t => t.Nome).
                    HasColumnType("varchar(20)").
                    IsRequired();
                }

                );
            modelBuilder.Entity<Pedido>(
                t =>
                {
                    t.ToTable("Pedidos");
                    t.Property(t => t.Id).
                    HasColumnType("int").
                    IsRequired().
                    ValueGeneratedOnAdd();

                    t.Property(t => t.DataInicio).
                    HasColumnType("DATE").
                    IsRequired().
                    HasDefaultValueSql("getdate()");

                    t.Property(t => t.DataTermino).
                    HasColumnType("DATE");

                    t.HasOne(t => t.Funcionario).
                    WithMany(t => t.PedidoFuncionario).
                    IsRequired().
                    OnDelete(DeleteBehavior.NoAction);

                    t.HasOne(t => t.Cliente).
                    WithMany(t => t.PedidoCliente).
                    IsRequired().
                    OnDelete(DeleteBehavior.NoAction);

                    t.HasOne(t => t.Status).
                    WithMany(t => t.PedidoStatu).
                    IsRequired().
                    OnDelete(DeleteBehavior.NoAction);
                }


                );
            modelBuilder.Entity<Topico>(
                t =>
                {
                    t.ToTable("Topicos");
                    t.Property(t => t.Id).
                    HasColumnType("INT").
                    IsRequired().
                    ValueGeneratedOnAdd();

                    t.Property(t => t.DataInicio).
                    HasColumnType("DATE").
                    IsRequired().
                    HasDefaultValueSql("GETDATE()");

                    t.Property(t => t.DataTermino).
                    HasColumnType("DATE");

                    t.HasOne(t => t.Status).
                    WithMany(t => t.Topicos).
                    OnDelete(DeleteBehavior.NoAction);

                    t.HasOne(t => t.Pedido).
                    WithMany(t => t.Topico).
                    OnDelete(DeleteBehavior.NoAction);
                }
                
                
                
                
                
                
                
                );

        }
    }
}
