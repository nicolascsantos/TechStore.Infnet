using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechStore.API.APIModels;
using TechStore.Application.UseCases.Produto.Common;
using TechStore.Application.UseCases.Produto.DeletarProduto;
using TechStore.Application.UseCases.Produto.ListarProdutos;
using TechStore.Application.UseCases.Produto.ObterProdutoPorId;

namespace TechStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(IMediator mediator, ILogger<ProdutoController> logger)
            => (_mediator, _logger) = (mediator, logger);


        [HttpGet("{id::guid}")]
        [ProducesResponseType(typeof(APIResponse<ProdutoOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Obter([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[GET] - GetProdutoPorId");
            var output = await _mediator.Send(new ObterProdutoPorIdInput(id), cancellationToken);
            return Ok(new APIResponse<ProdutoOutput>(output));
        }

        [HttpGet()]
        [ProducesResponseType(typeof(APIResponse<ProdutoOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Listar(CancellationToken cancellationToken)
        {
            _logger.LogInformation("[GET] - ListarTodosProdutos");
            var output = await _mediator.Send(new ListarProdutosInput(), cancellationToken);
            return Ok(new APIResponse<List<ProdutoOutput>>(output));
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(APIResponse<ProdutoOutput>), StatusCode = StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(422, Type = typeof(ProblemDetails), StatusCode = StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoAPIInput produto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[POST] - Criar Produto");
            var output = await _mediator.Send(produto.ToProdutoInput(), cancellationToken);
            return CreatedAtAction(nameof(Criar), new { id = output.Id }, new APIResponse<ProdutoOutput>(output));
        }

        [HttpDelete("{id::guid}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Deletar([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[DELETE] - DeletarProduto");
            var output = await _mediator.Send(new DeletarProdutoInput(id), cancellationToken);
            return NoContent();
        }


        [HttpPut("{id::guid}")]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] AtualizarProdutoAPIInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("[DELETE] - AtualizarProduto");
            var output = await _mediator.Send(request.ToAtualizarProdutoInput(id, request), cancellationToken);
            return Ok(new APIResponse<ProdutoOutput>(output));
        }
    }
}
