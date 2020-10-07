using UnityEngine;

public class GamePausedStage : MonoBehaviour
{
  [SerializeField] GamePausedWindowView gamePausedWindowView;
  [SerializeField] StandaloneGamePausedInputDetector standaloneGamePausedInputDetector;
  bool isGamePaused = false;

  private void OnEnable()
  {
    GamePauseState.onStateEntered += () => Activate();
    GamePauseState.onStateExit += () => DeActivate();

    GameBegunState.onStateEntered += () => ActivateInputDetector();
    GameFinishedState.onStateEntered += () => DeActivateInputDetector();

    standaloneGamePausedInputDetector.escapeKeyInput += () => PauseUnpause();
  }

  private void OnDisable()
  {
    GamePauseState.onStateEntered -= () => Activate();
    GamePauseState.onStateExit -= () => DeActivate();

    GameBegunState.onStateEntered -= () => ActivateInputDetector();
    GameFinishedState.onStateEntered -= () => DeActivateInputDetector();

    standaloneGamePausedInputDetector.escapeKeyInput -= () => PauseUnpause();
  }

  private void Start()
  {
    DeActivateInputDetector();
  }

  void PauseUnpause()
  {
    isGamePaused = !isGamePaused;
    if (isGamePaused == true)
    {
      GameStatusStatesFactory.GetGameStateMachine().ChangeGameStatus(GameStatusEnum.GamePaused);
    }
    else
    {
      GameStatusStatesFactory.GetGameStateMachine().BackToPreviousState();
    }
  }

  public void ActivateInputDetector()
  {
    isGamePaused = false;
    standaloneGamePausedInputDetector.Activate();
  }

  public void DeActivateInputDetector()
  {
    standaloneGamePausedInputDetector.DeActivate();
  }

  private void Activate()
  {
    gamePausedWindowView.ActivateWindow();
  }

  public void DeActivate()
  {
    gamePausedWindowView.DeActivateWindow();
  }

}