using System;
using UnityEngine;

public class GamePriorStage : MonoBehaviour
{
  [SerializeField] StandaloneGameSelectionInputDetector standaloneGameSelectionInputDetector;
  [SerializeField] GameModeSelector gameModeSelector;
  [SerializeField] GameSelectionWindowView gameSelectionWindowView;
  [SerializeField] GameManager gameManager;

  private void OnEnable()
  {
    GameReadyToStartState.onStateEntered += () => Activate();
    GameReadyToStartState.onStateExit += () => DeActivate();

    standaloneGameSelectionInputDetector.verticalKeyInput += () => ChangeGameMode();
    standaloneGameSelectionInputDetector.enterKeyInput += () => StartGameMode();
  }

  private void ChangeGameMode()
  {
    gameModeSelector.ChangeGameMode();
  }

  private void StartGameMode()
  {
    gameModeSelector.StartGameMode();
    gameManager.MakeAMatch();
  }


  public void Activate()
  {
    standaloneGameSelectionInputDetector.Activate();
    gameSelectionWindowView.ActivateWindow();
  }

  public void DeActivate()
  {
    standaloneGameSelectionInputDetector.DeActivate();
    gameSelectionWindowView.DeActivateWindow();
  }

  private void OnDisable()
  {
    GameReadyToStartState.onStateEntered -= () => Activate();
    GameReadyToStartState.onStateExit -= () => DeActivate();

    standaloneGameSelectionInputDetector.verticalKeyInput -= () => ChangeGameMode();
    standaloneGameSelectionInputDetector.enterKeyInput -= () => StartGameMode();
  }

}
