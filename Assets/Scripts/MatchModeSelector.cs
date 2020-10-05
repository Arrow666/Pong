using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchModeSelector : MonoBehaviour
{
  [SerializeField] MatchModeStructFactory matchModeFactory;
  [SerializeField] Dropdown playSideDropDown;
  [SerializeField] Dropdown gameDifficultyDropDown;
  [SerializeField] Dropdown maxScoreToWinDropDown;

  private void Start()
  {
    DrawSelectionOption();
  }

  #region DrawSelectionOption

  void DrawSelectionOption()
  {
    DrawPlaySideOption();
    DrawGameDifficultyOption();
    DrawMaxScoreToWinOption();
  }

  void DrawPlaySideOption()
  {
    List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

    foreach (var optionName in Enum.GetNames(typeof(GamePlaySide)))
    {
      options.Add(new Dropdown.OptionData(optionName));
    }

    playSideDropDown.ClearOptions();
    playSideDropDown.AddOptions(options);
  }

  void DrawGameDifficultyOption()
  {
    List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

    foreach (var optionName in Enum.GetNames(typeof(GameDifficultyTypes)))
    {
      options.Add(new Dropdown.OptionData(optionName));
    }

    gameDifficultyDropDown.ClearOptions();
    gameDifficultyDropDown.AddOptions(options);
  }

  void DrawMaxScoreToWinOption()
  {
    List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

    foreach (var optionName in MaxScoreList.ScoreValues)
    {
      options.Add(new Dropdown.OptionData(optionName.ToString()));
    }

    maxScoreToWinDropDown.ClearOptions();
    maxScoreToWinDropDown.AddOptions(options);
  }

  #endregion

  public void ChangeMatchMode(GameModeTypes gameMode)
  {
    switch (gameMode)
    {
      case GameModeTypes.SinglePlayer:
        {
          matchModeFactory.playSide = (GamePlaySide)playSideDropDown.value;
          matchModeFactory.gameDifficultyTypes = (GameDifficultyTypes)gameDifficultyDropDown.value;
          matchModeFactory.maxScoreToWin = Convert.ToInt32(maxScoreToWinDropDown.options[maxScoreToWinDropDown.value].text);
        }
        break;
      case GameModeTypes.TwoPlayer:
        {
          matchModeFactory.playSide = (GamePlaySide)playSideDropDown.value;
          matchModeFactory.maxScoreToWin = Convert.ToInt32(maxScoreToWinDropDown.options[maxScoreToWinDropDown.value].text);
        }
        break;
    }

  }
}
