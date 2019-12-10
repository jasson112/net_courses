using PieShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Data
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository categoryRepository;
        List<Pie> pies;
        public MockPieRepository(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            pies = new List<Pie> {
                new Pie{
                    id = 1,
                    Name = "Strawberry",
                    Price = 15.95M,
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem Ipsum Lorem Ipsum Lorem Ipsum",
                    AllegryInfo = "Lorem Ipsum",
                    ImgUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg",
                    ImgThumbUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg",
                    OfTheWeek = false,
                    InStock = true,
                    Category = this.categoryRepository.GetCategoryById(1)
                },
                new Pie{
                    id = 2,
                    Name = "Cheese",
                    Price = 18.95M,
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem Ipsum Lorem Ipsum Lorem Ipsum",
                    AllegryInfo = "Lorem Ipsum",
                    ImgUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
                    ImgThumbUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg",
                    OfTheWeek = false,
                    InStock = true,
                    Category = this.categoryRepository.GetCategoryById(1)
                },
                new Pie{
                    id = 3,
                    Name = "Pumpkin",
                    Price = 12.95M,
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem Ipsum Lorem Ipsum Lorem Ipsum",
                    AllegryInfo = "Lorem Ipsum",
                    ImgUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg",
                    ImgThumbUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg",
                    OfTheWeek = false,
                    InStock = true,
                    Category = this.categoryRepository.GetCategoryById(1)
                }
            };
            
        }
        public IEnumerable<Pie> AllPies => from p in pies orderby p.Name select p;

        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public Pie GetPieById(int id)
        {
            return pies.SingleOrDefault( p => p.id == id);
        }
    }
}
