using System.Collections.Generic;

public class GameStatusStatesFactory
{
  public static GameStatusStateMachine gameStatusStateMachine;
  static Dictionary<GameStatusEnum, GameStatusState> gameStatusStatesDictionary;

  static GameStatusStatesFactory()
  {
    gameStatusStatesDictionary = new Dictionary<GameStatusEnum, GameStatusState>
    {
      { GameStatusEnum.ReadyToStart, new GameReadyToStartState() },
      { GameStatusEnum.GameBegun, new GameBegunState() },
      { GameStatusEnum.GameRunning, new GameRunningState() },
      { GameStatusEnum.GamePaused, new GamePauseState() },
      { GameStatusEnum.GameFinished, new GameFinishedState() }
    };
  }

  public static GameStatusState GetGameState(GameStatusEnum gameStatusEnum)
  {
    return gameStatusStatesDictionary[gameStatusEnum];
  }

  public static void SetGameStateMachine(GameStatusStateMachine _gameStatusStateMachine)
  {
    gameStatusStateMachine = _gameStatusStateMachine;
  }

  public static GameStatusStateMachine GetGameStateMachine()
  {
    return gameStatusStateMachine;
  }
}