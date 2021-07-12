using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.ViewModels.Utilities.Slides
{
    public class SlideViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public string Description { set; get; }
        public string Url { set; get; }
        public int SortOrder { get; set; }
    }
}
