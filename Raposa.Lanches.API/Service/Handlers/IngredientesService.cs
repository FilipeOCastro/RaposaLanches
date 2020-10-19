using AutoMapper;
using Raposa.Lanches.API.Model;
using Raposa.Lanches.DataBase.Repostitories;
using System.Collections.Generic;

namespace Raposa.Lanches.API.Service.Handlers
{
    public class IngredientesService : IIngredientesService
    {
        private readonly IIngredientesRepository _ingredientesRepository;
        private readonly IMapper _mapper;

        public IngredientesService(IIngredientesRepository ingredientesRepository, IMapper mapper)
        {
            _ingredientesRepository = ingredientesRepository;
            _mapper = mapper;
        }


        public List<IngredienteModel> GetAllIngredientes()
        {
            var result = _ingredientesRepository.GetAllIngredientes();

            var ingredientes = _mapper.Map<List<DataBase.Ingrediente>,
                                      List<IngredienteModel>>(result);

            return ingredientes;
        }

        public IngredienteModel InsertIngrediente(IngredienteModel ingredienteModel)
        {
            var ingrediente = _mapper.Map<IngredienteModel,
                                          DataBase.Ingrediente>(ingredienteModel);

            var result = _ingredientesRepository.InsertIngrediente(ingrediente);

            return _mapper.Map<DataBase.Ingrediente,
                                          IngredienteModel>(result);
        }

        public void DeleteIngrediente(int id)
        {
            _ingredientesRepository.DeleteIngrediente(id);
        }

        public void UpdateIngrediente(IngredienteModel ingredienteModel)
        {
            var ingrediente = _mapper.Map<IngredienteModel,
                                         DataBase.Ingrediente>(ingredienteModel);

            _ingredientesRepository.UpdateIngrediente(ingrediente);

        }
    }
}