using UnityEngine;

public class GameBeganStage : MonoBehaviour
{
  [SerializeField] GameBeganWindowView gameBeganWindowView;

  private void OnEnable()
  {
    GameBegunState.onStateEntered += Activate;
    GameReadyToStartState.onStateEntered += DeActivate;
    GameFinishedState.onStateEntered += DeActivate;
  }

  private void OnDisable()
  {
    GameBegunState.onStateEntered -= Activate;
    GameReadyToStartState.onStateEntered -= DeActivate;
    GameFinishedState.onStateEntered -= DeActivate;
  }

  private void Activate()
  {
    gameBeganWindowView.ActivateWindow();
  }

  private void DeActivate()
  {
    gameBeganWindowView.DeActivateWindow();
  }

}
