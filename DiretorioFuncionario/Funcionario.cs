using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DiretorioFuncionario
{
    class Funcionario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }

        public Funcionario()
        {
        }
        public Funcionario(int id, string nomeCompleto, DateTime dataNascimento, decimal salario)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"{Id,-10} {NomeCompleto,-25} {DataNascimento, -25:dd/MM/yyyy}{Salario.ToString ("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
