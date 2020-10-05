using UnityEngine;
using UnityEngine.UI;

public class GameModeSelectedPlayerDisplayer : MonoBehaviour
{
  public Image _1arrowIconPlayer;
  public Image _2arrowIconPlayer;

  public void SinglePlayerSelected()
  {
    _1arrowIconPlayer.gameObject.SetActive(true);
    _2arrowIconPlayer.gameObject.SetActive(false);
  }

  public void TwoPlayerSelected()
  {
    _1arrowIconPlayer.gameObject.SetActive(false);
    _2arrowIconPlayer.gameObject.SetActive(true);
  }
}
