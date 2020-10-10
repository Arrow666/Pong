using UnityEngine;
using UnityEngine.UI;

public class GameRunningScoreBoardDisplay : MonoBehaviour
{
  public Text leftPlayerScoreText;
  public Text rightPlayerScoreText;

  private void OnEnable()
  {
    GameBegunState.onStateEntered += () => ResetScore();
  }

  public void UpdateScore(GamePlaySide playSide, int score)
  {
    switch (playSide)
    {
      case GamePlaySide.Left:
        leftPlayerScoreText.text = score.ToString();
        break;
      case GamePlaySide.Right:
        rightPlayerScoreText.text = score.ToString();
        break;
    }
  }
  public void ResetScore()
  {
    rightPlayerScoreText.text = "0";
    leftPlayerScoreText.text = "0";
  }

  private void OnDisable()
  {
    GameBegunState.onStateEntered -= () => ResetScore();
  }

}