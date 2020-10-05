using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerMatch : IMatch
{
  readonly ScoreMaintainer scoreMaintainer;
  readonly Dictionary<PlayerId, Player> players;
  readonly Vector3[] playerSpawnPositions;

  public SinglePlayerMatch(SinglePlayerMatchModeStructure sp_MatchModeStructure, Vector3[] playerSpawnPositions)
  {
    players = new Dictionary<PlayerId, Player>();
    this.playerSpawnPositions = playerSpawnPositions;


    if (sp_MatchModeStructure.playSide == GamePlaySide.Left)
    {
      var playerGObj = GameObject.Instantiate(sp_MatchModeStructure.playerToSpawn, playerSpawnPositions[0], Quaternion.identity);
      var botGObj = GameObject.Instantiate(sp_MatchModeStructure.playerToSpawn, playerSpawnPositions[1], Quaternion.identity);

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
      var botGObj = GameObject.Instantiate(sp_MatchModeStructure.playerToSpawn, playerSpawnPositions[0], Quaternion.identity);

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
    return scoreMaintainer.ScoreUpdate(playerScoredSide);
  }

  public void ScoreReset()
  {
    scoreMaintainer.ScoreReset();
  }
}

