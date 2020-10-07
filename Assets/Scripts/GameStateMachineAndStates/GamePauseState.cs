using System;
using UnityEngine;

public class GamePauseState : GameStatusState
{
  public static event Action onStateEntered;
  public static event Action onStateExit;

  public override void Enter()
  {
    Time.timeScale = 0;
    onStateEntered?.Invoke();
  }

  public override void Exit()
  {
    Time.timeScale = 1;
    onStateExit?.Invoke();
  }
}
