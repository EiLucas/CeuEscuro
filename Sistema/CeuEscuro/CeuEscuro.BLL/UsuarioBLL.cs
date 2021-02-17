using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CeuEscuro.DAL;//Inserido manualmente
using CeuEscuro.DTO;//Inserido manualmente

namespace CeuEscuro.BLL
{
    public class UsuarioBLL
    {
        //Instanciando objeto
        UsuarioDAL objBLL = new UsuarioDAL();

        //Cadastrar
        public void CadastrarUsuario(UsuarioDTO objModelo)
        {
            objBLL.Cadastrar(objModelo);
        }

        //Autenticar
        public UsuarioDTO AutenticaUser(string objUser, string objSenha)
        {
            UsuarioDTO user = objBLL.Autentica(objUser, objSenha);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("Usuario inesistente!");
            }
        }

        //Editar
        public void EditaUsuario(UsuarioDTO objModelo)
        {
            objBLL.Editar(objModelo);
        }

        //Excluir
        public void ExcluirUsuario(int objModelo)
        {
            objBLL.Excluir(objModelo);
        }

        //Seleciona
        public UsuarioDTO SelecionaUsuario(int objModelo)
        {
            return objBLL.Seleciona(objModelo);
        }

        //Listar
        public List<UsuarioDTO> ListarUsuario()
        {
            return objBLL.Listar();
        }
    }
}
