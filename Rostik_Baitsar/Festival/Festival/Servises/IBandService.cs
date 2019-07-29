using Festival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival.Servises
{
    public interface IBandService
    {
        Task<List<Band>> GetBands();

        Task<Band> GetBand(int id);
    }
}
