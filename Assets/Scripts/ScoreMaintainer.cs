using System.Collections.Generic;
using System.Linq;

public enum PlayerId
{
  One,
  Two
}

public class ScoreMaintainer
{
  bool isSideSwitched = false;// When isSideSwapped is false then, Player 1 is on left and Player 2 is on right side of screen, else sides swapped
  Dictionary<PlayerId, int> playersIdnScore;

  int maximumScoreToWin = 0;

  public Dictionary<PlayerId, int> PlayersIdnScore => playersIdnScore;
  public bool IsGameOverFlag { get; private set; } = false;

  public void SwitchSide()
  {
    isSideSwitched = !(isSideSwitched);
  }

  /// <summary>
  /// When switchSide is false then, PlayerOne is on Left side and else Right side if true
  /// </summary>
  /// <param name="_maximumScoreToWin"></param>
  /// <param name="switchSide"></param>
  public ScoreMaintainer(int _maximumScoreToWin, bool switchSide = false)
  {
    playersIdnScore = new Dictionary<PlayerId, int>();
    playersIdnScore.Add(PlayerId.One, 0);
    playersIdnScore.Add(PlayerId.Two, 0);
    maximumScoreToWin = _maximumScoreToWin;
    isSideSwitched = switchSide;
  }


  public int ScoreUpdate(GamePlaySide playerScoredSide)
  {
    if (IsGameOverFlag) return 0;// 0 means GameOver

    int updatedScore = 0;

    if (isSideSwitched == false)
    {
      if (playerScoredSide == GamePlaySide.Left)
      {
        updatedScore = ++playersIdnScore[PlayerId.One];
        IsGameOverFlag = playersIdnScore[PlayerId.One] >= maximumScoreToWin ? true : false;
      }
      else
      {
        updatedScore = ++playersIdnScore[PlayerId.Two];
        IsGameOverFlag = playersIdnScore[PlayerId.Two] >= maximumScoreToWin ? true : false;
      }
    }
    else
    {
      if (playerScoredSide == GamePlaySide.Left)
      {
        updatedScore = ++playersIdnScore[PlayerId.Two];
        IsGameOverFlag = playersIdnScore[PlayerId.Two] >= maximumScoreToWin ? true : false;
      }
      else
      {
        updatedScore = ++playersIdnScore[PlayerId.One];
        IsGameOverFlag = playersIdnScore[PlayerId.One] >= maximumScoreToWin ? true : false;
      }
    }

    return updatedScore;
  }

  public void ScoreReset()
  {
    foreach (var key in playersIdnScore.Keys.ToList())
    {
      playersIdnScore[key] = 0;
    }
  }
}