namespace AXIS.App.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public int Stock { get; set; } 
    }

}
