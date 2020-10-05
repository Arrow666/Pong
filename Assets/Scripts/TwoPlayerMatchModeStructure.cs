using System.Collections.Generic;
using UnityEngine;

public struct TwoPlayerMatchModeStructure
{
  public GameObject playerToSpawn;
  public GamePlaySide playSide;
  public int maxScoreToWin;

  public TwoPlayerMatchModeStructure(GameObject playerToSpawn, GamePlaySide playSide, int maxScoreToWin)
  {
    this.playerToSpawn = playerToSpawn;
    this.playSide = playSide;
    this.maxScoreToWin = maxScoreToWin;
  }

  public static List<int> dualModeMaxScoreList => new List<int>() { 5, 8, 10 };
}

