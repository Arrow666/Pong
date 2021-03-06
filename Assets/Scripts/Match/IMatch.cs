﻿public interface IMatch
{
  bool IsMatchFinished { get; }
  int ScoreUpdate(GamePlaySide playerScoredSide);
  void ResetPositionsForNextTurn();
  GameScore GetFinalMatchScore();
}