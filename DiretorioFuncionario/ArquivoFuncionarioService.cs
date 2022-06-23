using System;
using System.Collections.Generic;
using System.IO;


namespace DiretorioFuncionario
{
    class ArquivoFuncionarioService : IArquivoFuncionarioService
    {
        public string CaminhoArquivo { get; set; }
        private List<Funcionario> _funcionarios;
        public ArquivoFuncionarioService()
        {
        }

        public ArquivoFuncionarioService(string caminhoArquivo)
        {
            _funcionarios = new List<Funcionario>();
            CaminhoArquivo = caminhoArquivo;
        }
        public List<string> ListaDiretorios()
        {
            List<string> arquivos = new List<string>();
            
            var localizarArquivos = Directory.EnumerateFiles(CaminhoArquivo);
            Console.WriteLine("\nArquivos: ");
            foreach (var arquivo  in localizarArquivos)
            {
                arquivos.Add(Path.GetFileName(arquivo));
            }
            return arquivos;
        }

        public List<Funcionario> ListaFuncionarios()
        {
            var dotNetArquivos = Directory.EnumerateFiles(CaminhoArquivo, "*.IBMDOTNET");
            EncontrarFuncionariosDoArquivo(dotNetArquivos);
            return _funcionarios;
        }

        public void MoverArquivoSucesso(string caminhoArquivo)
        {
            string nomeDoArquivo = Path.GetFileName(caminhoArquivo);
            string diretorioProcessado = $"{CaminhoArquivo}\\PROCESSADOS\\{nomeDoArquivo}";
            File.Move(caminhoArquivo, diretorioProcessado, true);
            Console.WriteLine();
            Console.WriteLine($"Arquivo {Path.GetFileName(caminhoArquivo)} processado com sucesso! Movido para a pasta PROCESSADOS");
        }

        public void MoverArquivoErro(string caminhoArquivo)
        {
            string nomeDoArquivo = Path.GetFileName(caminhoArquivo);
            string diretorioError = $"{CaminhoArquivo}\\ERROR\\{nomeDoArquivo}";
            File.Move(caminhoArquivo, diretorioError, true);
        }
        public void EncontrarFuncionariosDoArquivo(IEnumerable<string> dotNetArquivos)
        {
            foreach (string arquivo in dotNetArquivos)
            {
                ExtrairFuncionariosDoArquivo(arquivo);
            }
        }

        public void ExtrairFuncionariosDoArquivo(string arquivo)
        {
            try
            {
                using (StreamReader novoFuncionario = File.OpenText(arquivo))
                {
                    novoFuncionario.ReadLine();
                    while (!novoFuncionario.EndOfStream)
                    {
                        string[] novoRegistroFuncionario = novoFuncionario.ReadLine().Split(";");
                        Funcionario funcionario = NovoRegistroFuncionario(novoRegistroFuncionario);
                        _funcionarios.Add(funcionario);
                    }
                }
                MoverArquivoSucesso(arquivo);
            }

            catch (FormatException e)
            {
                MoverArquivoErro(arquivo);
                Console.WriteLine();
                Console.WriteLine($"O arquivo {arquivo} esta corrompido: {e.Message}! Arquivo movido para a pasta ERROR");
            }
        }

        public Funcionario NovoRegistroFuncionario(string[] novoRegistroFuncionario)
        {
            int id = int.Parse(novoRegistroFuncionario[0]);
            string nomeCompleto = novoRegistroFuncionario[1];
            DateTime dataNascimento = DateTime.Parse(novoRegistroFuncionario[2]);
            decimal salario = decimal.Parse(novoRegistroFuncionario[3]);
            Funcionario funcionarioExistente = _funcionarios.Find(x => x.Id == id);

            if (funcionarioExistente != null)
            {
                throw new FormatException("Existem registros com o mesmo ID");
            }
            else
            {
                return new Funcionario(id, nomeCompleto, dataNascimento, salario);
            }
        }

    }
}
