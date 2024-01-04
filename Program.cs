using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

string[] nomeHosped;

Console.WriteLine("Informe a capacidade de hospede");
int capacidade =  int.Parse(Console.ReadLine());

Console.WriteLine("Informe o valor da diaria");
decimal valorDiaria = decimal.Parse(Console.ReadLine());

Console.WriteLine("Informe a quantidade de dias a serem reservados");
int dias = int.Parse(Console.ReadLine());	

Console.WriteLine("Quantos hospedes deseja incluir ??");

int qtdHopsdes = int.Parse(Console.ReadLine());


nomeHosped = new string[qtdHopsdes+1];

for (int i = 1; i <= qtdHopsdes; i++)
{
	Console.WriteLine($"Digite o nome do {i}º hospede:");
	nomeHosped[i] = Console.ReadLine();
}


foreach (var nome in nomeHosped)
{
	if (nome != null)
	{
		Pessoa p1 = new Pessoa(nome: nome);
		hospedes.Add(p1);
	}
		
}


// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: capacidade, valorDiaria: valorDiaria);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: dias);
reserva.CadastrarSuite(suite);

	


try
{
	reserva.CadastrarHospedes(hospedes);

	// Exibe a quantidade de hóspedes e o valor da diária
	Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
	Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
}
catch (Exception ex)
{

	Console.WriteLine(ex.Message );
}