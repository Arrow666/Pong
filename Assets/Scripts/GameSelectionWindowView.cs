using UnityEngine;

public class GameSelectionWindowView : MonoBehaviour, IWindowView
{
  public GameObject gameSelectionWindow;

  public void ActivateWindow()
  {
    gameSelectionWindow.SetActive(true);
  }

  public void DeActivateWindow()
  {
    gameSelectionWindow.SetActive(false);
  }

}
