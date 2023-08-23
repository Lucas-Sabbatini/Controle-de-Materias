

internal class Program
{
    private static void Main(string[] args)
    {
        int opMenu,opMateria,opAvaliacao,opMenuMateria=0;
        Pessoa user;
        user = MetodosMenu.logIn();

        MetodosMenu.showMenuInicial(user,out opMenu,out opMateria);

        switch(opMenu){
            case 1:
                //Ver dados da materia
                MetodosMenu.showMenuMateria(user.Materias[opMateria-1],out opMenuMateria,out opAvaliacao);
            break;
            case 2:
                //Adicionar materia
                MetodosMenu.adicionarMateria(user);
            break;
            case 3:
                //Remover materia
                MetodosMenu.removerMateria(user,user.Materias[opMateria-1]);
            break;
        }

        switch(opMenuMateria){
            case 1:
                Console.WriteLine("voltou");
            break;
            case 2:
            Console.WriteLine("voltou");
            break;
            case 3:
            Console.WriteLine("voltou");
            break;
            default:
                Console.WriteLine("Alguém adicionou ou removeu alguma matéira");
            break;

        }
    }
}
