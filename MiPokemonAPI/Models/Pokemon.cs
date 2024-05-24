using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPokemonAPI.Models
{
    public class Pokemon
    {
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public List<string> Movimientos { get; set; }
    public string URL { get; set; }
}

}