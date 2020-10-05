using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardDisplay : MonoBehaviour
{
  public Text gameStatusText;// To display "Paused", "Win", "Lose" literals
  public Text playerLeftText;
  public Text playerRightText;

  public void UpdateScore(GamePlaySide playSide, int score)
  {
    switch (playSide)
    {
      case GamePlaySide.Left:
        playerLeftText.text = score.ToString();
        break;
      case GamePlaySide.Right:
        playerRightText.text = score.ToString();
        break;
    }
  }
}