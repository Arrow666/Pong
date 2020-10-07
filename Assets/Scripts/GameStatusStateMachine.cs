using UnityEngine;

public class GameStatusStateMachine
{
  GameStatusState currentGameStatusState;
  GameStatusEnum gameStatusEnum = GameStatusEnum.None;

  public GameStatusStateMachine(GameStatusEnum gameStatus)
  {
    currentGameStatusState = GameStatusStatesFactory.GetGameState(gameStatus);
    ChangeGameStatus(gameStatus);// To enter the currentGameStatusState
    gameStatusEnum = gameStatus;// To be set after currentGameStatusState has been entered
  }

  public void ChangeGameStatus(GameStatusEnum gameStatus)
  {
    if (gameStatusEnum == gameStatus)
    {
      Debug.LogWarning($"GameStatusStateMachine : Trying to set an already active {gameStatusEnum} GameStatusState!!");
      return;
    }

    if (currentGameStatusState != null)
    {
      currentGameStatusState.Exit();
    }
    currentGameStatusState = GameStatusStatesFactory.GetGameState(gameStatus);
    currentGameStatusState.Enter();
  }
}
