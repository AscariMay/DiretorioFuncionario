using System;
using System.Collections.Generic;
using System.Text;

namespace DiretorioFuncionario
{
    class GerenciadorDeImpressao
    {
        private IArquivoFuncionarioService _arquivoFuncionarioService;
        public List<Funcionario> Funcionarios { get; set; }

        public GerenciadorDeImpressao()
        {
        }

        public GerenciadorDeImpressao(IArquivoFuncionarioService arquivoFuncionarioService)
        {
            _arquivoFuncionarioService = arquivoFuncionarioService;
            Funcionarios = new List<Funcionario>();
        }

        public void ImprimirListaDiretorios()
        {
            List<string> arquivos = _arquivoFuncionarioService.ListaDiretorios();
            foreach (string arquivo in arquivos)
            {
                Console.WriteLine(arquivo);
            }
        }

        public void ImprimirFuncionarios()
        {
            Funcionarios = _arquivoFuncionarioService.ListaFuncionarios();

            Console.WriteLine();
            if (Funcionarios.Count == 0)
            {
                Console.WriteLine("Não existem funcionários a serem listados!");
            }
            else
            {
                Console.WriteLine("Lista Funcionários: ");
                Console.WriteLine();
                Console.WriteLine("Id ".PadRight(10) + " Nome ".PadRight(25) +  " Data de Nascimento ".PadRight(25) +  " Salario");
                foreach (Funcionario funcionario in Funcionarios)
                {
                    Console.WriteLine(funcionario);
                }
            }
        }
    }
}
