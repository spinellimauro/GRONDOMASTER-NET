using System.Collections.Generic;

public class RegisterViewModel
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public EquipoSoFifaViewModel Equipo { get; set; }

    public RegisterViewModel()
    {
        Equipo = new EquipoSoFifaViewModel();
    }

}