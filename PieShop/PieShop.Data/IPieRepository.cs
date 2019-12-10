using PieShop.Model;
using System.Collections.Generic;
using System.Text;

namespace PieShop.Data
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int id);
    }
}
