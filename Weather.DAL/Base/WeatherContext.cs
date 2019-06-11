namespace Weather.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Weather.Domain.Model;

    public partial class WeatherContext : DbContext
    {
        #region Construtores
        public WeatherContext()
            : base("WeatherContext")
        {
        }
        #endregion

        #region Propriedades
        public virtual DbSet<Cidade> Cidade { get; set; }

        #endregion

        #region Métodos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilitar o delete em cascata em relacionamentos 1:N evitando
             ter registros filhos     sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Toda propriedade do tipo string na entidade POCO
             seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Entity<Cidade>()
                .Property(c => c.Nome).IsRequired();


        }

        public static WeatherContext Create()
        {
            return new WeatherContext();
        }
        #endregion
    }
}
