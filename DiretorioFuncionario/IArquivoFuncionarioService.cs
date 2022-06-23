using System;
using System.Collections.Generic;
using System.Text;

namespace DiretorioFuncionario
{
    interface IArquivoFuncionarioService
    {
        List<string> ListaDiretorios();
        List<Funcionario> ListaFuncionarios();
        void MoverArquivoSucesso(string caminhoDoArquivo);
        void MoverArquivoErro(string caminhoDoArquivo);
    }
}
