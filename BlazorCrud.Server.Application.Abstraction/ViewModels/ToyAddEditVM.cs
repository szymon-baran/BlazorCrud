using BlazorCrud.Shared.Dictionaries;

namespace BlazorCrud.Server.Application
{
    public class ToyAddEditVM
    {
        public int? Id { get; set; }
        public string Name { get; set; } = "";
        public ToyType? ToyType { get; set; }
        public int? BrandId { get; set; }
    }
}
