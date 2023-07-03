using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VacanteAPP;

public class LastMinute
{
    public int LastMinuteId { get; set; }

    [Required]
    [DisplayName("Numele Vacantei Last Minute")]
    [MaxLength(30, ErrorMessage = "Maximum de litere admise este 30")]
    public string NameLastMinute { get; set; }

    [Required]
    [DisplayName("Display Order")]
    [Range(1, 50, ErrorMessage = "Numarul de afisare trebuie sa fie intre 1-50")]
    public int DisplayOrder { get; set; }

    [Required]
    [DisplayName("Data Vacantei")]
    [DataType(DataType.Date)]
    public DateTime LastMinuteDate { get; set; }

    [Required]
    [DisplayName("Oraș")]
    public string Oras { get; set; }

    [Required]
    [DisplayName("Pret")]
    public decimal Pret { get; set; }

    [Required]
    [MaxLength(200, ErrorMessage = "Descrierea trebuia sa aiba maxim 200 caractere")]
    [DisplayName("Descriere")]
    public string Descriere { get; set; }

    public LastMinute()
    {


    }
}