
# GameSearchEngine :video_game:
<details>
<summary><strong>🧑‍💻 O que foi desenvolvido</strong></summary>

- Foram desenvolvidos diversos métodos que implementam manipulações a coleções existentes em um software que já teve o seu desenvolvimento iniciado. Além disso, foram desenvolvidas também diversas consultas `LINQ` para determinadas aplicações e uma aplicação de testes.

</details>
<details>
  <summary><strong>:memo: Habilidades trabalhadas </strong></summary>

- Habilidades com relação a manipulação de coleções
- Consultas LINQ para determinadas operações
- Um método de testes sobre coleções.
- Interpretação das coleções de dados já existentes em um software.
- Interpretação do funcionamento de um código já implementado.

</details>

## Requisitos do projeto


Foi inicioa o desenvolvimento de um sistema para gerenciar e armazenar dados de jogos jogados por Usuários, e o intuito era o de continuar esse desenvolvimento. 

Este sistema está dividido em diretórios específicos, para que fique mais fácil de entender e separar as entidades.
 - `Contracts/` Estão armazenadas as `interfaces` que uma classe pode implementar.
 - `Controller/` Estão armazenados os controllers responsáveis por realizar alguma ação que interage com a pessoa usuária e o banco de dados. No nosso caso há apenas um _controller_.
 - `Database/` Está armazenada a classe que representa o banco de dados do sistema. Essa classe contém uma lista de cada um dos modelos presentes no sistema e alguns métodos que podem ser utilizados para fazer consultas a essas listas e a relações entre elas.
 - `Models/` Contém os Modelos do sistema, no caso três: `Game`, `Player`, `GameStudio`.

O arquivo `Program.cs` utiliza a classe `TrybeGamesController` para executar as ações com a pessoa usuária, então é possível ver o sistema em funcionamento ao executar o projeto em `src/TrybeGames` com o comando `dotnet test`. Porém algumas funcionalidades ainda não foram implementadas, e é para isso que você foi contratado.

Entretando, para entender melhor como todas essas classes se relacionam entre si, vamos utilizar um diagrama. Primeiro, vamos entender qual a relação entre os Models `Game`, `Player` e `GameStudio` no diagrama abaixo:

![image](https://github.com/henriqueAvner/game-project-csharp/assets/133919307/effed8e1-8ac2-4131-92ad-e50190b51d2d)


Perceba que cada `Game` possui duas relações com `Player`:
 1. Um jogo `Game` pode ter várias pessoas jogadoras `Player` utilizando para isso o membro `Game.Players`, que é uma lista do tipo inteiro e armazena os Ids das pessoas jogadoras.
 2. Uma pessoa jogadora `Player` pode ter vários jogos `Game` comprados utilizando para isso o membro `Player.GamesOwned`, que é uma lista do tipo inteiro e armazena os Ids dos jogos comprados.

`GameStudio`, por sua vez, se relaciona apenas com `Game`. Cada `Game` é desenvolvido por um `GameStudio` e é utilizado o campo `Game.DeveloperStudio`, que é do tipo inteiro e armazena o Id do studio desenvolvedor do jogo.

`Player` também pode ter uma lista de estúdios favoritos. Para isso é utilizado o seu membro `Player.FavoriteGameStudios`, que é uma lista do tipo inteiro que armazena os Ids dos estúdios favoritos.

Esses Models, por sua vez, são utilizados na classe `TrybeGamesDatabse` para compor o nosso banco de dados. E `TrybeGamesDatabase` é utilizado em `TrybeGamesController` para realizar as consultas e operações requisitadas pela pessoa usuária. Veja no diagrama completo abaixo todas as relações entre cada entidade do sistema.

![image](https://github.com/henriqueAvner/game-project-csharp/assets/133919307/e820df4d-1cfd-44aa-ad33-72cb2163814b)



### 1. Funcionalidde para adicionar uma nova pessoa jogadora ao banco de dados

_Implementado o método `AddPlayer()` no arquivo `src/TrybeGames/TrybeGamesController.cs`_

<details>
  <summary>Este método utiliza as entradas da pessoa usuária pelo <code>Console</code> para criar uma nova pessoa jogadora e adicionar ao banco de dados</summary><br />
</details>

### 2. Funcionalidade de adicionar um novo estúdio de jogos ao banco de dados

_Implementado o método `AddGameStudio()` no arquivo `src/TrybeGames/TrybeGamesController.cs`_

<details>
  <summary>Este método utiliza as entradas da pessoa usuária pelo <code>Console</code> para criar um novo Estúdio de Jogos e adicionar ao banco de dados</summary><br />
</details>



### 3. Funcionalidade de adicionar novo Jogo ao Banco de dados

_Implementado o método `AddGame()` no arquivo `src/TrybeGames/TrybeGamesController.cs`_

<details>
  <summary>Este método utiliza as entradas da pessoa usuária pelo <code>Console</code> para criar um novo Jogo e adicionar ao banco de dados</summary><br />

  É recebido da pessoa usuária os seguintes dados de um jogo:
   1. Nome (`Name`).
   2. Data de lançamento (`ReleaseDate`).
   3. Tipo de jogo (`GameType`).
</details>



### 4. Funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos

_Implementado o método `GetGamesDevelopedBy()` no arquivo `src/TrybeGames/Database/TrybeGamesDatabase.cs`_

<details>
  <summary>Este método recebe por parâmetro um estúdio de jogos e retorna todos os jogos que aquele estúdio desenvolveu</summary><br />

  Por se tratar de um método da classe `TrybeGamesDatabase`, este não lida com entradas e interações com a pessoa usuária. Porém ele é utilizado pelo método `QueryGamesFromStudio` para buscar os jogos desenvolvidos pelo estúdio selecionado neste método.
  
</details>

### 5. Funcionalidade de buscar jogos jogados por uma pessoa jogadora

_Implementado o método `GetGamesPlayedBy()` no arquivo `src/TrybeGames/Database/TrybeGamesDatabase.cs`_

<details>
  <summary>Este método recebe por parâmetro uma pessoa jogadora e retorna todos os jogos jogados por aquela pessoa jogadora</summary><br />

  Por se tratar de um método da classe `TrybeGamesDatabase`, este não lida com entradas e interações com a pessoa usuária. Porém ele é utilizado pelo método `QueryGamesPlayedByPlayer` para buscar os jogos jogados pela pessoa jogadora selecionada neste método.


</details>



### 6. Funcionalidade de buscar jogos comprados por uma pessoa jogadora

_Implementado o método `GetGamesOwnedBy()` no arquivo `src/TrybeGames/Database/TrybeGamesDatabase.cs`_

<details>
  <summary>Este método recebe por parâmetro uma pessoa jogadora e retorna todos os jogos que aquela pessoa jogadora possui</summary><br />

  Por se tratar de um método da classe `TrybeGamesDatabase`, este não lida com entradas e interações com a pessoa usuária. Porém é utilizado pelo método `QueryGamesBoughtByPlayer` para buscar os jogos comprados pela pessoa jogadora selecionada neste método.

</details>



### 7. Funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor

_Implementado o método `GetGamesWithStudio()` no arquivo `src/TrybeGames/Database/TrybeGamesDatabase.cs`_

<details>
  <summary>Este método não recebe parâmetros e retorna as informações de jogos e seus estúdios de acordo com o DTO GameWithStudio</summary><br />
  
  O DTO `GameWithStudio` está presente no arquivo `src/TrybeGames/DTO/GameWithStudio.cs` e segue a seguinte estrutura

  ```csharp
  public class GameWithStudio
  {
      public string? GameName { get; set; } // nome do jogo
      public string? StudioName { get; set; } // nome do estúdio que desenvolveu o jogo
      public int NumberOfPlayers { get; set; } // número de pessoas jogadoras do jogo
  }
  ```

</details>


### 8. Funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados

_Implementado o método `GetGameTypes()` no arquivo `src/TrybeGames/Database/TrybeGamesDatabase.cs`_

<details>
  <summary>Este método não recebe parâmetros e retorna as informações dos tipos de jogos dentre os jogos cadastrados</summary><br />

</details>



### 9. Funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras

_Implementado o método `GetStudiosWithGamesAndPlayers()` no arquivo `src/TrybeGames/Database/TrybeGamesDatabase.cs`_

<details>
  <summary>Este método não recebe parâmetros e retorna as informações dos estúdios de jogos, seus jogos e para cada jogo, suas pessoas jogadoras de acordo com os DTOs StudioGamesPlayers e GamePlayer</summary><br />

  
  Os DTOs `StudioGamesPlayers` e `GamePlayer` estão presentes no arquivo `src/TrybeGames/DTO/StudioGamesPlayers.cs` e segue a seguinte estrutura

  ```csharp
  public class GamePlayer
  {
      public string GameName = ""; // nome do jogo
      public List<Player>? Players { get; set; } // lista das pessoas jogadoras que jogam este jogo.
  }
  public class StudioGamesPlayers
  {
      public string? GameStudioName { get; set; } // nome do estúdio de jogos
      public List<GamePlayer>? Games { get; set; } // lista das informações de jogos e pessoas jogadoras baseada no DTO GamePlayer
  }
  ```


</details>



### 10. Testes da funcionalidade de buscar jogos jogados por uma pessoa jogadora

_Implementado o método `TestGetGamesPlayedBy()` no arquivo `src/TrybeGames.Test/TestTrybeGamesDatabase.cs`_

<details>
  <summary>Este método implementa os testes do método indicado</summary><br />

  No método `TestGetGamesPlayedBy()` foi criado um teste para a funcionalidade de buscar os jogos jogados por uma pessoa jogadora implementada no método `GetGamesPlayedBy` do arquivo `src/TrybeGames/Database/TrybeGamesDatabase.cs`.

  

</details>

## :warning: Atenção :warning:

### Todos os arquivos desenvolvidos estão presentes na árvore descrita. Todos os outros foram desenvolvidos pela Trybe! :white_check_mark:


