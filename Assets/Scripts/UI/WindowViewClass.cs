using UnityEngine;

public class WindowViewClass : MonoBehaviour
{
  public void ActivateWindow()
  {
    gameObject.SetActive(true);
  }

  public void DeActivateWindow()
  {
    gameObject.SetActive(false);
  }
}