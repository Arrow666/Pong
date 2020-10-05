public enum GameStatusEnum
{
  ReadyToStart,
  GameBegun,
  GameResume,
  GamePaused,
  GameFinished
}

public class GameStatusStateMachine
{
  GameStatusState currentGameStatusState;

  public GameStatusStateMachine(GameStatusEnum gameStatus)
  {
    currentGameStatusState = GameStatusStatesFactory.GetGameState(gameStatus);
  }

  public void ChangeGameStatus(GameStatusEnum gameStatus)
  {
    currentGameStatusState.Exit();
    currentGameStatusState = GameStatusStatesFactory.GetGameState(gameStatus);
    currentGameStatusState.Enter();
  }
}
