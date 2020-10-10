using System.Collections.Generic;
using UnityEngine;

public class MaxScoreList
{
  public static List<int> ScoreValues => new List<int>() { 5, 8, 10 };
}

public class GameManager : MonoBehaviour
{
  [SerializeField] GameRunningScoreBoardDisplay gameRunningScoreBoardDisplay;
  [SerializeField] GameFinishedScoreBoardDisplay gameFinishedScoreBoardDisplay;
  [SerializeField] MatchCreator matchCreator;
  GameStatusStateMachine gameStatusStateMachine;
  [SerializeField] BallServicer ballServicer;
  IMatch match;

  private void Start()
  {
    gameStatusStateMachine = new GameStatusStateMachine(GameStatusEnum.ReadyToStart);
  }

  public void CreateAMatch()
  {
    match = matchCreator.CreateMatch();
    StartAGame();
  }

  public void UpdateScore(GamePlaySide playerScoredSide)
  {
    if (match.IsMatchFinished == false)// For score update
    {
      int scoreBoardEntryToUpdate = match.ScoreUpdate(playerScoredSide);
      gameRunningScoreBoardDisplay.UpdateScore(playerScoredSide, scoreBoardEntryToUpdate);
      match.ResetPositionsForNextTurn();
      ballServicer.ServeTheNextBall(playerScoredSide);
    }

    CheckToSeeIsTheMatchFinished();
  }

  private void CheckToSeeIsTheMatchFinished()
  {
    if (match.IsMatchFinished == true)
    {
      GameScore finalGameScore = match.GetFinalMatchScore();
      gameFinishedScoreBoardDisplay.SetGameScore(finalGameScore);
      gameStatusStateMachine.ChangeGameStatus(GameStatusEnum.GameFinished);
      Debug.Log("Game Finished!!");
    }
  }

  private void StartAGame()
  {
    gameStatusStateMachine.ChangeGameStatus(GameStatusEnum.GameBegun);
  }

}
