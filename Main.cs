

internal class Program
{
    private static void Main(string[] args)
    {
        int opMenu,opMateria,opAvaliacao=0,opMenuMateria=0;
        Pessoa user;

        
        user = MetodosMenu.logIn();

        MetodosMenu.showMenuInicial(user,out opMenu,out opMateria);
        do{
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
        }while(opAvaliacao >1 && opMateria > 1);
        

        switch(opMenuMateria){
            case 1:
                //alterar os dados de uma avaliação
                MetodosMenu.alterarAvaliacao(user.Materias[opMateria-1],user.Materias[opMateria-1].Avaliacoes[opAvaliacao-1]);
            break;
            case 2:
                //adicionar avaliação
                MetodosMenu.adicionarAvaliacao(user.Materias[opMateria-1]);
            break;
            case 3:
                //remover avaliação
                MetodosMenu.removerAvaliacao(user.Materias[opMateria-1],user.Materias[opMateria-1].Avaliacoes[opAvaliacao-1]); 
            break;
            default:
                Console.WriteLine("Alguém adicionou ou removeu alguma matéira");
            break;

        }
    }
}
