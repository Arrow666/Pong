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
  IMatch match;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      MakeAMatch();
    }
  }

  private void MakeAMatch()
  {
    //TODO: Match Should be Created as per Match Selection in UI i.e.
    //match = matchCreator.CreateMatch(GameModeTypes.SinglePlayer);
  }

  public void UpdateScore(GamePlaySide playerScoredSide)
  {
    scoreBoard.UpdateScore(playerScoredSide, match.ScoreUpdate(playerScoredSide));
  }

}
