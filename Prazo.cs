public class Prazo{
    public Data diaDoPrazo;
    public string tipoDoPrazo;
    private int notaTotal;
    private int notaObtida;
    private int notaRecomendada;
    
    public Prazo(Data diaDoPrazo,string tipoDoPrazo,int notaTotal,int notaObtida){
        this.diaDoPrazo = diaDoPrazo;
        this.tipoDoPrazo = tipoDoPrazo;
        this.notaTotal = notaTotal;
        this.notaObtida = notaObtida;
    }

    public int AdicionarNota(int nota){
        if(nota>=notaTotal){
            Console.WriteLine("A nota obtida é maior doque a nota total");
            return -1;
        }

        notaObtida = nota;
        return 0;
    }

    public int NotaObtida{
        get=>notaObtida;
        set{
            if(value<=notaTotal){
                notaObtida = value;
            }
        }
    }

    public int NotaRecomendada{
        get=>notaRecomendada;
        set{
            if(value<=notaRecomendada){
                notaRecomendada = value;
            }
        }
    }

    public int NotaTotal{
        get => notaTotal;
        set => notaTotal = value;
    }
}