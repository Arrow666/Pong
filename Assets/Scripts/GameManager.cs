using System.Collections.Generic;
using UnityEngine;

public class MaxScoreList
{
  public static List<int> ScoreValues => new List<int>() { 5, 8, 10 };
}

public class GameManager : MonoBehaviour
{

  //CheckList:
  /*
   * Win/Lose logic
   * Game modes for bot, PvP(Single Player, Two Player)
   * Difficulty options for bots Easy/Normal/Hard
   * Options to select Maximum wins
   * Selection for side Left/Right
   * Leader board
   */

  [SerializeField] ScoreBoardDisplay scoreBoard;
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
      scoreBoard.UpdateScore(playerScoredSide, scoreBoardEntryToUpdate);
      match.ResetPositions();
      ballServicer.ServeTheNextBall();
    }

    CheckToSeeIsTheMatchFinished();
  }

  private void CheckToSeeIsTheMatchFinished()
  {
    if (match.IsMatchFinished == true)
    {
      gameStatusStateMachine.ChangeGameStatus(GameStatusEnum.GameFinished);
      Debug.Log("Game Finished!!");
    }
  }

  private void StartAGame()
  {
    gameStatusStateMachine.ChangeGameStatus(GameStatusEnum.GameBegun);
  }

}
