using UnityEngine;

public struct Player
{
  public PlayerId playerId;
  public GamePlaySide playSide;
  public GameObject playerGameObject;
  //TODO: Controller whether bot or player

  public Player(PlayerId playerId, GameObject playerGameObject, GamePlaySide playSide)
  {
    this.playerId = playerId;
    this.playerGameObject = playerGameObject;
    this.playSide = playSide;
  }
}

public struct GameScore
{
  public string leftPlayerName;
  public string leftPlayerScore;

  public string rightPlayerName;
  public string rightPlayerScore;

  public string playerNameWhoWon;

  public string totalScore;
}
