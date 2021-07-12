using ShopOnline.Data.EF;
using ShopOnline.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Application.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly EshopDbContext _context;
        
        public SlideService(EshopDbContext context)
        {
            _context = context;
        }
        public async Task<List<SlideViewModel>> GetAll()
        {
            var slide = await _context.slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();
            return slide;
        }
    }
}
