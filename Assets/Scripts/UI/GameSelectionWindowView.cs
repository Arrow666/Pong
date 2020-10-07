using UnityEngine;

public class GameSelectionWindowView : MonoBehaviour
{
  public WindowViewClass windowView;

  private void OnEnable()
  {
    if(windowView == null)
    {
      Debug.LogError($"GameSelectionWindowView : windowView is not set in inspector", this);
    }
  }

  public void ActivateWindow()
  {
    windowView.ActivateWindow();
  }

  public void DeActivateWindow()
  {
    windowView.DeActivateWindow();
  }

}
