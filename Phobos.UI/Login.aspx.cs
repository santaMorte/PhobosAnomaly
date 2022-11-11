﻿using Phobos.BLL;//
using Phobos.DTO;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phobos.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
            lblMessage.Font.Size = 50;
        }

        //limpar
        public void Limpar()
        {
            txtNome.Text = txtSenha.Text = string.Empty;
            txtNome.Focus();
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pegando a informacao digitada pelo usuario
                string objNome = txtNome.Text;
                string objSenha = txtSenha.Text;

                //instanciando objeto DTO
                UsuarioAutenticaDTO objModelo = new UsuarioAutenticaDTO();
                UsuarioBLL objValida = new UsuarioBLL();

                objModelo = objValida.AutenticaUsuario(objNome, objSenha);
                if (objModelo !=null)
                {
                    switch (objModelo.UsuarioTp)
                    {
                        case 1:
                            lblMessage.Text = "Admin";
                            Limpar();
                            break;
                            case 2:
                            Response.Redirect("/Pages/ConsultaUser.aspx");
                            //lblMessage.Text = "User";
                            Limpar();
                            break;
                    }
                }
                else
                {
                    lblMessage.Text = "Deu problema Denovo !!";
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Deu Problema denovo !! " + ex.Message;
                Limpar();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}