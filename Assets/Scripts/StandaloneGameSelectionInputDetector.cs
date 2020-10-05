using System;
using UnityEngine;

public class StandaloneGameSelectionInputDetector : MonoBehaviour
{

  public event Action verticalKeyInput;
  public event Action enterKeyInput;

  private void Update()
  {
    if (Input.GetButtonDown("Vertical") == true)
    {
      verticalKeyInput?.Invoke();
    }

    if (Input.GetKeyDown(KeyCode.Return) == true)// Enter Key
    {
      enterKeyInput?.Invoke();
    }
  }

  public void Activate()
  {
    gameObject.SetActive(true);
  }

  public void DeActivate()
  {
    gameObject.SetActive(false);
  }

}
