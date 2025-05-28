using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class UpdateFilmeDto

{
    public string Titulo { get; set; }

    [StringLength(50, ErrorMessage = "O tamanho do Gênero não pode exceder 50 caracteres.")]
    public string Genero { get; set; }

    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")]
    public int Duracao { get; set; }
}
