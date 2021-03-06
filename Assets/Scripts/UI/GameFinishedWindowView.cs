﻿using UnityEngine;

public class GameFinishedWindowView : MonoBehaviour
{
  public WindowViewClass windowView;
  public BackToHomeButton backToHomeButton;

  private void OnEnable()
  {
    if (windowView == null)
    {
      Debug.LogError($"GameFinishedWindowView : windowView is not set in inspector", this);
    }
  }

  private void Start()
  {
    backToHomeButton.button.onClick.AddListener(GoHome);
  }

  private void GoHome()
  {
    Debug.Log("Back to Home");
    GameStatusStatesFactory.GetGameStateMachine().ChangeGameStatus(GameStatusEnum.ReadyToStart);
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
