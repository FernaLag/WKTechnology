namespace WKTechnology.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public string ModificadoPor { get; set; }

        public BaseEntity()
        {
            CriadoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
            ModificadoPor = string.Empty;
        }
    }
}