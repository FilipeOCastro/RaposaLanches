using AutoMapper;
using Raposa.Lanches.API.Model;
using Raposa.Lanches.DataBase.Repostitories;
using System.Collections.Generic;

namespace Raposa.Lanches.API.Service.Handlers
{
    public class LanchesService : ILanchesService
    {
        private readonly ILanchesRepository _lancheRepository;
        private readonly IMapper _mapper;

        public LanchesService(ILanchesRepository lancheRepository, IMapper mapper)
        {
            _lancheRepository = lancheRepository;
            _mapper = mapper;
        }


        public List<LancheModel> GetAllLanches()
        {
            var result = _lancheRepository.GetAllLanches();

            var lanches = _mapper.Map<List<DataBase.Lanche>,
                                      List<LancheModel>>(result);

            return lanches;
        }

        public LancheModel InsertLanche(LancheModel lancheModel)
        {
            var lanche = _mapper.Map<LancheModel,
                                          DataBase.Lanche>(lancheModel);

            var result = _lancheRepository.InsertLanche(lanche);

            _lancheRepository.InsertIngredientes(result.ID, lancheModel.IngredientesIds);

            return _mapper.Map<DataBase.Lanche,
                                          LancheModel>(result);
        }

        public void DeleteLanche(int id)
        {
            _lancheRepository.DeleteLanche(id);
        }
    }
}