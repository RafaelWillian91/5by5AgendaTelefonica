Console.WriteLine("******* Programa de Agenda telefônica *********");


string path = @"C:\dev\";
string file = "listaTelefonica";
List<Pessoa> contacts = new List<Pessoa>();



void iniciarAgenda()
{
    Console.WriteLine("1 - Adicionar contato telefônico: ");
    Console.WriteLine("2 - Mostrar contatos telefonicos: ");
    //Console.WriteLine("3 - Adicionar Genêro da pessoa: ");
    int response = int.Parse(Console.ReadLine());

    switch (response)
    {
        case 1:
            addContact();
            break;

        case 2:
            mostrarContatos();
            break;
    }

}


void addContact()
{
    Console.WriteLine("Entre com o nome da Pessoa: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Entre com o número de telefone: ");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine("Entre com o gênero: ");
    char gender = char.Parse(Console.ReadLine());

    Pessoa p = new Pessoa(nome, number, gender);
    
    //No arquivo temos string e não objetos
    string linha;

    if (File.Exists(file)) {

        StreamReader sr = new StreamReader(path + file);
        //le todo o arquivo e adiciona na lista
        while ((linha = sr.ReadLine()) is not null)
        {
            string[] aux = linha.Split(",");

            Pessoa pessoa = new Pessoa(
                aux[0],
                int.Parse(aux[1]),
                char.Parse(aux[2]));

            contacts.Add(pessoa);
        }
        sr.Close();
    }
        contacts.Add(p);
        StreamWriter sw = new StreamWriter(path + file);
        
        foreach (Pessoa pessoa in contacts)
         {
            sw.WriteLine($"{pessoa.name},{pessoa.number},{pessoa.gender}" );
            
         }
            sw.Close();
}

void mostrarContatos()
{
    Console.WriteLine("******* Contatos telefônicos *******");

    if (File.Exists(path + file))
    {
        StreamReader sr = new StreamReader(path + file);
        string linha;

        while ((linha = sr.ReadLine()) is not null)
        {
            string[] aux = linha.Split(",");

            Pessoa pessoa = new Pessoa(
                aux[0],
                int.Parse(aux[1]),
                char.Parse(aux[2]));

            Console.WriteLine($"Nome: {pessoa.name}");
            Console.WriteLine($"Telefone: {pessoa.number}");
            Console.WriteLine($"Gênero: {pessoa.gender}");
            Console.WriteLine("--------------------");
        }

        sr.Close();
    }
    else
    {
        Console.WriteLine("Nenhum contato cadastrado.");
    }
}
iniciarAgenda();