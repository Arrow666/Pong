using System.Collections.Generic;

public class GameStatusStatesFactory
{
  static Dictionary<GameStatusEnum, GameStatusState> gameStatusStatesDictionary;

  static GameStatusStatesFactory()
  {
    gameStatusStatesDictionary = new Dictionary<GameStatusEnum, GameStatusState>
    {
      { GameStatusEnum.ReadyToStart, new GameReadyToStartState() },
      { GameStatusEnum.GameBegun, new GameBegunState() }
    };
  }

  public static GameStatusState GetGameState(GameStatusEnum gameStatusEnum)
  {
    return gameStatusStatesDictionary[gameStatusEnum];
  }
}