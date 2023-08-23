

public class Data{
    public int dia;
    public int mes;
    public int ano;

    public Data(int dia, int mes,int ano){
        if(dataValida(dia,mes,ano)){
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }
        else{
            dia = 1;
            mes = 1;
            ano = 1;
        }
    }

    public Data(){
        dia = 1;
        mes = 1;
        ano= 1;
    }

    ~Data(){
        Console.WriteLine("Dia destruido"+dia);
    }

    public void mostrarData(){
        switch(mes){
            case 1:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Janeiro",ano);
            break;
            case 2:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Fevereiro",ano);
            break;
            case 3:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Março",ano);
            break;
            case 4:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Abril",ano);
            break;
            case 5:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Maio",ano);
            break;
            case 6:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Junho",ano);
            break;
            case 7:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Julho",ano);
            break;
            case 8:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Agosto",ano);
            break;
            case 9:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Setembro",ano);
            break;
            case 10:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Outubro",ano);
            break;
            case 11:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Novembro",ano);
            break;
            case 12:
                Console.WriteLine("Dia {0} de {1} de {2}",dia,"Dezembro",ano);
            break;
        }
        
    }

    private bool dataValida(int dia,int mes,int ano){              //Uma função static é definida em um objeto mas não altera as propriedades dele
        if(mes==1||mes==3||mes==5||mes==7||mes==8||mes==10){
            if(dia>31||dia<1){
                return false;
            }
            else{
                return true;
            }
        }
        if(mes==2){
            if(ano%4==0){
                if(dia>29||dia<1){
                    return false;
                }
                else{
                    return true;
                }
            }
            else{
                if(dia>28||dia<1){
                    return false;
                }
                else{
                    return true;
                }
            }
        }
        if(mes==4||mes==6||mes==9||mes==11||mes==12){
            if(dia>30||dia<1){
                return false;
            }
            else{
                return true;
            }
        }
        return false;
    }
}
