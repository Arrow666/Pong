using UnityEngine;

public class GameStatusStateMachine
{
  GameStatusState currentGameStatusState;
  GameStatusEnum currentGameStatusEnum = GameStatusEnum.None;

  public GameStatusEnum PreviousGameStatusEnum { get; private set; }

  public GameStatusStateMachine(GameStatusEnum gameStatus)
  {
    GameStatusStatesFactory.SetGameStateMachine(this);// Set GameStatusStateMachine in Factory
    currentGameStatusState = GameStatusStatesFactory.GetGameState(gameStatus);
    ChangeGameStatus(gameStatus);// To enter the currentGameStatusState
    currentGameStatusEnum = gameStatus;// To be set after currentGameStatusState has been entered
  }

  public void ChangeGameStatus(GameStatusEnum gameStatus)
  {
    if (currentGameStatusEnum == gameStatus)
    {
      Debug.LogWarning($"GameStatusStateMachine : Trying to set an already active {currentGameStatusEnum} GameStatusState!!");
      return;
    }

    if (currentGameStatusState != null)
    {
      PreviousGameStatusEnum = currentGameStatusEnum;
      currentGameStatusEnum = gameStatus;
      currentGameStatusState.Exit();
    }
    Debug.Log($"Game Current State : {currentGameStatusEnum}");
    currentGameStatusState = GameStatusStatesFactory.GetGameState(gameStatus);
    currentGameStatusState.Enter();
  }

  public void BackToPreviousState()
  {
    ChangeGameStatus(PreviousGameStatusEnum);
  }

}
