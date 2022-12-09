namespace jogo_da_forca
{
    internal class Forca
    {
        public static int cabecalho()
        {
            //DECLARACAO DE VARIAVEIS 
            int opcao = 0;
            bool verificacao = false;

            string jogar, tema;

            do
            {
                Console.WriteLine("==========Bem -vindo a jogo da força!!!==========");
                Console.WriteLine("00000000000    0        0000000       0\n     0       0   0     0            0   0\n     0       0   0    0   0000000   0   0\n 0   0       0   0     0        0   0   0\n   0           0         0 0 0 0      0\n============================================\n\t\t0000      0\n  \t\t0   0    000\n\t\t0000\t0   0\n============================================\n                  +---+\n                  |   |\n                  O   |\n                 /|\\  |\n                 / \\  |\n                      |\n                  =========");
                Console.WriteLine("Vamos jogar?(S\\N)");

                jogar = Console.ReadLine().ToUpper();
                if (jogar != "S" && jogar != "N")
                {
                    Console.WriteLine("ERRO!Digite somente 'S' para sim e 'N' para não \n Pressione qualquer tecla para recomecar  ");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (jogar != "S" && jogar != "N");


            if (jogar == "S")
            {
                Random randomico = new Random();


                do
                {
                    Console.WriteLine("Deseja escolher o tema ?(S\\N)");


                    tema = Console.ReadLine().ToUpper();

                    if (tema != "S" && tema != "N")
                    {
                        Console.WriteLine("ERRO!Digite somente 'S' para sim e 'N' para não \n Pressione qualquer tecla para recomecar  ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                } while (tema != "S" && tema != "N");
                if (tema == "S")
                {
                    do
                    {
                        Console.WriteLine("Selecione um tema :\n 1 - Fruta \n 2 - Animais \n 3 - Paises \n  ");
                        verificacao = int.TryParse(Console.ReadLine(), out opcao);
                        if (verificacao != true)
                        {
                            Console.WriteLine("ERRO!!Por favor digite somente o numero da opcao!\nAperte Enter para continuar!");
                            Console.ReadKey();
                            Console.Clear();

                        }
                    } while (verificacao != true && (opcao >= 4));
                }
                else
                {
                    opcao = randomico.Next(1, 4);
                }
                return opcao;
            }
            else
            {
                return -1;
            }
        }





        public static char[] esconde(string palavra, char letra_usuario, char[] palavra_escondida)
        {


            int i = 0;
            foreach (char letra in palavra)
            {
                if (letra_usuario == letra)
                {
                    palavra_escondida[i] = letra_usuario;
                }
                else
                {
                    if (palavra_escondida[i] == '_')
                    {
                        palavra_escondida[i] = '_';
                    }

                }
                i++;
            }
            return palavra_escondida;


        }
        public static bool errou(string palavra, char letra_usuario)
        {

            bool contem = palavra.Contains(letra_usuario);

            return contem;

        }
        public static string palavra(int opcao)
        {
            Random randomico = new Random();
            int numero;
            numero = randomico.Next(1, 5);
            string[] frutas = new string[5] { "morango", "melancia", "abacaxi", "laranja", "tomate" };
            string[] animais = new string[5] { "cachorro", "cobra", "girafa", "lobo", "tamandua" };
            string[] paises = new string[5] { "inglaterra", "alemanha", "brasil", "mexico", "senegal" };
            if (opcao == 1)
            {
                return frutas[numero];
            }
            else if (opcao == 2)
            {
                return animais[numero];
            }
            else
            {
                return paises[numero];
            }

        }
        public static string dica(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    return "Frutas";
                    break;
                case 2:
                    return "Animais";
                    break;
                case 3:
                    return "Paises";
                    break;
                defeult:
                    return "";

            }
            return "";
        }
        public static int acabou(char[] lst_palavra)
        {
            int cont = 0;
            foreach (char elemento in lst_palavra)
            {
                if (elemento == '_')
                {
                    cont++;
                }
            }

            return cont;
        }
        public static int Quantidade_Tentativas_restantes(char[] lst_letra_errada)
        {
            int quant = 0, cont = 0;
            foreach (char elemento in lst_letra_errada)
            {
                if (elemento != ' ')
                {
                    cont++;
                }

            }

            quant = 7 - cont;

            return quant;
        }
        public static char[] vetor_letra_errada(char letra, string palavra, int i, char[] lst)
        {


            bool verificacao = errou(palavra, letra);
            if (verificacao == false)
            {
                lst[i] = letra;

            }
            return lst;
        }
        public static string verificacao_letra_existe(string letra, char[] letra_digitadas)
        {
            bool verifica_letra_digitada = false, verificaseLetra = false;
            int cont = 0;


            do
            {

                if (verifica_letra_digitada == true)
                {
                    Console.Write("Digite a letra desejada:");
                    letra = Console.ReadLine().ToLower();

                }
                do
                {
                    try
                    {


                        verificaseLetra = Char.IsLetter(char.Parse(letra));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Digitou algo que não é uma letra!");

                    }
                    if (verificaseLetra)
                    {
                        cont++;
                    }

                    if (letra.Length != 1 || cont == 0)
                    {


                        Console.WriteLine("Digite apenas uma letra ");
                        Console.Write("Digite a letra desejada:");
                        letra = Console.ReadLine().ToLower();
                    }



                } while (letra.Length != 1 || cont == 0);
                int contador = 0;
                foreach (char elemento1 in letra_digitadas)
                {
                    if (elemento1 == char.Parse(letra))
                    {
                        Console.WriteLine("Letra ja digitada por favor digite outra");
                        contador++;

                    }


                }
                if (contador != 0)
                {
                    verifica_letra_digitada = true;
                }
                else
                {
                    verifica_letra_digitada = false;
                }



            } while (verifica_letra_digitada == true);


            return letra;


        }

        public static char[] vetor_letras_totais(char letra, int j, char[] lst)
        {
            lst[j] = letra;

            return lst;
        }
        public static void Creditos()
        {

            Console.WriteLine("Créditos");
            Console.WriteLine("\n\n");
            Console.WriteLine("Gustavo Matos");
            Console.WriteLine("\n\n");
            Console.WriteLine("Nélia Simas");
            Console.WriteLine("\n\n");
            Console.WriteLine("Rhuan Henrique");
            Console.ReadKey();

        }
        public static void tabuleiro(int posicao)
        {

            string[] tabuleiro = new string[7] { "\n+---+\n|   |\n    |\n    |\n    |\n    |\n=========", "+---+\n|   |\nO   |\n    |\n    |\n    |\n=========", "+---+\n|   |\nO   |\n|   |\n    |\n    |\n=========", " +---+\n |   |\n O   |\n/|   |\n     |\n     |\n=========", " +---+\n |   |\n O   |\n/|\\  |\n     |\n     |\n=========", " +---+\n |   |\n O   |\n/|\\  |\n/    |\n     |\n=========", " +---+\n |   |\n O   |\n/|\\  |\n/ \\  |\n     |\n=========" };
            Console.WriteLine(tabuleiro[posicao]);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0, contador = 0;
            //O cabecalho é o inicio do codigo, essa funcao retorno o numero a opcao que o usuario selecionou.
            int x = Forca.cabecalho();
            Console.Clear();
            //O metodo Forca.palavra sorteia uma palavra de acordo com tema selecionado pelo usuario.

            string palavra = Forca.palavra(x);
            //Declaração da lista de letras totais 
            char[] lst_letras_totais = new char[7 + palavra.Length];

            //Declaração da lista de letras erradas
            char[] lst_letra_errada = new char[7];
            //povoando a lista de letras erradas erradas
            for (int posicao = 0; posicao < 7; posicao++)
            {
                lst_letra_errada[posicao] = ' ';

            }
            //Declara uma lista que sera utilizada para armazenar as letras da palavra, poderia ter feito pela propria string , mas desse jeito fica mais facil de manipular acredite
            char[] lst_palavra = new char[palavra.Length];
            //Povoa inicialmente a lista com o caracter com "_" para que o usuario tenha nocao do tamanho da palavra
            for (int tam = 0; tam < palavra.Length; tam++)
            {
                lst_palavra[tam] = '_';
            }
            char letra = ' ';
            //acabou é uma variavel que verifica se o jogador acabou o jogo 
            int acabou;
            lst_palavra = Forca.esconde(palavra, letra, lst_palavra);
            if (x != -1)
            {
                do
                {
                    //tabuleiro mostra o desenho da forca que é atualizado caso o usuario erre uma letra 
                    Forca.tabuleiro(i);
                    //forca.dica mostra o tema da palavra a ser adivinhada
                    Console.WriteLine($"Dica: {Forca.dica(x)}");
                    //Mostra a lista de caracteres que formam a palavra
                    for (int j = 0; j < palavra.Length; j++)
                    {
                        Console.Write(lst_palavra[j] + " ");
                    }

                    Console.WriteLine("");

                    Console.Write("Letras Erradas:");
                    lst_letra_errada = Forca.vetor_letra_errada(letra, palavra, i, lst_letra_errada);
                    foreach (char elemento in lst_letra_errada)
                    {
                        Console.Write(elemento + " ");

                    }

                    Console.WriteLine($"\nQuantidade de tentativas restantes:{Forca.Quantidade_Tentativas_restantes(lst_letra_errada)}");


                    Console.Write("Letras Digitadas: ");

                    foreach (char elemento in lst_letras_totais)
                    {
                        Console.Write(elemento + " ");

                    }
                    Console.WriteLine("");
                    //verificacao = letra digitada pelo usuario
                    Console.Write("Digite a letra desejada:");
                    string verificacao = Console.ReadLine().ToLower();

                    //TIREI DAQUI
                    verificacao = Forca.verificacao_letra_existe(verificacao, lst_letras_totais);

                    //lst_letras_totais.Append(char.Parse(verificacao));
                    letra = char.Parse(verificacao);
                    lst_letras_totais = Forca.vetor_letras_totais(letra, contador, lst_letras_totais);

                    lst_palavra = Forca.esconde(palavra, letra, lst_palavra);

                    if (Forca.errou(palavra, letra) == false)
                    {
                        Console.WriteLine("A letra digitada não existe na palavra-chave");
                        Console.WriteLine("Aperte qualquer tecla para continuar jogando !");
                        Console.ReadKey();
                        i++;
                    }
                    contador++;
                    acabou = Forca.acabou(lst_palavra);
                    Console.Clear();
                } while (i != 7 && acabou != 0);


                if (i == 7)
                {
                    Console.WriteLine("O perdedor conquista a dignidade de um vencedor quando aceita a sua derrota !! ");

                }
                else
                {
                    Console.WriteLine("Para vencer, deve conhecer perfeitamente a terra e os homens. O resto é uma questão de calculo.Eis a arte da guerra.Sun Tzu");
                }
            }
            else
            {
                Console.WriteLine("Se você conhece o inimigo e conhece a si mesmo, não precisa temer o resultado de cem batalhas, porque voce sera derrotado em todas elas ");
            }
            Console.ReadKey();
            Console.Clear();
            Forca.Creditos();
            Console.Clear();
        }
    }
}