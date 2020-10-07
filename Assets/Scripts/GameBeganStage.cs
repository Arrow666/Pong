using UnityEngine;

public class GameBeganStage : MonoBehaviour
{
  [SerializeField] GameBeganWindowView gameBeganWindowView;
  [SerializeField] GameManager gameManager;

  private void OnEnable()
  {
    GameBegunState.onStateEntered += () => Activate();
  }

  private void Activate()
  {
    gameBeganWindowView.ActivateWindow();
  }

  private void OnDisable()
  {
    GameBegunState.onStateEntered -= () => Activate();
  }
}
