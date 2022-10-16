using BlazorCrud.Shared.Dictionaries;

namespace BlazorCrud.Shared.Domain
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ToyType ToyType { get; set; }
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}