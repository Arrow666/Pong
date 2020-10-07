using UnityEngine;

public class GameModeSelector : MonoBehaviour
{
  [SerializeField] MatchModeSelector matchModeSelector;
  [SerializeField] GameModeSelectedPlayerDisplayer gameModeSelectedPlayerDisplayer;

  GameModeTypes selectedGameMode;
  bool singlePlayerModeSelected = true;

  private void OnEnable()
  {
    selectedGameMode = GameModeTypes.SinglePlayer;
    gameModeSelectedPlayerDisplayer.SinglePlayerSelected();
  }

  public void ChangeGameMode()
  {
    singlePlayerModeSelected = !singlePlayerModeSelected;
    if (singlePlayerModeSelected == true)
    {
      selectedGameMode = GameModeTypes.SinglePlayer;
      gameModeSelectedPlayerDisplayer.SinglePlayerSelected();
    }
    else
    {
      selectedGameMode = GameModeTypes.TwoPlayer;
      gameModeSelectedPlayerDisplayer.TwoPlayerSelected();
    }
  }

  public void StartGameMode()
  {
    matchModeSelector.ChangeMatchMode(selectedGameMode);
  }
}
