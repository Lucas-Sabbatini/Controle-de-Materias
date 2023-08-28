public class Prazo{
    private Data diaDoPrazo;
    private string tipoDoPrazo;
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
    }

    public int alterarNotaObtida(float notaObtida){
        if(notaObtida<=notaTotal&&notaObtida>=0){
            this.notaObtida = notaObtida;
            return 0;
        }
        return 1;
    }
    public float NotaRecomendada{
        get=>notaRecomendada;
        set => notaRecomendada = value;
    }

    public float NotaTotal{
        get => notaTotal;
        set => notaTotal = value;
    }

    public Data DiaDoPrazo{
        get => diaDoPrazo;
    }

    public string TipoDoPrazo{
        get => tipoDoPrazo;
    }

    public int alterarDiaDoPrazo(int dia,int mes,int ano){
        Data diaDoPrazo = new Data(dia,mes,ano);
        if(diaDoPrazo.dataValida()){
            this.diaDoPrazo = diaDoPrazo;
            return 0;
        }
        return 1;
    }

    public int alterarTipoDoPrazo(string tipoDoPrazo){
        if(tipoDoPrazo==null){
            return 1;
        }
        this.tipoDoPrazo = tipoDoPrazo;
        return 0;
    }
}