using UnityEngine;

public class GamePausedWindowView : MonoBehaviour
{
  public WindowViewClass windowView;

  private void OnEnable()
  {
    if (windowView == null)
    {
      Debug.LogError($"GamePausedWindowView : windowView is not set in inspector", this);
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
