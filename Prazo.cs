public class Prazo{
    public Data diaDoPrazo;
    public string tipoDoPrazo;
    private float notaTotal;
    private float notaObtida;
    private float notaRecomendada;
    
    public Prazo(Data diaDoPrazo,string tipoDoPrazo,float notaTotal,float notaObtida){
        this.diaDoPrazo = diaDoPrazo;
        this.tipoDoPrazo = tipoDoPrazo;
        this.notaTotal = notaTotal;
        this.notaObtida = notaObtida;
    }


    public float NotaObtida{
        get=>notaObtida;
        set {
            if(value<=notaTotal){
                notaObtida = value;
            }
        }
    }

    public float NotaRecomendada{
        get=>notaRecomendada;
        set => notaRecomendada = value;
    }

    public float NotaTotal{
        get => notaTotal;
        set => notaTotal = value;
    }
}