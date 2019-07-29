using Festival.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festival.Servises
{
    public interface IBandService
    {
        Task<List<Band>> GetBands();

        Task<Band> GetBand(int id);
    }
}
