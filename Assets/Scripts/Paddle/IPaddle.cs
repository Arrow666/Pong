using UnityEngine;

public interface IPaddle
{
  Vector2 Velocity { get; }
  GamePlaySide playSide { get; set; }
}