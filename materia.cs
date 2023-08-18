public class Materia{
    public string Nome;
    public int qtAvaliacoes;
    public List<Prazo> Avaliacoes = new();

    public Materia(string Nome,int qtAvaliacoes){
        this.Nome = Nome;
        this.qtAvaliacoes = qtAvaliacoes;
        int i;
        int dia,mes,ano;
        int notaTotal;
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
            int.TryParse(Console.ReadLine(),out notaTotal);

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
        if(Avaliacoes.Remove(prazo)) return 0;
        qtAvaliacoes--;
        return 1;
    }
}