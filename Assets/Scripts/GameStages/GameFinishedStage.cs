using UnityEngine;

public class GameFinishedStage : MonoBehaviour
{
  [SerializeField] GameFinishedWindowView gameFinishedWindowView;

  private void OnEnable()
  {
    GameFinishedState.onStateEntered += Activate;
    GameFinishedState.onStateExit += DeActivate;
  }

  private void OnDisable()
  {
    GameFinishedState.onStateEntered -= Activate;
    GameFinishedState.onStateExit -= DeActivate;
  }

  private void Activate()
  {
    gameFinishedWindowView.ActivateWindow();
  }

  public void DeActivate()
  {
    gameFinishedWindowView.DeActivateWindow();
  }
}
