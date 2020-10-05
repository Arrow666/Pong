using UnityEngine;

public class MatchModeStructFactory : MonoBehaviour
{
  [SerializeField] GameObject playerToSpawn;
  public GamePlaySide playSide;
  public GameDifficultyTypes gameDifficultyTypes;
  public int maxScoreToWin;

  public SinglePlayerMatchModeStructure GetSinglePlayerMatchCreationStructure()
  {
    return new SinglePlayerMatchModeStructure(playerToSpawn, playSide, gameDifficultyTypes, maxScoreToWin);
  }

  public TwoPlayerMatchModeStructure GetTwoPlayerMatchCreationStructure()
  {
    return new TwoPlayerMatchModeStructure(playerToSpawn, playSide, maxScoreToWin);
  }

}
