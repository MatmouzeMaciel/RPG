using RPG.src.Entities;


namespace RPG
{
    class Program
    {
        public static void Main()
        {   
            //Cria lista habilidades utilizando o objeto Habilidade como base
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

            //Cria lista jogadores utilizando o objeto Jogador como base
            List<Jogador> jogadores = 
            [
                new()
                {
                    Nome = "Arus",
                    Level = 42,
                    Classe = (Guerreiro)new()
                },
                new()
                {
                    Nome = "Topapa",
                    Level = 42,
                    Classe = (MagoNegro)new()
                },
                new()
                {
                    Nome = "Jenica",
                    Level = 42,
                    Classe = (MagoBranco)new()
                },
                new()
                {
                    Nome = "Wedge",
                    Level = 42,
                    Classe = (Ninja)new()
                }
            ];
            Habilidade habilidade1 = habilidades[0];
            Jogador jogador1 = jogadores[0];    
            Jogador jogador2 = jogadores[1];
            //Comparação de antes e depois de chamar Atacar:
            Console.WriteLine($" vida do {jogador1.Nome} antes de chamar Atacar era de {jogador1.Classe.AtualHP}");
            Console.WriteLine($" mana do {jogador2.Nome} antes de chamar Atacar era de {jogador2.Classe.AtualMana}");       
            int dano = jogador2.Classe.Atacar(jogador1.Classe, habilidade1);
            Console.WriteLine($" vida do {jogador1.Nome} depois de chamar Atacar é de {jogador1.Classe.AtualHP}");
            Console.WriteLine($" mana do {jogador2.Nome} depois de chamar Atacar é de {jogador2.Classe.AtualMana}");
            //Deveria estar dentro do método Atacar, porém para fins demonstrativo segue o "resultado"
            Console.WriteLine($"{jogador2.Nome} utilizou {habilidade1.CustoMana} de mana e causou {dano} de dano em {jogador1.Nome}"); 

        }
        
    }
}
