using System.Collections.Generic;
using System.Threading.Tasks;
using Jokenpo.Api.Controllers.Base;
using Jokenpo.Domain.Commands;
using Jokenpo.Domain.Entities;
using Jokenpo.Domain.Handlers;
using Jokenpo.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jokenpo.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("jokenpos")]
    public class JokenposController : BaseController
    {
        private readonly PlayJokenpoHandler _handler;
        private readonly IJokenpoRepository _jokenpoRepository;

        public JokenposController(PlayJokenpoHandler handler,
                                  IJokenpoRepository jokenpoRepository)
        {
            _handler = handler;
            _jokenpoRepository = jokenpoRepository;
        }

        /// <summary>
        /// Consultar todas as jogadas realizadas
        /// </summary>
        /// <returns>Retorna o objeto de retorno encapsulado no objeto 'data'.</returns>
        /// <response code="200">Retorna o resultado da operação</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="500">Erro interno no servidor</response>
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(DataResult<IEnumerable<JokenpoItem>>), 200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return DataResult(await _jokenpoRepository.GetAll());
        }

        /// <summary>
        /// Realizar uma jogada de Jokenpo
        /// </summary>
        /// <returns>Retorna o objeto de retorno encapsulado no objeto 'data'.</returns>
        /// <response code="200">Retorna o resultado da operação</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="500">Erro interno no servidor</response>
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(DataResult<string>), 200)]
        [HttpPost]
        public async Task<IActionResult> Play(PlayJokenpoCommand command)
        {
            return DataResult(await _handler.Handle(command));
        }
    }
}