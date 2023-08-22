

internal class Program
{
    private static void Main(string[] args)
    {
        int opMenu,opMateria;
        Pessoa user;
        user = MetodosMenu.logIn();

        MetodosMenu.showMenuInicial(user,out opMenu,out opMateria);

        switch(opMenu){
            case 1:
                //Ver dados da materia
                MetodosMenu.showMenuMateria(user.Materias[opMateria-1]);
            break;
            case 2:
                //Adicionar materia
                MetodosMenu.adicionarMateria(user,user.Materias[opMateria-1]);
            break;
            case 3:
                //Remover materia
                MetodosMenu.removerMateria(user,user.Materias[opMateria-1]);
            break;
        }
    }
}
