using Raposa.Lanches.API.Model;
using System.Collections.Generic;

namespace Raposa.Lanches.API.Service
{
    public interface ILanchesService
    {
        List<LancheModel> GetAllLanches();

        LancheModel InsertLanche(LancheModel lancheModel);

        void DeleteLanche(int id);
    }
}