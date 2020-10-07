using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardDisplay : MonoBehaviour
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
        rightPlayerScoreText.text = score.ToString();
        break;
      case GamePlaySide.Right:
        leftPlayerScoreText.text = score.ToString();
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