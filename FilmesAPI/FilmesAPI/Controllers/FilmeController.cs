using AutoMapper;
using FilmesApi.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace FilmesApi.Controllers
{
    [ApiController] // Necessário para o Swagger reconhecer como API REST
    [Route("[controller]")] // Define a rota base como /filme
    public class FilmeController : ControllerBase
    {

        private FilmeContext? _context;
        private IMapper _mapper;


        public FilmeController(FilmeContext? context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmesDTo filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges(); 
            return CreatedAtAction(nameof(RecuperaFilmePorID), 
                new { id =filme.Id }, filme);
        }


        /// <summary>
        /// Recupera uma lista de filmes com paginação.
        /// </summary>
        /// <param name="skip">Número de registros a serem ignorados (para paginação).</param>
        /// <param name="take">Número de registros a serem retornados (limite).</param>
        /// <returns>Lista de filmes no formato ReadFilmeDto.</returns>
        /// <response code="200">Filmes retornados com sucesso.</response>
        [HttpGet]
        public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
        }

        /// <summary>
        /// Recupera um filme específico pelo ID.
        /// </summary>
        /// <param name="id">ID do filme a ser buscado.</param>
        /// <returns>Um filme no formato ReadFilmeDto, caso encontrado.</returns>
        /// <response code="200">Filme encontrado com sucesso.</response>
        /// <response code="404">Filme não encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RecuperaFilmePorID(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }


        /// <summary>
        /// Atualiza os dados de um filme existente.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="filmeDto">Dados atualizados do filme.</param>
        /// <returns>Retorna 204 se a atualização for bem-sucedida ou 404 se o filme não for encontrado.</returns>
        /// <response code="204">Filme atualizado com sucesso.</response>
        /// <response code="404">Filme não encontrado.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizaFilme(int id, [FromBody] 
            UpdateFilmeDto filmeDto) 
        {
             var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Atualiza parcialmente os dados de um filme existente.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="patch">Documento JSON Patch contendo as operações de atualização parcial.</param>
        /// <returns>Retorna 204 se a atualização for bem-sucedida, 400 para erros de validação, ou 404 se o filme não for encontrado.</returns>
        /// <response code="204">Filme atualizado parcialmente com sucesso.</response>
        /// <response code="400">Dados inválidos enviados no corpo da requisição.</response>
        /// <response code="404">Filme não encontrado.</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizaFilmeParcial(int id, 
            JsonPatchDocument<UpdateFilmeDto> patch)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();

            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

            patch.ApplyTo(filmeParaAtualizar, ModelState);

            if (!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(filmeParaAtualizar, filme);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Remove um filme do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">ID do filme a ser removido.</param>
        /// <returns>Retorna 204 se a remoção for bem-sucedida ou 404 se o filme não for encontrado.</returns>
        /// <response code="204">Filme removido com sucesso.</response>
        /// <response code="404">Filme não encontrado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();

        }

    }
}

