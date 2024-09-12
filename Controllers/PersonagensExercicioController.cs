using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enum;
using static RpgApi.Models.Enum.ClasseEnum;
using static RpgApi.Models.Personagem;
    

namespace RpgApi.Controllers
{
    [ApiController]
    [Route(V)]
    public class PersonagensExercicioController : ControllerBase
    {
        private const string V = "[controller]";

        public static List<Personagem> Personagens { get; set; } = new List<Personagem>()
        {
            new Personagem(){Id=1, Nome="Frodo", PontosVida=100, Forca=17 ,Defesa=23, Inteligencia= 33, Classe = Models.Enum.ClasseEnum.Cavaleiro },
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=Models.Enum.ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=Models.Enum.ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=Models.Enum.ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=Models.Enum.ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=Models.Enum.ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=Models.Enum.ClasseEnum.Mago },
            new Personagem() { Id = 8, Nome = "waldemir", PontosVida=100, Forca=90, Defesa=50, Inteligencia=70, Classe=Models.Enum.ClasseEnum.Cavaleiro },
        };
    
    [ApiController]
[Route("api/[controller]")]
public class PersonagensController : ControllerBase
{
            private const string V = "1";
            private readonly List<Personagem> _personagens = new List<Personagem>(); // Simulação de banco de dados

    // a) Método GetByNome
    [HttpGet("GetByNome")]
    public IActionResult GetByNome([FromQuery] string nome)
    {
        var personagem = _personagens.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (personagem == null)
        {
            return NotFound(new { Message = "Personagem não encontrado." });
        }
        return Ok(personagem);
    }

    // b) Método GetClerigoMago
    [HttpGet("GetClerigoMago")]
    public IActionResult GetClerigoMago()
    {
        var personagensFiltrados = _personagens
            .Where(static p =>
            {
                //?????
                return p.Classe = Cavaleiro;
            }).OrderByDescending(p => p.PontosVida).ToList();

        return Ok(personagensFiltrados);
    }

    // c) Método GetEstatisticas
    [HttpGet("GetEstatisticas")]
    public IActionResult GetEstatisticas()
    {
        var quantidadePersonagens = _personagens.Count;
        var somatorioInteligencia = _personagens.Sum(p => p.Inteligencia);

        return Ok(new
        {
            QuantidadePersonagens = quantidadePersonagens,
            SomatorioInteligencia = somatorioInteligencia
        });
    }

    // d) Método PostValidacao
    [HttpPost("PostValidacao")]
    public IActionResult PostValidacao([FromBody] Personagem novoPersonagem)
    {
        if (novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
        {
            return BadRequest(new { Message = "Dados inválidos para o personagem." });
        }

        _personagens.Add(novoPersonagem);
        return Ok(novoPersonagem);
    }

    // e) Método PostValidacaoMago
    [HttpPost("PostValidacaoMago")]
    public IActionResult PostValidacaoMago([FromBody] Personagem novoPersonagem)
        {
            //pq não tá indo????
                if ( Personagem = cavaleiro  P.inteligência < 35)
            {
                _personagens.Add(novoPersonagem);
                return Ok(novoPersonagem);
            }

            return BadRequest(new { Message = "O Mago deve ter inteligência de pelo menos 35." });
        }

        // f) Método GetByClasse
        [HttpGet("GetByClasse")]
    public IActionResult GetByClasse([FromQuery] int classeId)
    {
        var personagensPorClasse = _personagens.Where(p => p.Id == classeId).ToList();
        return Ok(personagensPorClasse);
    }
}
    }
}