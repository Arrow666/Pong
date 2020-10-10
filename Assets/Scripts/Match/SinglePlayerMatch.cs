using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SinglePlayerMatch : IMatch, IDisposable
{
  readonly ScoreMaintainer scoreMaintainer;
  readonly List<Player> players;
  readonly Vector3[] playerSpawnPositions;// 0 index is for leftSide and 1 index vice versa

  public bool IsMatchFinished { get; private set; }

  public SinglePlayerMatch(SinglePlayerMatchModeStructure sp_MatchModeStructure, Vector3[] _playerSpawnPositions)
  {
    players = new List<Player>();
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

      CreateBot(sp_MatchModeStructure, botGObj, GamePlaySide.Right);

      players.Add(player);
      players.Add(botPlayer);

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

      CreateBot(sp_MatchModeStructure, botGObj, GamePlaySide.Left);

      players.Add(player);
      players.Add(botPlayer);

      scoreMaintainer = new ScoreMaintainer(sp_MatchModeStructure.maxScoreToWin, true);
    }

    GameReadyToStartState.onStateEntered += DestroyPaddles;
  }

  private void CreateBot(SinglePlayerMatchModeStructure sp_MatchModeStructure, GameObject botGObj, GamePlaySide botToPlaySide)
  {
    switch (sp_MatchModeStructure.gameDifficultyTypes)
    {
      case GameDifficultyTypes.Easy:
        botGObj.AddComponent<BotPaddleEasy>().playSide = botToPlaySide;
        break;
      case GameDifficultyTypes.Normal:
        botGObj.AddComponent<BotPaddleNormal>().playSide = botToPlaySide;
        break;
      case GameDifficultyTypes.Hard:
        botGObj.AddComponent<BotPaddleHard>().playSide = botToPlaySide;
        break;
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

  public void ResetPositionsForNextTurn()
  {
    foreach (var player in players)
    {
      if (player.playSide == GamePlaySide.Left)
      {
        player.playerGameObject.transform.position = playerSpawnPositions[0];// Left
      }
      else
      {
        player.playerGameObject.transform.position = playerSpawnPositions[1];// Right
      }
    }
  }

  public GameScore GetFinalMatchScore()
  {
    GameScore gameScore = new GameScore();

    foreach (var player in players)
    {
      if (player.playSide == GamePlaySide.Left)
      {
        gameScore.leftPlayerName = player.playerGameObject.name;// Left player
        gameScore.leftPlayerScore = scoreMaintainer.PlayersIdnScore[player.playerId].ToString();
      }
      else
      {
        gameScore.rightPlayerName = player.playerGameObject.name;// Right
        gameScore.rightPlayerScore = scoreMaintainer.PlayersIdnScore[player.playerId].ToString();
      }
    }

    gameScore.totalScore = scoreMaintainer.MaximumScoreToWin.ToString();
    gameScore.playerNameWhoWon = players.Where(x => x.playerId == scoreMaintainer.GetWinnerId()).FirstOrDefault().playerGameObject.name;

    DestroyPaddles();

    return gameScore;

  }

  void DestroyPaddles()
  {
    foreach (var player in players)
    {
      if (player.playerGameObject != null)
      {
        GameObject.Destroy(player.playerGameObject);
      }
    }
  }

  public void Dispose()
  {
    GameReadyToStartState.onStateEntered -= DestroyPaddles;
    Debug.Log($"Dispsed");
  }

}

