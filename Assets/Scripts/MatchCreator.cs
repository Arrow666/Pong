using UnityEngine;

public class MatchCreator : MonoBehaviour
{
  [SerializeField] Vector3[] paddleSpawnPositions;
  [SerializeField] MatchModeStructFactory matchModeFactory;

  public IMatch CreateMatch()
  {
    switch (matchModeFactory.gameModeTypes)
    {
      case GameModeTypes.SinglePlayer:
        {
          SinglePlayerMatch singlePlayerMatch = new SinglePlayerMatch(matchModeFactory.GetSinglePlayerMatchCreationStructure(), paddleSpawnPositions);
          return singlePlayerMatch;
        }
      case GameModeTypes.TwoPlayer:
        {
          TwoPlayerMatch twoPlayerMatch = new TwoPlayerMatch(matchModeFactory.GetTwoPlayerMatchCreationStructure(), paddleSpawnPositions);
          return twoPlayerMatch;
        }
      default:
        //TODO: Implement Null Object for Match
        return null;
    }
  }
}
