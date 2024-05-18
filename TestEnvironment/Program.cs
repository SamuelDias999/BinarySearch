using Infra.CrossCutting.Utils;
using Domain.Models;
using System.Linq;

# region Comparando Objetos

var pessoas = new List<Pessoa>
{
    new Pessoa { Nome = "João", Idade = 20 },
    new Pessoa { Nome = "Maria", Idade = 30 },
    new Pessoa { Nome = "José", Idade = 40 },
    new Pessoa { Nome = "Lucas", Idade = 47 },
    new Pessoa { Nome = "Marcos", Idade = 38 },
    new Pessoa { Nome = "Mateus", Idade = 38 },
    new Pessoa { Nome = "Lucas", Idade = 19 },
    new Pessoa { Nome = "Marcos", Idade = 10 },
    new Pessoa { Nome = "Mateus", Idade = 80 },
    new Pessoa { Nome = "Lucas", Idade = 25 },
    new Pessoa { Nome = "Marcos", Idade = 69 },
    new Pessoa { Nome = "Mateus", Idade = 12 },
    new Pessoa { Nome = "Lucas", Idade = 9 },
    new Pessoa { Nome = "Marcos", Idade = 32 },
    new Pessoa { Nome = "Mateus", Idade = 27 },
    new Pessoa { Nome = "Lucas", Idade = 36 },
    new Pessoa { Nome = "Marcos", Idade = 17 },
    new Pessoa { Nome = "Mateus", Idade = 3 },
};


var funcionario = new Funcionario { Nome = "Lucas", Idade = 36, Cargo = "Gerente" };

var lista = pessoas.OrderBy(p => p.Nome).ThenBy(p => p.Idade).ToList();

var index = SearchBinary.BinarySearchFromArray(
    lista,
    p => new[] { p.Nome, p.Idade.ToString() },
    new[] { funcionario.Nome, funcionario.Idade.ToString() });

if (index.Element == null)
{
    Console.WriteLine("Elemento não encontrado");
}
else
{
    Console.WriteLine($"Nome: {index.Element.Nome} - Idade: {index.Element.Idade} - Tentativas: {index.Steps}");
}


# endregion

# region Comparando Inteiros

List<int> numeros = Enumerable.Range(1, 100000).ToList();

var listaOrdenada = numeros.Order().ToList();

var index2 = SearchBinary.BinarySearch(listaOrdenada, -1);

if (index2.Element == 0)
{
    Console.WriteLine("Não encontrado!");
}
else
{
    Console.WriteLine($"Valor: {index2.Element} - Tentativas: {index2.Steps}");
}

# endregion

# region Comparando Strings
List<string> nomes = new List<string> { "Samuel", "Lucas", "Carlos", "Joice", "Juan"};

var listaOrdenada2 = nomes.Order().ToList();

var index3 = SearchBinary.BinarySearch(listaOrdenada2, "Samuel");

if (index3.Element == null)
{
    Console.WriteLine("Não encontrado!");
}
else
{
    Console.WriteLine($"Valor: {index3.Element} - Tentativas: {index3.Steps}");
}

# endregion