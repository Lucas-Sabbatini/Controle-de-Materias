public class Pessoa{
    public string nome;
    private byte[] senha;
    private string usuario;
    public List<Materia> Materias = new();

    public Pessoa(string nome,byte[] senha,string usuario){
        int qtMaterias,qtAvaliacoes;
        string nomeMateria;
        Console.WriteLine("Quantas Matérias você planeja adicionar no primeiro momento?");
        int.TryParse(Console.ReadLine(),out qtMaterias);

        this.nome = nome;
        this.senha = senha;
        this.usuario = usuario;

        for(int i=0;i<qtMaterias;i++){
            Console.WriteLine("Qual é o nome dessa matéria?");
            nomeMateria = Console.ReadLine();
            Console.WriteLine("Quantas avaliações essa matéria tem?");
            int.TryParse(Console.ReadLine(),out qtAvaliacoes);

            Materia mat = new Materia(nomeMateria,qtAvaliacoes);

            Materias.Add(mat);
        }
    }
    
    public int adicionarMateria(Materia mat){
        Materias.Add(mat);
        return 0;
    }

    public int removerMateria(Materia mat){
       if( Materias.Remove(mat)) return 0;
        return 1;
    }

    public int checkLogin(string usuario,byte[] senha){
        if(this.usuario==usuario&&senha.SequenceEqual(this.senha)){
            return 0;
        }
        return 1;
    }
}