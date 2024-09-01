using RPG.src.Entities;


namespace RPG
{
    class Program
    {
        public static void Main()
        {
            List<Habilidade> habilidades =
            [
                new()
                 {
                    NomeAtaque = "Bola de Fogo",
                    TipoDoHeroi = (TiposHeroi)(TiposHeroi.MagoBranco & TiposHeroi.MagoNegro),
                    NivelHabilidade = 1,
                    CustoMana = 100
                },
                new()
                {
                    NomeAtaque = "Raio Congelante",
                    TipoDoHeroi = (TiposHeroi)(TiposHeroi.MagoBranco & TiposHeroi.MagoNegro),
                    NivelHabilidade = 1,
                    CustoMana = 100
                }
            ];
            
            List<Jogador> jogadores = 
            [
                new()
                {
                    Nome = "Matmouze",
                    Classe = (Guerreiro)new()
                },
                new()
                {
                    Nome = "Stoneee",
                    Classe = (MagoNegro)new()
                }
            ];
            Habilidade habilidade1 = habilidades[0];
            Jogador jogador1 = jogadores[0];    
            Jogador jogador2 = jogadores[1];
            Console.WriteLine(jogador1.Classe.AtualHP);  
            Console.WriteLine(jogador2.Classe.AtualMana);       
            int dano = jogador2.Classe.Atacar(jogador1.Classe, habilidade1);
            Console.WriteLine(jogador1.Classe.AtualHP);
            Console.WriteLine(jogador2.Classe.AtualMana); 
        }
        
    }
}
