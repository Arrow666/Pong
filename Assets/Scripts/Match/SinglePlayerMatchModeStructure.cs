using System.Collections.Generic;
using UnityEngine;

public struct SinglePlayerMatchModeStructure
{
  public GameObject playerToSpawn;
  public GamePlaySide playSide;
  public GameDifficultyTypes gameDifficultyTypes;
  public int maxScoreToWin;

  public SinglePlayerMatchModeStructure(GameObject playerToSpawn, GamePlaySide playSide, GameDifficultyTypes gameDifficultyTypes, int maxScoreToWin)
  {
    this.playerToSpawn = playerToSpawn;
    this.playSide = playSide;
    this.gameDifficultyTypes = gameDifficultyTypes;
    this.maxScoreToWin = maxScoreToWin;
  }

  public static List<int> singleModeMaxScoreList => new List<int>() { 5, 8, 10 };
}

