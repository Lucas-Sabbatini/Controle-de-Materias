public class Materia{
    public string Nome;
    public int qtAvaliacoes;
    public List<Prazo> Avaliacoes = new();

    public Materia(string Nome,int qtAvaliacoes){
        this.Nome = Nome;
        this.qtAvaliacoes = qtAvaliacoes;
        int i;
        int dia,mes,ano;
        float notaTotal;
        string tipoDoPrazo;

        for(i=0;i<qtAvaliacoes;i++){
            Console.WriteLine("Digite o dia dd/mm/aaaa");
            int.TryParse(Console.ReadLine(),out dia);
            int.TryParse(Console.ReadLine(),out mes);
            int.TryParse(Console.ReadLine(),out ano);
            Data diaDoPrazo = new Data(dia,mes,ano);

            Console.WriteLine("Qual é o tipo da avaliação? (prova/trabalho/seminário): ");
            tipoDoPrazo = Console.ReadLine();
            Console.WriteLine("Qual é o valor total da avaliação?");
            float.TryParse(Console.ReadLine(),out notaTotal);

            Prazo prazo = new Prazo(diaDoPrazo,tipoDoPrazo,notaTotal,-1);

            Avaliacoes.Add(prazo);
        }

        Avaliacoes.Sort(ordenaAvaliações);
    }

    private static int ordenaAvaliações(Prazo x,Prazo y){
        if(x.diaDoPrazo.ano == y.diaDoPrazo.ano){
            if(x.diaDoPrazo.mes == y.diaDoPrazo.mes){
                if(x.diaDoPrazo.dia == y.diaDoPrazo.dia){
                    return 0;
                }
                else if(x.diaDoPrazo.dia > y.diaDoPrazo.dia){
                    return 1;
                }
                else if(x.diaDoPrazo.dia < y.diaDoPrazo.dia){
                    return -1;
                }
            }
            else if(x.diaDoPrazo.mes > y.diaDoPrazo.mes){
                return 1;
            }
            else if(x.diaDoPrazo.mes < y.diaDoPrazo.mes){
                return -1;
            }

        }
        else if(x.diaDoPrazo.ano > y.diaDoPrazo.ano){
            return 1;
        }
        else if(x.diaDoPrazo.ano < y.diaDoPrazo.ano){
            return -1;
        }
        return 0;
    }

    public int AdicionarPrazo(Prazo prazo){
        Avaliacoes.Add(prazo);
        qtAvaliacoes++;
        return 0;
    }
    public int removerPrazo(Prazo prazo){
        if(Avaliacoes.Remove(prazo)){
            qtAvaliacoes--;
            return 0;
        } 
        return 1;
    }
    public int alterarNotaTotalPrazo(int[] notas){
        int i,soma=0;

        for(i=0;i<qtAvaliacoes;i++){
            soma += notas[i];
        }

        if(soma!=100) return 1;

        for(i=0;i<qtAvaliacoes;i++){
            Avaliacoes[i].NotaTotal = notas[i];
        }
        return 0;
    }

    public int calcNotasRecomendadas(ref int tipoDesempenho){
        int i;
        float porcentagem=0,soma=0,somaProporcional=0,somaNotasTotais=0;

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
        else if(soma<60){
            //ver quanto falta de nota e dividir proporcionalmente com relação aos valores respectivos de cada prova
            soma = 100 -soma;
            porcentagem = (float) soma/somaProporcional;
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