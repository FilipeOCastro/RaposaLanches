using Raposa.Lanches.API.Interfaces;
using Raposa.Lanches.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raposa.Lanches.API.Repository;
using AutoMapper;

namespace Raposa.Lanches.API.Service
{
    public class RaposaLancheService : IService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public RaposaLancheService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
     

        public List<LancheModel> GetAllLanches()
        {
            var result = _repository.GetAllLanches();

            var lanches = _mapper.Map<List<DataBase.Lanche>,
                                      List<LancheModel>>(result);

            return lanches;
        }

        public List<IngredienteModel> GetAllIngredientes()
        {
            var result = _repository.GetAllIngredientes();

            var ingredientes = _mapper.Map<List<DataBase.Ingrediente>,
                                      List<IngredienteModel>>(result);

            return ingredientes;
        }

        public IngredienteModel InsertIngrediente(IngredienteModel ingredienteModel)
        {
            var ingrediente = _mapper.Map<IngredienteModel,
                                          DataBase.Ingrediente>(ingredienteModel);

            var result = _repository.InsertIngrediente(ingrediente);

            return _mapper.Map<DataBase.Ingrediente,
                                          IngredienteModel>(result);
        }

        public void DeleteIngrediente(int id)
        {
            _repository.DeleteIngrediente(id);
        }

        public LancheModel InsertLanche(LancheModel lancheModel)
        {
            var lanche = _mapper.Map<LancheModel,
                                          DataBase.Lanche>(lancheModel);

            var result = _repository.InsertLanchee(lanche);

            _repository.InsertIngredientes(result.ID, lancheModel.IngredientesIds);

            return _mapper.Map<DataBase.Lanche,
                                          LancheModel>(result);
        }

        public void DeleteLanche(int id)
        {
            _repository.DeleteLanche(id);
        }

        public void UpdateIngrediente(IngredienteModel ingredienteModel)
        {
            var ingrediente = _mapper.Map<IngredienteModel,
                                         DataBase.Ingrediente>(ingredienteModel);

            _repository.UpdateIngrediente(ingrediente);
           
        }
    }
}
