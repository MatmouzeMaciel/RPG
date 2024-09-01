namespace RPG.src.Entities
{
    /**/
    public class Habilidade()
    {
        public Guid ID = Guid.NewGuid();
        public string NomeAtaque {get; set; } = "";
        /*TipoDoHeroi é atribuido à Habilidade para que haja o pareamento das habilidades
        entre as classes, e seja possível realizar verificação de que o objeto Jogador está chamando um objeto Habilidade compatível*/
        //Por ser para fins educacionais, não foi levado à isto no projeto
        public TiposHeroi TipoDoHeroi {get; set; } 
        public int NivelHabilidade {get; set; } = 1;
        public int CustoMana {get; set; }
        public int Dano {get; set; }
  
    }
    /*O objeto TiposHeroi serve como um alicerse de referenciamento entre os Objetos Habilidade e Jogador, podendo realizar esse cruzamento sem maiores problemas */
    public enum TiposHeroi{
        Guerreiro = 0, //0
        MagoBranco = 1, //1
        MagoNegro = 2, //2
        Ninja = 4 //4
    }
    /*Jogador é a abstração final/conveniente para este projeto logo que nela é gerada todos os parâmetros necessários para gerar o Objeto 
    Jogador de forma que faça sentido na utilização dentro deste projeto*/
    public class Jogador()
    {
        /*Foi setado para todo onjeto Jogador um ID para que mesmo que haja repetições entre od objetos, haja um dicernimento claro entre eles */
        public Guid IDJogador = Guid.NewGuid();
        public string Nome {get; set; } = "";
        public int Level {get; set; }
        public Heroi Classe {get; set; } = new Heroi();


    }

    /*O Objeto heroi é herdado pelos objetos MagoBranco, MagoNegro, Guerreiro e Ninja, e é referenciada em Jogador para criar a 
    Classe utilizada pelo Objeto Jogador*/
    public class Heroi()
    {
        public Guid IDHeroi = Guid.NewGuid();
        public TiposHeroi TipoDeHeroi {get; set; } 
        public int MaxHP {get; set; }
        public int AtualHP {get; set; }
        public int MaxMana {get; set; }
        public int AtualMana {get; set; }
        public int AtaqueBase {get; set; }
        public int DefesaBase {get; set; }
        public List<Habilidade> Habilidades {get; set;} = new List<Habilidade>();
        //O método Atacar é sobrescrito em cada classe utilizando valores/peculidades delas. 
        public virtual int Atacar(Heroi atacado, Habilidade habilidade){
            if(AtualMana < habilidade.CustoMana){
                return 0;
            }
            int danoCausado = AtaqueBase + habilidade.Dano - atacado.DefesaBase;
            AtualMana -= habilidade.CustoMana;
            atacado.AtualHP -= danoCausado;
            return danoCausado;
        }
    }

    public class MagoNegro : Heroi
    {
        public MagoNegro()
        {
            TipoDeHeroi = TiposHeroi.MagoNegro;
            MaxHP = 300;
            AtualHP = 300;
            MaxMana = 1000;
            AtualMana = 1000;
            AtaqueBase = 50;
            DefesaBase = 10;
        }
        public override int Atacar(Heroi atacado, Habilidade habilidade)
        {
            if(AtualMana < habilidade.CustoMana){
                return 0;
            }
            AtualMana -= habilidade.CustoMana;
            int danoCausado = AtaqueBase + habilidade.Dano - atacado.DefesaBase + habilidade.CustoMana + (int)(0.15*AtualHP);
            AtualHP = 
            atacado.AtualHP -= danoCausado;
            return danoCausado;
        }
    }

    public class MagoBranco : Heroi
    {
        public MagoBranco()
        {
            TipoDeHeroi = TiposHeroi.MagoBranco;
            MaxHP = 300;
            AtualHP = 300;
            MaxMana = 1000;
            AtualMana = 1000;
            AtaqueBase = 50;
            DefesaBase = 10;
        }
        public override int Atacar(Heroi atacado, Habilidade habilidade)
        {
            if(AtualMana < habilidade.CustoMana){
                return 0;
            }
            AtualMana -= habilidade.CustoMana;
            int danoCausado = AtaqueBase + habilidade.Dano - atacado.DefesaBase + habilidade.CustoMana;
            atacado.AtualHP -= danoCausado;
            return danoCausado;
        }  
    }

    public class Guerreiro : Heroi
    {
        public Guerreiro()
        {
            TipoDeHeroi = TiposHeroi.Guerreiro;
            MaxHP = 1000;
            AtualHP = 1000;
            MaxMana = 300;
            AtualMana = 300;
            AtaqueBase = 25;
            DefesaBase = 40;
        }
        public override int Atacar(Heroi atacado, Habilidade habilidade)
        {
            if(AtualMana < habilidade.CustoMana){
                return 0;
            }
            AtualMana -= habilidade.CustoMana;
            int danoCausado = AtaqueBase + habilidade.Dano - atacado.DefesaBase + (int)(0.3*AtualHP);
            atacado.AtualHP -= danoCausado;
            return danoCausado;
        }
    }

    public class Ninja : Heroi
    {
        public Ninja()
        {
            TipoDeHeroi = TiposHeroi.Ninja;
            MaxHP = 700;
            AtualHP = 700;
            MaxMana = 400;
            AtualMana = 400;
            AtaqueBase = 35;
            DefesaBase = 05;
        }
        public override int Atacar(Heroi atacado, Habilidade habilidade)
        {
            if(AtualMana < habilidade.CustoMana){
                return 0;
            }
            AtualMana -= habilidade.CustoMana;
            int danoCausado = AtaqueBase + habilidade.Dano - atacado.DefesaBase + (int)(1.3*AtaqueBase);
            atacado.AtualHP -= danoCausado;
            return danoCausado;
        }
    }
}