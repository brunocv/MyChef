using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication3.Models
{
    public partial class LI4DBContext : DbContext
    {
        public LI4DBContext()
        {
        }

        public LI4DBContext(DbContextOptions<LI4DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alergias> Alergias { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuReceita> MenuReceita { get; set; }
        public virtual DbSet<Passo> Passo { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<ReceitaPassoIngrediente> ReceitaPassoIngrediente { get; set; }
        public virtual DbSet<ReceitaReceita> ReceitaReceita { get; set; }
        public virtual DbSet<ReceitaUtensilio> ReceitaUtensilio { get; set; }
        public virtual DbSet<ReceitasFavoritas> ReceitasFavoritas { get; set; }
        public virtual DbSet<RegimeAlimentar> RegimeAlimentar { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Utensilio> Utensilio { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }
        public virtual DbSet<UtilizadorIngrediente> UtilizadorIngrediente { get; set; }
        public virtual DbSet<UtilizadorPassoReceita> UtilizadorPassoReceita { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                System.String curSystem = Environment.MachineName;
                optionsBuilder.UseSqlServer("Server=" + curSystem + ";Database=LI4DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Alergias>(entity =>
            {
                entity.HasKey(e => new { e.Utilizadorid, e.Tipoid })
                    .HasName("PK__Alergias__798A297E9645CD42");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Alergias)
                    .HasForeignKey(d => d.Tipoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAlergias422145");

                entity.HasOne(d => d.Utilizador)
                    .WithMany(p => p.Alergias)
                    .HasForeignKey(d => d.Utilizadorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAlergias942253");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Ingrediente)
                    .HasForeignKey(d => d.Tipoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKIngredient26250");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fim)
                    .HasColumnName("fim")
                    .HasColumnType("datetime");

                entity.Property(e => e.Inicio)
                    .HasColumnName("inicio")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Utilizador)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.Utilizadorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMenu752190");
            });

            modelBuilder.Entity<MenuReceita>(entity =>
            {
                entity.HasKey(e => new { e.Dia, e.Receitaid, e.Menuid })
                    .HasName("PK__Menu_Rec__06778C0EEE3DCE77");

                entity.ToTable("Menu_Receita");

                entity.Property(e => e.Dia)
                    .HasColumnName("dia")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuReceita)
                    .HasForeignKey(d => d.Menuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMenu_Recei706874");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.MenuReceita)
                    .HasForeignKey(d => d.Receitaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMenu_Recei124436");
            });

            modelBuilder.Entity<Passo>(entity =>
            {
                entity.HasKey(e => new { e.Numero, e.Receitaid })
                    .HasName("PK__Passo__27FDD4F1894DFB31");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TempoEstimado).HasColumnName("Tempo_Estimado");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.Passo)
                    .HasForeignKey(d => d.Receitaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPasso258598");
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Dificuldade).HasColumnName("dificuldade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nutricao).HasColumnName("nutricao");

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Receita)
                    .HasForeignKey(d => d.Categoriaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceita193");
            });

            modelBuilder.Entity<ReceitaPassoIngrediente>(entity =>
            {
                entity.HasKey(e => new { e.PassoNumero, e.Ingredienteid, e.PassoReceitaid })
                    .HasName("PK__Receita___00547A316FFC69E9");

                entity.ToTable("Receita_Passo_Ingrediente");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.ReceitaPassoIngrediente)
                    .HasForeignKey(d => d.Ingredienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceita_Pa104487");

                entity.HasOne(d => d.Passo)
                    .WithMany(p => p.ReceitaPassoIngrediente)
                    .HasForeignKey(d => new { d.PassoNumero, d.PassoReceitaid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceita_Pa77458");
            });

            modelBuilder.Entity<ReceitaReceita>(entity =>
            {
                entity.HasKey(e => new { e.Receitaid, e.Receitaid2 })
                    .HasName("PK__Receita___730455488665C676");

                entity.ToTable("Receita_Receita");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.ReceitaReceitaReceita)
                    .HasForeignKey(d => d.Receitaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceita_Re172240");

                entity.HasOne(d => d.Receitaid2Navigation)
                    .WithMany(p => p.ReceitaReceitaReceitaid2Navigation)
                    .HasForeignKey(d => d.Receitaid2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceita_Re167674");
            });

            modelBuilder.Entity<ReceitaUtensilio>(entity =>
            {
                entity.HasKey(e => new { e.Receitaid, e.Utensilioid })
                    .HasName("PK__Receita___878EF32B59F88F3A");

                entity.ToTable("Receita_Utensilio");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.ReceitaUtensilio)
                    .HasForeignKey(d => d.Receitaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceita_Ut813862");

                entity.HasOne(d => d.Utensilio)
                    .WithMany(p => p.ReceitaUtensilio)
                    .HasForeignKey(d => d.Utensilioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceita_Ut281182");
            });

            modelBuilder.Entity<ReceitasFavoritas>(entity =>
            {
                entity.HasKey(e => new { e.Utilizadorid, e.Receitaid })
                    .HasName("PK__Receitas__C95312A6A5D6E7F7");

                entity.ToTable("Receitas_Favoritas");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.ReceitasFavoritas)
                    .HasForeignKey(d => d.Receitaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceitas_F353053");

                entity.HasOne(d => d.Utilizador)
                    .WithMany(p => p.ReceitasFavoritas)
                    .HasForeignKey(d => d.Utilizadorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReceitas_F368283");
            });

            modelBuilder.Entity<RegimeAlimentar>(entity =>
            {
                entity.ToTable("Regime_Alimentar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utensilio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegimeAlimentarid).HasColumnName("Regime_Alimentarid");

                entity.HasOne(d => d.RegimeAlimentar)
                    .WithMany(p => p.Utilizador)
                    .HasForeignKey(d => d.RegimeAlimentarid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUtilizador38477");
            });

            modelBuilder.Entity<UtilizadorIngrediente>(entity =>
            {
                entity.HasKey(e => new { e.Utilizadorid, e.Ingredienteid })
                    .HasName("PK__Utilizad__8C36683B4DA5F65E");

                entity.ToTable("Utilizador_Ingrediente");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.UtilizadorIngrediente)
                    .HasForeignKey(d => d.Ingredienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUtilizador548353");

                entity.HasOne(d => d.Utilizador)
                    .WithMany(p => p.UtilizadorIngrediente)
                    .HasForeignKey(d => d.Utilizadorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUtilizador123697");
            });

            modelBuilder.Entity<UtilizadorPassoReceita>(entity =>
            {
                entity.ToTable("Utilizador_Passo_Receita");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dificuldades)
                    .HasColumnName("dificuldades")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TempoReal).HasColumnName("tempo_real");

                entity.HasOne(d => d.Utilizador)
                    .WithMany(p => p.UtilizadorPassoReceita)
                    .HasForeignKey(d => d.Utilizadorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUtilizador858975");

                entity.HasOne(d => d.Passo)
                    .WithMany(p => p.UtilizadorPassoReceita)
                    .HasForeignKey(d => new { d.PassoNumero, d.PassoReceitaid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUtilizador258619");
            });
        }
    }
}
