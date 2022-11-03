using System;


namespace Phobos.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascUsuario { get; set; }
        public int UsuarioTp { get; set; }
    }
}
