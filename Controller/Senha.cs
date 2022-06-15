using System;
using System.Collections.Generic;
using System.Text;


namespace Projeem.Controller
{
    #region >> Classe Senha: Agregada de Usuario;
    public class Senha
    {
        String pwdCripty;

        int num_digito;
        String senha;
        Encoding ascii = Encoding.ASCII;
        Byte[] newSenha = new Byte[8];

        public Senha()
        {
        }
        public void Encripty(String pwd)
        {

            Num_digito = pwd.Length;
            senha = pwd.ToUpper();

            #region TODO: GetBytes Comments
            /* 
             * Criar um array de tipo byte para 
             * armazenar a senha, atravéz do método
             * GetBytes(str) do obj Encoding, com sua propriedade .ASCII;
             */
            #endregion

            Byte[] bSenha = ascii.GetBytes(senha);
            int k = 0;
            int j = 0;
            // Navegar dentro do array recolhendo
            // cada byte (b) do array da senha (bSenha);
            foreach (Byte b in bSenha)
            {
                j = ((b * 2) - 40) + 3;
                newSenha[k] = (byte)j;
                k++;
            }

            PwdCripty = Decripty();
        }

        public String Decripty()
        {
            String decodedString = ascii.GetString(newSenha);
            return decodedString;
        }
        public String PwdCripty
        {
            get { return pwdCripty; }
            set { pwdCripty = value; }
        }
        private int Num_digito
        {
            get { return num_digito; }
            set { num_digito = value; }
        }

    }
    #endregion
}
