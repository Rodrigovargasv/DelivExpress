using DelivExpress.Application.DTOs;
using DelivExpress.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DelivExpress.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // Buscas por todos os produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAsync()
        {
            var listaProdutos = await _produtoService.GetProdutos();
            return Ok(listaProdutos);
        }

        // Busca produto por ID
        [HttpGet("{id}", Name = "getProduto")]
        public async Task<ActionResult> getByIdAsync(int id)
        {
            var produtoDTO = await _produtoService.GetById(id);

            if (produtoDTO == null)
            {
                return NotFound();
            }

            return Ok(produtoDTO);
        }

        // Cria um novo Produto
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProdutoDTO produtoDTO) 
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
           
            await _produtoService.Add(produtoDTO);
            return  new CreatedAtRouteResult("GetProduto", new { id = produtoDTO.Id}, produtoDTO);

        }

        // Atuliza um produto.
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody]ProdutoDTO produtoDTO )
        {

            if (id != produtoDTO.Id)
            {
                return BadRequest(ModelState);
            }

            await _produtoService.Update(produtoDTO);
            return Ok(produtoDTO);
        }

        // Deleta um Produto
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> DeleteAsync(int id)
        {
            var produtoDTO = await _produtoService.GetById(id);
           

            if (produtoDTO == null)
            {
                return NotFound(ModelState);
            }

            await _produtoService.Remove(id);

            return Ok(produtoDTO);

        }
        
    }
}
