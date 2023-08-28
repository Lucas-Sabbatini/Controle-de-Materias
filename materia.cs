public class Materia{
    public string Nome;
    public int qtAvaliacoes;
    public List<Prazo> Avaliacoes = new();

    public Materia(string Nome,int qtAvaliacoes){
        int i;
        this.Nome = Nome;
        this.qtAvaliacoes = qtAvaliacoes;
        for(i=0;i<qtAvaliacoes;i++){
            AdicionarPrazo();
        }
    }

    private static int ordenaAvaliações(Prazo x,Prazo y){
        if(x.DiaDoPrazo.ano == y.DiaDoPrazo.ano){
            if(x.DiaDoPrazo.mes == y.DiaDoPrazo.mes){
                if(x.DiaDoPrazo.dia == y.DiaDoPrazo.dia){
                    return 0;
                }
                else if(x.DiaDoPrazo.dia > y.DiaDoPrazo.dia){
                    return 1;
                }
                else if(x.DiaDoPrazo.dia < y.DiaDoPrazo.dia){
                    return -1;
                }
            }
            else if(x.DiaDoPrazo.mes > y.DiaDoPrazo.mes){
                return 1;
            }
            else if(x.DiaDoPrazo.mes < y.DiaDoPrazo.mes){
                return -1;
            }

        }
        else if(x.DiaDoPrazo.ano > y.DiaDoPrazo.ano){
            return 1;
        }
        else if(x.DiaDoPrazo.ano < y.DiaDoPrazo.ano){
            return -1;
        }
        return 0;
    }

    public int AdicionarPrazo(){
        int dia,mes,ano;
        float notaTotal,notaObtida;
        string tipoDoPrazo;
        char op;

        notaObtida = -1;
        Console.WriteLine("Digite o dia dd/mm/aaaa");
        int.TryParse(Console.ReadLine(),out dia);
        int.TryParse(Console.ReadLine(),out mes);
        int.TryParse(Console.ReadLine(),out ano);
        Data diaDoPrazo = new Data(dia,mes,ano);

        Console.WriteLine("Qual é o tipo da avaliação? (prova/trabalho/seminário): ");
        tipoDoPrazo = Console.ReadLine();
        Console.WriteLine("Qual é o valor total da avaliação?");
        float.TryParse(Console.ReadLine(),out notaTotal);
            
        do{
            Console.WriteLine("Você já fez essa prova? (s/n)");
            char.TryParse(Console.ReadLine(),out op);
            if(op=='s'){
                Console.WriteLine("Digite quanto você tirou na prova");
                float.TryParse(Console.ReadLine(),out notaObtida);
            }
            else if(op!='n'){
                Console.WriteLine("Opção inválida, digite novamente");
            }
        }while(op!='s'&&op!='n');
            

        Prazo prazo = new Prazo(diaDoPrazo,tipoDoPrazo,notaTotal,notaObtida);

        Avaliacoes.Add(prazo);
        Avaliacoes.Sort(ordenaAvaliações);
        return 0;
    }
    public int removerPrazo(Prazo prazo){
        if(Avaliacoes.Remove(prazo)){
            qtAvaliacoes--;
            return 0;
        } 
        return 1;
    }
    public int alterarNotaTotalPrazo(float[] notas){
        int i;
        float soma=0;
        int retorno;

        for(i=0;i<qtAvaliacoes;i++){
            soma += notas[i];
        }

        if(soma!=100) return 1;

        for(i=0;i<qtAvaliacoes;i++){
            Avaliacoes[i].NotaTotal = notas[i];
            if(Avaliacoes[i].NotaObtida>Avaliacoes[i].NotaTotal){
                retorno = Avaliacoes[i].alterarNotaObtida(Avaliacoes[i].NotaTotal);
                if(retorno == 1) return 2;
            }
        }
        return 0;
    }

    public int calcNotasRecomendadas(out int tipoDesempenho){
        int i;
        float porcentagem,soma=0,somaProporcional=0,somaNotasTotais=0;

        for(i=0;i<qtAvaliacoes;i++){
            if(Avaliacoes[i].NotaObtida!=-1){   //ver quanto falta de nota e dividir proporcionalmente com relação aos valores respectivos de cada prova
                soma+=Avaliacoes[i].NotaObtida;
                somaNotasTotais += Avaliacoes[i].NotaTotal;
            }
            else{
                somaProporcional += Avaliacoes[i].NotaTotal;
            }
        }
        if(soma > 100){
            tipoDesempenho = 0;
            return 1;
        }
        else if(soma>=60){
            //calcular a media de desempenho e recomendar as proximas notas na mesma proporção
            porcentagem = (float) soma/somaNotasTotais;
            tipoDesempenho = 1;
        }
        else if(soma + somaProporcional <60){
            //não existe chance de passar
            tipoDesempenho = 2;
            return 1;
        }
        else{ //soma<60
            //ver quanto falta de nota e dividir proporcionalmente com relação aos valores respectivos de cada prova
            soma = 60 -soma;
            porcentagem = (float) soma/somaProporcional;  //quantidade de nota q falta/ soma das notas totais das provas que ainda faltam
            tipoDesempenho = 3;
           
        }

        for(i=0;i<qtAvaliacoes;i++){
            if(Avaliacoes[i].NotaObtida==-1){
                Avaliacoes[i].NotaRecomendada = Avaliacoes[i].NotaTotal * porcentagem;
            }
            else{
                Avaliacoes[i].NotaRecomendada = -1;
            }
        }
        
        return 0;
    }
}