namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    // 4. Crie a funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        var queryStudioDevelopers = from game in Games
                                    join studio in GameStudios
                                    on game.DeveloperStudio equals
                                    studio.Id
                                    where studio.Name == gameStudio.Name
                                    select game;

        return queryStudioDevelopers.ToList();
    }

    // 5. Crie a funcionalidade de buscar jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        var queryGamesPlayedByPlayer = Games.Where(g => g.Players.Contains(player.Id));

        return queryGamesPlayedByPlayer.ToList();
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {

        // var GamesOwnedBy = Games.Where(g => playerEntry.GamesOwned.Contains(g.Id));

        var GamesOwnedBy = from game in Games
                           from gameOwned in playerEntry.GamesOwned
                           where game.Id == gameOwned
                           select game;

        return GamesOwnedBy.ToList();

    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        var allGamesWithStudio = Games.Select(g => new GameWithStudio
        {
            GameName = g.Name,
            StudioName = GameStudios.Find(studio => studio.Id == g.DeveloperStudio)?.Name,
            NumberOfPlayers = g.Players.Count()
        });

        return allGamesWithStudio.ToList();

    }

    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        var allGamesType = (from game in Games
                            select game.GameType).Distinct();

        return allGamesType.ToList();

    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        var getStudioWithGamesAndPlayers =
        from studio in GameStudios
        orderby studio.Name
        select new StudioGamesPlayers
        {
            GameStudioName = studio.Name,
            Games = (from game in Games
                     where game.DeveloperStudio == studio.Id
                     orderby game.Name
                     select new GamePlayer
                     {
                         GameName = game.Name,
                         Players = Players.Where(p => game.Players.Contains(p.Id)).OrderBy(p => p.Name).ToList(),
                     }).ToList()

        };
        return getStudioWithGamesAndPlayers.ToList();

    }

}


