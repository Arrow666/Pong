using System;
using UnityEngine;

public class StandaloneGamePausedInputDetector : MonoBehaviour
{
  public event Action escapeKeyInput;

  private void Update()
  {
    if (Input.GetButtonDown("Cancel") == true)
    {
      escapeKeyInput?.Invoke();
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
