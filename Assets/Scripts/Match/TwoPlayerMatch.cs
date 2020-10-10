using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TwoPlayerMatch : IMatch, IDisposable
{
  readonly ScoreMaintainer scoreMaintainer;
  readonly List<Player> players;
  readonly Vector3[] playerSpawnPositions;

  public bool IsMatchFinished { get; private set; }

  public TwoPlayerMatch(TwoPlayerMatchModeStructure tp_MatchModeStructure, Vector3[] _playerSpawnPositions)
  {
    players = new List<Player>();
    playerSpawnPositions = _playerSpawnPositions;


    if (tp_MatchModeStructure.playSide == GamePlaySide.Left)
    {
      var playerOneGObj = GameObject.Instantiate(tp_MatchModeStructure.playerToSpawn, playerSpawnPositions[0], Quaternion.identity);
      playerOneGObj.name = "PlayerLeft";
      var playerTwoGObj = GameObject.Instantiate(tp_MatchModeStructure.playerToSpawn, playerSpawnPositions[1], Quaternion.identity);
      playerTwoGObj.name = "PlayerRight";

      Player playerOne = new Player(PlayerId.One, playerOneGObj, GamePlaySide.Left);
      Player playerTwo = new Player(PlayerId.Two, playerTwoGObj, GamePlaySide.Right);

      playerOneGObj.AddComponent<Paddle>().playSide = GamePlaySide.Left;
      playerTwoGObj.AddComponent<Paddle>().playSide = GamePlaySide.Right;

      players.Add(playerOne);
      players.Add(playerTwo);

      scoreMaintainer = new ScoreMaintainer(tp_MatchModeStructure.maxScoreToWin);
    }
    else
    {
      var playerOneGObj = GameObject.Instantiate(tp_MatchModeStructure.playerToSpawn, playerSpawnPositions[1], Quaternion.identity);
      playerOneGObj.name = "PlayerRight";
      var playerTwoGObj = GameObject.Instantiate(tp_MatchModeStructure.playerToSpawn, playerSpawnPositions[0], Quaternion.identity);
      playerTwoGObj.name = "PlayerLeft";

      Player playerOne = new Player(PlayerId.One, playerOneGObj, GamePlaySide.Right);
      Player playerTwo = new Player(PlayerId.Two, playerTwoGObj, GamePlaySide.Left);

      playerOneGObj.AddComponent<Paddle>().playSide = GamePlaySide.Right;
      playerTwoGObj.AddComponent<Paddle>().playSide = GamePlaySide.Left;

      players.Add(playerOne);
      players.Add(playerTwo);

      scoreMaintainer = new ScoreMaintainer(tp_MatchModeStructure.maxScoreToWin, true);
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
  }

}

