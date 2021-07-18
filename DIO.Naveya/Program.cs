using System;
using DIO.Naveya.Classes;

namespace DIO.Naveya
{
    class Program
    {
        static AlbumRepositorio repositorio = new AlbumRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarDiscos();
                        break;
                    case "2":
                        InserirDisco();
                        break;
                    case "3":
                        AtualizarDisco();
                        break;
                    case "4":
                        ExcluirDisco();
                        break;
                    case "5":
                        VisualizarDisco();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("A loja Naveya agradece a sua colaboração. Pressione qualquer tecla para fechar a janela.");
            Console.ReadKey();
        }
        
        private static void ListarDiscos()
        {
            Console.WriteLine("Lista de discos disponíveis");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum disco cadastrado!");
                return;
            }

            foreach (var disco in lista)
            {   
                Console.WriteLine("#ID {0}: - {1} - {2} - {3}", disco.retornaId(), disco.retornaTitulo(), disco.retornaArtista(), disco.retornaExcluido());
            }
        }

        public static void InserirDisco()
        {
            Console.WriteLine("Inserir um novo disco");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do disco: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o nome do artista: ");
            string entradaArtista = Console.ReadLine();

            Console.Write("Digite o ano do disco: ");
            int entradaAno = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Midia)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Midia), i));
            }
            Console.Write("Digite o tipo de mídia dentre as opções acima: ");
            int entradaMidia = int.Parse(Console.ReadLine());

            Album novoAlbum = new Album(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        artista: entradaArtista,
                                        ano: entradaAno,
                                        midia: (Midia)entradaMidia);

            repositorio.Insere(novoAlbum);
            Console.WriteLine("Disco inserido com sucesso!");
        }

        private static void AtualizarDisco()
        {
            Console.Write("Digite o id do disco a ser atualizado: ");
            int indiceAlbum = int.Parse(Console.ReadLine());
            Console.WriteLine("Disco selecionado: \n{0}", repositorio.Lista()[indiceAlbum]);

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do disco: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o nome do artista: ");
            string entradaArtista = Console.ReadLine();

            Console.Write("Digite o ano do disco: ");
            int entradaAno = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Midia)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Midia), i));
            }
            Console.Write("Digite o tipo de mídia dentre as opções acima: ");
            int entradaMidia = int.Parse(Console.ReadLine());

            Album atualizaAlbum = new Album(id: indiceAlbum,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        artista: entradaArtista,
                                        ano: entradaAno,
                                        midia: (Midia)entradaMidia);

            repositorio.Atualiza(indiceAlbum, atualizaAlbum);
            Console.WriteLine("Disco atualizado com sucesso!");
        }

        private static void ExcluirDisco()
        {
            Console.Write("Digite o id do disco a ser excluído: ");
            int indiceAlbum = int.Parse(Console.ReadLine());
            Console.WriteLine("Disco selecionado: \n{0}", repositorio.Lista()[indiceAlbum]);

            Console.Write("Você tem certeza que deseja excluir este disco? Aperte 'S' para SIM: ");
            char opcaoUsuario = char.Parse(Console.ReadLine().ToUpper());

            if (opcaoUsuario == 'S')
            {
                repositorio.Exclui(indiceAlbum);
                Console.WriteLine("Album excluído com sucesso.");
            }
        }

        private static void VisualizarDisco()
        {
            Console.Write("Digite o id do disco: ");
            int indiceAlbum = int.Parse(Console.ReadLine());

            var album = repositorio.RetornaPorId(indiceAlbum);

            Console.WriteLine(album);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Loja de discos Navêya");

            Console.WriteLine("1 - Lista de discos disponíveis");
            Console.WriteLine("2 - Inserir novo disco");
            Console.WriteLine("3 - Atualizar informações de disco");
            Console.WriteLine("4 - Excluir disco");
            Console.WriteLine("5 - Visualizar discos cadastrados");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();
            Console.Write("Informe a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
