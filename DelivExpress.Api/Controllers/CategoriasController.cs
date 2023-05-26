using DelivExpress.Application.DTOs;
using DelivExpress.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DelivExpress.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        #region Controladores de busca, atualização e deleção de dados
        // Buscas por todos os produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAllAsync()
        {
            var listaDeCategorias = await _categoriaService.GetCategorias();
            return Ok(listaDeCategorias);
        }

        // Busca produto por ID
        [HttpGet("{id}", Name = "getCategoria")]
        public async Task<ActionResult<CategoriaDTO>> GetByIdAsync(int id)
        {
            var categoriaDto = await _categoriaService.GetById(id);

            if (id == null)
            {
                return NotFound();
            }
            return Ok(categoriaDto);
        }

        // Cria um novo Produto
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CategoriaDTO categoriaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoriaService.Add(categoriaDTO);
            return new CreatedAtRouteResult("GetProduto", new { id = categoriaDTO.Id }, categoriaDTO);

        }

        // Atuliza um produto.
        [HttpPut]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id)
            {
                return BadRequest(ModelState);
            }

            await _categoriaService.Update(categoriaDTO);

            return Ok(categoriaDTO);
        }

        // Deleta um Produto
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaDTO>> DeleteAsync(int id)
        {
            var categoriaDTO = await _categoriaService.GetById(id);

            if (id != categoriaDTO.Id)
            {
                return NotFound(ModelState);
            }

            await _categoriaService.Remove(id);

            return Ok(categoriaDTO);

        }
        #endregion
    }
}
