using MySql.Data.MySqlClient;//
using Phobos.DTO;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.DAL
{
    public class UsuarioDAL:Conexao
    {
        //CRUD

        //Create
        public void Cadastrar(UsuarioDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO Usuario (Nome,Email,Senha,DataNascUsuario,UsuarioTp) VALUES (@Nome,@Email,@Senha,@DataNascUsuario,@UsuarioTp)", conn);
                cmd.Parameters.AddWithValue("@Nome", objCad.Nome);
                cmd.Parameters.AddWithValue("@Email", objCad.Email);
                cmd.Parameters.AddWithValue("@Senha",objCad.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuario",objCad.DataNascUsuario);
                cmd.Parameters.AddWithValue("@UsuarioTp",objCad.UsuarioTp);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        //Read
        public List<UsuarioListDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Nome,Email,Descricao FROM Usuario INNER JOIN TipoUsuario ON Usuario.UsuarioTp = TipoUsuario.Id", conn);
                dr = cmd.ExecuteReader();
                //ponteiro - lista vazia
                List<UsuarioListDTO> Lista = new List<UsuarioListDTO>();
                while (dr.Read())
                {
                    UsuarioListDTO obj = new UsuarioListDTO();
                    obj.Nome = dr["Nome"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Descricao = dr["Descricao"].ToString();

                    //adiciar a lista
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar registros !!"+ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Update


    }
}
