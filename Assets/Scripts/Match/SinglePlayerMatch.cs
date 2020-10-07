using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SinglePlayerMatch : IMatch
{
  readonly ScoreMaintainer scoreMaintainer;
  readonly Dictionary<PlayerId, Player> players;
  readonly Vector3[] playerSpawnPositions;// 0 index is for leftSide and 1 index vice versa

  public bool IsMatchFinished { get; private set; }

  public SinglePlayerMatch(SinglePlayerMatchModeStructure sp_MatchModeStructure, Vector3[] _playerSpawnPositions)
  {
    players = new Dictionary<PlayerId, Player>();
    playerSpawnPositions = _playerSpawnPositions;


    if (sp_MatchModeStructure.playSide == GamePlaySide.Left)
    {
      var playerGObj = GameObject.Instantiate(sp_MatchModeStructure.playerToSpawn, playerSpawnPositions[0], Quaternion.identity);
      playerGObj.name = "PlayerLeft";
      var botGObj = GameObject.Instantiate(sp_MatchModeStructure.playerToSpawn, playerSpawnPositions[1], Quaternion.identity);
      botGObj.name = "BotRight";

      Player player = new Player(PlayerId.One, playerGObj, GamePlaySide.Left);
      Player botPlayer = new Player(PlayerId.Two, botGObj, GamePlaySide.Right);

      playerGObj.AddComponent<Paddle>().playSide = GamePlaySide.Left;

      switch (sp_MatchModeStructure.gameDifficultyTypes)
      {
        case GameDifficultyTypes.Easy:
          botGObj.AddComponent<BotPaddleEasy>().playSide = GamePlaySide.Right;
          break;
        case GameDifficultyTypes.Normal:
          botGObj.AddComponent<BotPaddleNormal>().playSide = GamePlaySide.Right;
          break;
        case GameDifficultyTypes.Hard:
          botGObj.AddComponent<BotPaddleHard>().playSide = GamePlaySide.Right;
          break;
      }

      players.Add(PlayerId.One, player);
      players.Add(PlayerId.Two, botPlayer);

      scoreMaintainer = new ScoreMaintainer(sp_MatchModeStructure.maxScoreToWin);
    }
    else
    {
      var playerGObj = GameObject.Instantiate(sp_MatchModeStructure.playerToSpawn, playerSpawnPositions[1], Quaternion.identity);
      playerGObj.name = "PlayerRight";
      var botGObj = GameObject.Instantiate(sp_MatchModeStructure.playerToSpawn, playerSpawnPositions[0], Quaternion.identity);
      botGObj.name = "BotLeft";

      Player player = new Player(PlayerId.One, playerGObj, GamePlaySide.Right);
      Player botPlayer = new Player(PlayerId.Two, botGObj, GamePlaySide.Left);

      playerGObj.AddComponent<Paddle>().playSide = GamePlaySide.Right;

      switch (sp_MatchModeStructure.gameDifficultyTypes)
      {
        case GameDifficultyTypes.Easy:
          botGObj.AddComponent<BotPaddleEasy>().playSide = GamePlaySide.Left;
          break;
        case GameDifficultyTypes.Normal:
          botGObj.AddComponent<BotPaddleNormal>().playSide = GamePlaySide.Left;
          break;
        case GameDifficultyTypes.Hard:
          botGObj.AddComponent<BotPaddleHard>().playSide = GamePlaySide.Left;
          break;
      }

      players.Add(PlayerId.One, player);
      players.Add(PlayerId.Two, botPlayer);

      scoreMaintainer = new ScoreMaintainer(sp_MatchModeStructure.maxScoreToWin, true);
    }

  }

  public int ScoreUpdate(GamePlaySide playerScoredSide)
  {
    int scoreToUpdate = scoreMaintainer.ScoreUpdate(playerScoredSide);
    if (scoreMaintainer.IsThereAWinner == true)
    {
      IsMatchFinished = true;
    }
    return scoreToUpdate;
  }

  public void ResetPositions()
  {
    foreach (Player player in players.Values.ToList())
    {
      if(player.playSide == GamePlaySide.Left)
      {
        player.playerGameObject.transform.position = playerSpawnPositions[0];// Left
      }
      else
      {
        player.playerGameObject.transform.position = playerSpawnPositions[1];// Right
      }
    }
  }

}

