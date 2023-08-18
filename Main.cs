
using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
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

            user = new Pessoa(cadastroNome,converteSenha(cadastroSenha),cadastroUsuario);

            /* Aqui a intensão é que quando o banco de dados esteja implementado eu busque o cadastro de um  usuário que bata com o usuário digitado no teclado,
                crie um objeto com as informações do banco de dados (sem necessariamente instanciar todas as variáveis desse objeto (não sei se isso é possível))
                e chame a função user.chekLogin passando como parâmetros os valores digitados pelos usuários no teclado. Caso o resultado seja positivo eu posso 
                terminar de instanciar esse objeto com as informações do bd. */     
            
            if(user.checkLogin(cadastroUsuario,converteSenha(cadastroSenha))==1){
                Console.WriteLine("Usuário ou senha incorretos");
                entrou = false;
            }

        }while(!entrou);

        Console.WriteLine($"Seja bem vindo {cadastroNome}!");

    }

    private static byte[] converteSenha(string s){
        MD5 md5 = MD5.Create();
        byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(s));

        Console.WriteLine("Hash MD5 como array de bytes:");

        return data;
    }
}
