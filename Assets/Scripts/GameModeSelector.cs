using UnityEngine;

public class GameModeSelector : MonoBehaviour
{
  [SerializeField] MatchModeSelector matchModeSelector;
  [SerializeField] GameModeSelectedPlayerDisplayer gameModePlayerSelectorUIToggler;
  GameModeTypes selectedGameMode;
  bool singlePlayerModeSelected = true;

  private void Start()
  {
    selectedGameMode = GameModeTypes.SinglePlayer;
    SelectGameMode();
  }
  private void Update()
  {
    if (Input.GetButtonDown("Vertical"))
    {
      singlePlayerModeSelected = !singlePlayerModeSelected;
      if (singlePlayerModeSelected == true)
      {
        selectedGameMode = GameModeTypes.SinglePlayer;
        gameModePlayerSelectorUIToggler.SinglePlayerSelected();
      }
      else
      {
        selectedGameMode = GameModeTypes.TwoPlayer;
        gameModePlayerSelectorUIToggler.TwoPlayerSelected();
      }
    }
  }

  public void SelectGameMode()
  {
    matchModeSelector.ChangeMatchMode(selectedGameMode);
  }
}
