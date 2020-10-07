using NUnit.Framework;

namespace Tests
{
  public class ScoreCalculatorTest
  {
    [Test]
    public void GameCompletedOn_LeftPlayerWin_Pass()
    {
      ScoreMaintainer scoreCalculator = new ScoreMaintainer(5);
      for (int i = 0; i < 5; i++)
      {
        scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      }

      /*Game Completed at this point with L5_R0*/

      Assert.IsTrue(scoreCalculator.IsThereAWinner);
    }

    [Test]
    public void GameCompletedOn_RightPlayerWin_Pass()
    {
      ScoreMaintainer scoreCalculator = new ScoreMaintainer(5);
      for (int i = 0; i < 5; i++)
      {
        scoreCalculator.ScoreUpdate(GamePlaySide.Right);
      }

      /*Game Completed at this point with L0_R5*/

      Assert.IsTrue(scoreCalculator.IsThereAWinner);
    }

    [Test]
    public void GameCompletedOn_ScoreDifference_L5_R3_Pass()
    {
      ScoreMaintainer scoreCalculator = new ScoreMaintainer(5);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);//L3

      scoreCalculator.ScoreUpdate(GamePlaySide.Right);
      scoreCalculator.ScoreUpdate(GamePlaySide.Right);
      scoreCalculator.ScoreUpdate(GamePlaySide.Right);//R3

      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);//L5

      /*Game Completed at this point with L5_R3*/

      Assert.IsTrue(scoreCalculator.IsThereAWinner);
    }

    [Test]
    public void GameCompletedOn_ScoreDifference_L3_R2_Fail()
    {
      ScoreMaintainer scoreCalculator = new ScoreMaintainer(5);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);//L3

      scoreCalculator.ScoreUpdate(GamePlaySide.Right);
      scoreCalculator.ScoreUpdate(GamePlaySide.Right);//R2

      /*Game Didn't Complete at this point with L3_R2*/

      Assert.IsFalse(scoreCalculator.IsThereAWinner);
    }

    [Test]
    public void AfterGameCompleted_PlayersScoreShouldNotIncrement_Pass()
    {
      /*Simulating for Score Diffrence of L5_R2*/
      ScoreMaintainer scoreCalculator = new ScoreMaintainer(5);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);//L3

      scoreCalculator.ScoreUpdate(GamePlaySide.Right);
      scoreCalculator.ScoreUpdate(GamePlaySide.Right);//R2

      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);//L5

      /*Game Completed at this point with L5_R2*/
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);//L5 +2
      scoreCalculator.ScoreUpdate(GamePlaySide.Right);
      scoreCalculator.ScoreUpdate(GamePlaySide.Right);//R2 +2

      Assert.AreEqual(5, scoreCalculator.PlayersIdnScore[PlayerId.One]);
      Assert.AreEqual(2, scoreCalculator.PlayersIdnScore[PlayerId.Two]);
    }

    [Test]
    public void WhenSideSwitched_AtStart_PlayerOneScoreTest_Pass()
    {
      ScoreMaintainer scoreCalculator = new ScoreMaintainer(5,true);//Side Switched in the beginning, PlayerOne is playing in Right Side
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);//L3

      scoreCalculator.ScoreUpdate(GamePlaySide.Right);
      scoreCalculator.ScoreUpdate(GamePlaySide.Right);//R2

      /*Game Didn't Complete at this point with L3_R2*/

      Assert.AreEqual(2, scoreCalculator.PlayersIdnScore[PlayerId.One]);
    }

    [Test]
    public void WhenSideSwitched_InBetween_PlayerOneScoreTest_Pass()
    {
      ScoreMaintainer scoreCalculator = new ScoreMaintainer(5);//Side Unchanged in the beginning, PlayerOne remains playing in Left Side
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);
      scoreCalculator.ScoreUpdate(GamePlaySide.Left);//L3

      scoreCalculator.SwitchSide();// Side switched

      scoreCalculator.ScoreUpdate(GamePlaySide.Right);
      scoreCalculator.ScoreUpdate(GamePlaySide.Right);//R2

      /*Game Didn't Complete at this point with L3_R2*/

      Assert.AreEqual(5, scoreCalculator.PlayersIdnScore[PlayerId.One]);
    }
  }
}
