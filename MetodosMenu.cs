using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
public static class MetodosMenu{

    public static Pessoa logIn(){
        string cadastroNome,cadastroSenha,cadastroUsuario;
        bool entrou = true;
        Pessoa user;

         do{
            Console.WriteLine("Digite o seu nome: ");
            cadastroNome = Console.ReadLine();
            Console.WriteLine("Agora digite a sua senha: ");
            cadastroSenha = Console.ReadLine();
            Console.WriteLine("Agora digite o seu usuário (e-mail, n.de.telefone, nickname): ");
            cadastroUsuario = Console.ReadLine();

            user = new Pessoa(cadastroNome,converteSenha(cadastroSenha),cadastroUsuario); // criando uma pessoa, a ideia é não criar

            /* Aqui a intensão é que quando o banco de dados esteja implementado eu busque o cadastro de um  usuário que bata com o usuário digitado no teclado,
                crie um objeto com as informações do banco de dados (sem necessariamente instanciar todas as variáveis desse objeto (não sei se isso é possível))
                e chame a função user.chekLogin passando como parâmetros os valores digitados pelos usuários no teclado. Caso o resultado seja positivo eu posso 
                terminar de instanciar esse objeto com as informações do bd. */     
            
            if(user.checkLogin(cadastroUsuario,converteSenha(cadastroSenha))==1){
                Console.WriteLine("Usuário ou senha incorretos");
                entrou = false;
            }

        }while(!entrou);


        return user;
    }

    private static byte[] converteSenha(string s){
        MD5 md5 = MD5.Create();
        byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(s));

        return data;
    }

    public static void showMenuInicial(Pessoa user,out int opMenu,out int opMateria){
        Console.WriteLine($"Seja bem vindo ao seu sistema de gerenciamento de provas {user.nome}!");

        do{
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("[1] - Conslultar ou alterar dados de alguma matéria");
            Console.WriteLine("[2] - Adicionar alguma matéria");
            Console.WriteLine("[3] - Remover alguma matéria"); 
            Console.WriteLine("Digite sua opção (1,2,3): ");
            int.TryParse(Console.ReadLine(),out opMenu);
                
            if(opMenu!= 1 && opMenu!= 2 && opMenu != 3){
                Console.WriteLine("Opção inválida, tente novamente");
            }
        }while(opMenu!= 1 && opMenu!= 2 && opMenu != 3);

        do{
            switch(opMenu){
                case 1:
                    Console.WriteLine("De qual matéria você deseja consultar ou alterar os dados?");
                break;
                case 2:
                    opMateria = 0;
                    return;
                case 3:
                    Console.WriteLine("Qual matéira você deseja remover?");

                break;
            }
            showMaterias(user);
            Console.WriteLine("Digite sua opção: ");
            int.TryParse(Console.ReadLine(),out opMateria);

            if(opMateria<0||opMateria>user.Materias.Count){
            Console.WriteLine("Opção inválida, tente novamente");
           }
        }while(opMateria<0||opMateria>user.Materias.Count);
    }

    private static void showMaterias(Pessoa user){
        int i = 0;

        for(i=0;i<user.Materias.Count;i++){
            Console.WriteLine($"[{i+1}] - : {user.Materias[i].Nome}");
        }
    }

    public static void showMenuMateria(Materia mat){
        Console.WriteLine($"Dados da matéria {mat.Nome}");
        Console.WriteLine("Avaliações: ");
        showAvaliacoes(mat);
    }
    public static void removerMateria(Pessoa user,Materia mat){
        if(user.removerMateria(mat)==0){
            Console.WriteLine("Materia Removida");
        }
        else{
            Console.WriteLine("Houve um problema em remover a matéria");
        }
        
    }

     public static void adicionarMateria(Pessoa user){
        string nome;
        int qtAvaliacoes;
        nome = Console.ReadLine();
        int.TryParse(Console.ReadLine(),out qtAvaliacoes);

        Materia mat = new Materia(nome,qtAvaliacoes);
        user.adicionarMateria(mat);
        Console.WriteLine("Materia Adicionada");
    }
    public static void showMenuMateria(Materia mat,out int opMenu,out int opAvaliacao){
        Console.WriteLine($"Avaliações da matéria {mat.Nome}: ");
        showAvaliacoes(mat);

        do{
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("[1] - Alterar os dados de alguma Avaliação");
            Console.WriteLine("[2] - Adicionar uma Avaliação");
            Console.WriteLine("[3] - Remover uma Avaliação"); 
            Console.WriteLine("Digite sua opção (1,2,3): ");
            int.TryParse(Console.ReadLine(),out opMenu);
                
            if(opMenu!= 1 && opMenu!= 2 && opMenu != 3){
                Console.WriteLine("Opção inválida, tente novamente");
            }
        }while(opMenu!= 1 && opMenu!= 2 && opMenu != 3);

       

        switch(opMenu){
            case 1:
                Console.WriteLine("De qual Avaliação você deseja alterar os dados?: ");
            break;
            case 2:
                opAvaliacao = 0;
                return;
            case 3:
                Console.WriteLine("Qual Avaliação você deseja remover?: ");
            break;
        }
        do{
            int.TryParse(Console.ReadLine(),out opAvaliacao);
            if(opAvaliacao<1||opAvaliacao>mat.qtAvaliacoes){
                Console.WriteLine("Você digitou um índice errado, tente novamente");
            }
        }while(opAvaliacao<1||opAvaliacao>mat.qtAvaliacoes);
    }

    public static void removerAvaliacao(Materia mat,Prazo avaliacao){
        if(mat.removerPrazo(avaliacao)==0){
            Console.WriteLine("Materia Removida");
        }
        else{
            Console.WriteLine("Houve um problema em remover a avaliacao");
        }
    }

    public static void adicionarAvaliacao(Materia mat){
        mat.AdicionarPrazo();
        Console.WriteLine("Avaliação adicionada!");
    }
    private static void showAvaliacoes(Materia mat){
        int i = 0;
        int tipoDesempenho;
        mat.calcNotasRecomendadas(out tipoDesempenho);


        for(i=0;i<mat.qtAvaliacoes;i++){
            Console.Write($"[{i+1}] - : ");
            mat.Avaliacoes[i].DiaDoPrazo.mostrarData();
            Console.WriteLine("Tipo: "+ mat.Avaliacoes[i].TipoDoPrazo);
            Console.WriteLine("Nota total: "+ mat.Avaliacoes[i].NotaTotal);
            if(mat.Avaliacoes[i].NotaObtida == -1){
                switch(tipoDesempenho){
                    case 0:
                        Console.WriteLine("Houve um erro em calcular suas notas recomendadas");
                    break;
                    case 1:
                        Console.WriteLine($"Você está indo muito bem, para continuar nesse nível de rendimento vc deveria tirar: {mat.Avaliacoes[i].NotaRecomendada}");
                    break;
                    case 2:
                        Console.WriteLine("Você infelizmente não tem chance de passar");
                    break;
                    case 3:
                        Console.WriteLine($"Para você ficar na média você deve tirar: {mat.Avaliacoes[i].NotaRecomendada}");
                    break;
                }
            }
            else{
                Console.WriteLine("Nota obtida: "+ mat.Avaliacoes[i].NotaObtida);
            }
        }
        Console.WriteLine("\n");
    }

    public static void alterarAvaliacao(Materia mat,Prazo avaliacao){
        int op,dia,mes,ano,aceito,i;
        string tipo;
        float nota;
        float[] notas = new float[mat.qtAvaliacoes];

        Console.WriteLine("O que você deseja mudar?");
        do{
            Console.WriteLine("[1] Alterar a data da avaliacao");
            Console.WriteLine("[2] Alterar o tipo da avaliacao");
            Console.WriteLine("[3] Alterar a nota Total da avaliacao");
            Console.WriteLine("[4] Alterar a nota Obtida da avaliacao");
            int.TryParse(Console.ReadLine(),out op);
            if(op>4&&op<1){
                Console.WriteLine("Opção inválida, digite novamente");
            }
        }while(op>4&&op<1);

        switch(op){
            case 1:
                do{
                    Console.WriteLine("Digite a data: (dd,mm,aaaa)");
                    int.TryParse(Console.ReadLine(),out dia);
                    int.TryParse(Console.ReadLine(),out mes);
                    int.TryParse(Console.ReadLine(),out ano);
                    aceito = avaliacao.alterarDiaDoPrazo(dia,mes,ano);
                    if(aceito == 1){
                        Console.WriteLine("Você digitou uma data que não é válida");
                    }
                }while(aceito == 1);
            break;
            case 2:
                do{
                    Console.WriteLine("Digite o novo tipo do prazo: ");
                    tipo = Console.ReadLine();
                    aceito = avaliacao.alterarTipoDoPrazo(tipo);
                    if(aceito == 1){
                    Console.WriteLine("Você digitou uma tipo que não é válida");
                    }
                }while(aceito == 1);
            break;
            case 3:
                do{
                    for(i=0;i<mat.qtAvaliacoes;i++){
                        Console.Write("Digite a nota da avaliacao do dia ");
                        mat.Avaliacoes[i].DiaDoPrazo.mostrarData();
                        float.TryParse(Console.ReadLine(),out notas[i]);
                    }
                    aceito = mat.alterarNotaTotalPrazo(notas);
                    if(aceito == 1){
                        Console.WriteLine("A soma das notas é diferente de 100, digite as notas novamente: ");
                    }
                    else if(aceito ==2){
                        Console.WriteLine("Você digitou uma nova inválida");
                    }
                }while(aceito ==1);
                
            break;
            case 5:
                do{
                    Console.WriteLine("Digite a data: (dd,mm,aaaa)");
                    float.TryParse(Console.ReadLine(),out nota);
                    aceito = avaliacao.alterarNotaObtida(nota);
                    if(aceito == 1){
                        Console.WriteLine("Você digitou uma nota que não é válida");
                    }
                    }while(aceito == 1);
            break;
        }
    }
}