using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//Inserido manualmente
using CeuEscuro.DTO;//Inserido manualmente

namespace CeuEscuro.DAL
{
    public class UsuarioDAL : Conexao
    {
        //cadastrar
        public void Cadastrar(UsuarioDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Usuario(NomeUsuario,CpfUsuario,SenhaUsuario,DataNascUsuario,UrlImgUsuario,TipoUsuario) VALUES(@v1,@v2,@v3,@v4,@v5,@v6)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.NomeUsuario);
                cmd.Parameters.AddWithValue("@v2", objCad.CpfUsuario);
                cmd.Parameters.AddWithValue("@v3", objCad.SenhaUsuario);
                cmd.Parameters.AddWithValue("@v4", objCad.DataNascUsuario);
                cmd.Parameters.AddWithValue("@v5", objCad.UrlImgUsuario);
                cmd.Parameters.AddWithValue("@v6", objCad.DescricaoTipoUsuario);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao castrar! " + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        //Autenticar
        public UsuarioDTO Autentica(string objUser, string objSenha)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario=@v1 AND SenhaUsuario=@v2", conn);
                cmd.Parameters.AddWithValue("@v1", objUser);
                cmd.Parameters.AddWithValue("@v2", objSenha);
                dr = cmd.ExecuteReader();

                UsuarioDTO obj = null;//ponteiro
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    obj.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    obj.CpfUsuario = Convert.ToString(dr["CpfUsuario"]);
                    obj.CpfUsuario = Convert.ToString(dr["CpfUsuario"]);
                    obj.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    obj.DataNascUsuario = Convert.ToString(dr["DataNascUsuario"]);
                    obj.UrlImgUsuario = Convert.ToString(dr["UrlImgUsuario"]);
                    obj.DescricaoTipoUsuario = Convert.ToString(dr["TipoUsuario"]);
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Usuario não cadastrado!" + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar
        public void Editar(UsuarioDTO objEditar)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Usuario SET NomeUsuario=@v1,CpfUsuario=@v2,SenhaUsuario=@v3,DataNascUsuario=@v4,UrlImgUsuario=@v5,TipoUsuario=@v6 WHERE IdUsuario=@v7", conn);
                cmd.Parameters.AddWithValue("@v1", objEditar.NomeUsuario);
                cmd.Parameters.AddWithValue("@v2", objEditar.CpfUsuario);
                cmd.Parameters.AddWithValue("@v3", objEditar.SenhaUsuario);
                cmd.Parameters.AddWithValue("@v4", objEditar.DataNascUsuario);
                cmd.Parameters.AddWithValue("@v5", objEditar.UrlImgUsuario);
                cmd.Parameters.AddWithValue("@v6", objEditar.DescricaoTipoUsuario);
                cmd.Parameters.AddWithValue("@v7", objEditar.IdUsuario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar! " + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        //Excluir
        public void Excluir(int objExcluir)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario=@v7", conn);
                cmd.Parameters.AddWithValue("@v7", objExcluir);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir registro! " + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        //Selecionar
        public UsuarioDTO Seleciona(int objSeleciona)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdUsuario, NomeUsuario, CpfUsuario, SenhaUsuario, DataNascUsuario, UrlImgUsuario, DescricaoTipoUsuario FROM Usuario JOIN TipoUsuario ON TipoUsuario = IdTipoUsuario WHERE IdUsuario=@v7", conn);
                cmd.Parameters.AddWithValue("@v7", objSeleciona);
                dr = cmd.ExecuteReader();

                //Ponteiro
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    obj.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    obj.CpfUsuario = Convert.ToString(dr["CpfUsuario"]);
                    obj.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    obj.DataNascUsuario = Convert.ToString(dr["DataNascUsuario"]);
                    obj.UrlImgUsuario = Convert.ToString(dr["UrlImgUsuario"]);
                    obj.DescricaoTipoUsuario = Convert.ToString(dr["DescricaoTipoUsuario"]);
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao pesquisar!" + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<UsuarioDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdUsuario, NomeUsuario, CpfUsuario, SenhaUsuario, DataNascUsuario, UrlImgUsuario, DescricaoTipoUsuario FROM Usuario JOIN TipoUsuario ON TipoUsuario = IdTipoUsuario", conn);
                dr = cmd.ExecuteReader();

                //Criando lista vazia
                List<UsuarioDTO> Lista = new List<UsuarioDTO>();

                //Preenchendo minha lista
                while (dr.Read())
                {
                    UsuarioDTO obj = new UsuarioDTO();
                    obj.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    obj.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    obj.CpfUsuario = Convert.ToString(dr["CpfUsuario"]);
                    obj.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    obj.DataNascUsuario = Convert.ToString(dr["DataNascUsuario"]);
                    obj.UrlImgUsuario = Convert.ToString(dr["UrlImgUsuario"]);
                    obj.DescricaoTipoUsuario = Convert.ToString(dr["DescricaoTipoUsuario"]);
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar", ex);
            }
            finally
            {
                Desconectar();
            }
        }

    }
}
