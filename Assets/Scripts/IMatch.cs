public interface IMatch
{
  int ScoreUpdate(GamePlaySide playerScoredSide);
  void ScoreReset();
}