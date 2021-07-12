using ShopOnline.Data.Enums;

namespace ShopOnline.Data.Entities
{
    public class Slide
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public string Description { set; get; }
        public string Url { set; get; }
        public int SortOrder { get; set; }
        public Status Status { set; get; }
    }
}
