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
                    Console.WriteLine("Qual matéria você deseja adicionar?");

                break;
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
    }
    public static void removerMateria(Pessoa user,Materia mat){
        if(user.removerMateria(mat)==0){
            Console.WriteLine("Materia Removida");
        }
        else{
            Console.WriteLine("Houve um problema em remover a matéria");
        }
        
    }

     public static void adicionarMateria(Pessoa user,Materia mat){
        user.adicionarMateria(mat);
        Console.WriteLine("Materia Adicionada");
    }
}