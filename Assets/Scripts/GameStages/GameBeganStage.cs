using UnityEngine;

public class GameBeganStage : MonoBehaviour
{
  [SerializeField] GameBeganWindowView gameBeganWindowView;

  private void OnEnable()
  {
    GameBegunState.onStateEntered += () => Activate();
  }

  private void OnDisable()
  {
    GameBegunState.onStateEntered -= () => Activate();
  }

  private void Activate()
  {
    gameBeganWindowView.ActivateWindow();
  }

}
