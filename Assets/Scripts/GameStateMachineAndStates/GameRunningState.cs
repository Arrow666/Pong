using System;

public class GameRunningState : GameStatusState
{
  public static event Action onStateEntered;
  public static event Action onStateExit;

  public override void Enter()
  {
    onStateEntered?.Invoke();
  }

  public override void Exit()
  {
    onStateExit?.Invoke();
  }
}
