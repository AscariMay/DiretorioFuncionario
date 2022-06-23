using System;
using System.IO;
using System.Collections.Generic;

namespace DiretorioFuncionario
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminho;

            Console.Write("Digite o caminho desejado: ");
            caminho = Console.ReadLine();

            GerenciadorDeImpressao impressao = new GerenciadorDeImpressao(new ArquivoFuncionarioService(caminho));

            try
            {
                impressao.ImprimirListaDiretorios();
                impressao.ImprimirFuncionarios();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine();
                Console.WriteLine("Diretorio nao localizado");
            }
        }
    }
}
