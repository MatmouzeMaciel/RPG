namespace RPG.src.Entities
{
    public class Habilidade()
    {
        public Guid ID = Guid.NewGuid();
        public string NomeAtaque {get; set; } = "";
        public TiposHeroi TipoDoHeroi {get; set; } 
        public int NivelHabilidade {get; set; } = 1;
        public int CustoMana {get; set; }
        public int Dano {get; set; }
  
    }

    public enum TiposHeroi{
        Guerreiro = 0, //0
        MagoBranco = 1, //1
        MagoNegro = 2, //2
        Ninja = 4 //4
    }
    
    public class Jogador()
    {
        public Guid IDJogador = Guid.NewGuid();
        public string Nome {get; set; } = "";
        public int Level {get; set; } = 1;
        public Heroi Classe {get; set; } = new Heroi();


    }

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