using UnityEngine;

public struct Player
{
  PlayerId playerId;
  GamePlaySide playSide;
  GameObject playerGameObject;
  //TODO: Controller whether bot or player

  public Player(PlayerId playerId, GameObject playerGameObject, GamePlaySide playSide)
  {
    this.playerId = playerId;
    this.playerGameObject = playerGameObject;
    this.playSide = playSide;
  }
}

public struct PlayerScoreStatus
{
  
}
