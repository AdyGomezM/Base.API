using AutoMapper;
using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO;
using Base.Domain.Entities;
using Base.Domain.ViewModels;
using Base.Infraestructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Service.Interfaces.Implementation
{
    public class PersonaService : ServiceBase<Persona, PersonaDTO>, IPersonaService
    {
        private readonly IMapper _mapper;
        private IPersonaRepository _personaRepository;

        public PersonaService(IMapper mapper, IPersonaRepository personaRepository) : base(mapper, personaRepository)
        {
            _mapper = mapper;
            _personaRepository = personaRepository;
        }

        public override async Task<ResponseHelper> InsertAsync(Persona entity)
        {

            ResponseHelper response = new ResponseHelper();
            try
            {

                var existe = await _personaRepository.ExisteNombre(entity.Nombre);

                if (!existe)
                {
                    var result = await _personaRepository.InsertAsync(entity);

                    if (result != 0)
                    {
                        response.Message = $"El elemento {entity.Nombre} fue insertado con éxito.";
                        response.Success = true;
                        // verificación de que entity tiene una propiedad Id y es modificable, si es asi le asignamos el valor de result que traerá el nuevo Id
                        var idProperty = entity.GetType().GetProperty("Id");
                        if (idProperty != null && idProperty.CanWrite)
                        {
                            idProperty.SetValue(entity, result, null);
                        }
                        response.Data = entity;

                    }
                }
                else
                {
                    response.Message = $"El elemento {entity.Nombre} ya existe.";
                }


            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }

    }
}
