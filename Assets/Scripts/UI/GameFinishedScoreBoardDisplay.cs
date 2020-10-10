using UnityEngine;
using UnityEngine.UI;

public class GameFinishedScoreBoardDisplay : MonoBehaviour
{
  public Text leftPlayerName;
  public Text leftScoreText;

  public Text rightPlayerName;
  public Text rightScoreText;

  public Text playerNameWhoWonText;
  public Text totalScoreText;

  public void SetGameScore(GameScore gameScore)
  {
    leftPlayerName.text = gameScore.leftPlayerName;
    leftScoreText.text = gameScore.leftPlayerScore;

    rightPlayerName.text = gameScore.rightPlayerName;
    rightScoreText.text = gameScore.rightPlayerScore;

    totalScoreText.text = gameScore.totalScore;
    playerNameWhoWonText.text = $"{gameScore.playerNameWhoWon} Won!!";
  }

}
