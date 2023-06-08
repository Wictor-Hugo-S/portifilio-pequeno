using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();
            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Voce digitou o número inválido");

                }
                opcao = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine("Volte sempre!!!");
            Console.ReadLine();
   
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nehuma série está cadastrada");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                

                Console.WriteLine("#ID {0}: - {1} {2} ", serie.retornaId(), serie.retornaTitulo(),(excluido ? "*Excluido*" : ""));
            }
        }
        private static void InserirSerie()
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano De Início da Série :");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.proximoId(),
                                       genero: (Genero)entradaGenero,
                                       titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);


        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
             Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da série ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite uma descrição ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {  
            Console.WriteLine("Digite o id da série ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
                repositorio.Exclui(indiceSerie);
            

              
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("_______________________");
            Console.WriteLine();
            Console.WriteLine("Seja bem vindo a DIO Séries!!");
            Console.WriteLine("Informe a opcao Desejada");
            Console.WriteLine("1-Listar séries ");
            Console.WriteLine("2-Inserir nova série ");
            Console.WriteLine("3-Atualizar série ");
            Console.WriteLine("4-Excluir série ");
            Console.WriteLine("5-Visualizar série ");
            Console.WriteLine("C-Limpar tela ");
            Console.WriteLine("X- Para sair da tela ");
            Console.WriteLine("_______________________");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine("Sua opção escolhida foi :" + opcao);
            Console.WriteLine("_______________________");
            Console.WriteLine();
            return opcao;
            }
    }
}
