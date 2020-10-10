using System;
using System.Collections;
using UnityEngine;

public class BallServicer : MonoBehaviour
{
  [SerializeField] float firstServiceDelayTime = 3f;
  [SerializeField] float inBetweenServiceDelayTime = 1f;
  [SerializeField] CountDownOnGameToBegun countDownOnGameToBegun;
  [SerializeField] Ball ballPrefab;
  [HideInInspector] public bool ballIsServed = false;
  Ball currentBall;
  Vector2 ballLaunchDirection;

  WaitForSeconds delayServiceWaitForSeconds;
  WaitForSeconds delayinBetweenServiceWaitForSeconds;
  IEnumerator startServiceRoutine;
  IEnumerator inBetweenServiceRoutine;

  private void OnEnable()
  {
    delayServiceWaitForSeconds = new WaitForSeconds(firstServiceDelayTime);
    delayinBetweenServiceWaitForSeconds = new WaitForSeconds(inBetweenServiceDelayTime);

    GameBegunState.onStateEntered += () => StartService();
    GameBegunState.onStateExit += () => StopService();

    GameRunningState.onStateEntered += () => InBetweenService();
    GameRunningState.onStateExit += () => StopInBetweenService();
  }


  private void OnDisable()
  {
    GameBegunState.onStateEntered -= () => StartService();
    GameBegunState.onStateExit -= () => StopService();

    GameRunningState.onStateEntered -= () => InBetweenService();
    GameRunningState.onStateExit -= () => StopInBetweenService();
  }

  public void ServeTheNextBall(GamePlaySide lastPlayerScoredSide)
  {
    ballIsServed = false;
    SetBallLaunchDirection(lastPlayerScoredSide);
    InBetweenService();
  }


  private void StartService()
  {
    startServiceRoutine = StartServiceCounterCoroutine();
    StartCoroutine(startServiceRoutine);

    countDownOnGameToBegun.DisplayCountDown(firstServiceDelayTime);
  }

  private void InBetweenService()
  {
    if (ballIsServed == false)
    {
      inBetweenServiceRoutine = InBetweenServiceCounterCoroutine();
      StartCoroutine(inBetweenServiceRoutine);
    }
  }

  private void StopService()
  {
    if (startServiceRoutine != null)
    {
      StopCoroutine(startServiceRoutine);
    }

    countDownOnGameToBegun.StopCountDown();
  }

  private void StopInBetweenService()
  {
    if (inBetweenServiceRoutine != null)
    {
      StopCoroutine(inBetweenServiceRoutine);
    }
  }

  IEnumerator StartServiceCounterCoroutine()
  {
    yield return delayServiceWaitForSeconds;
    currentBall = Instantiate(ballPrefab);
    ballIsServed = true;
    GameStatusStatesFactory.GetGameStateMachine().ChangeGameStatus(GameStatusEnum.GameRunning);
  }

  IEnumerator InBetweenServiceCounterCoroutine()
  {
    yield return delayinBetweenServiceWaitForSeconds;
    currentBall.SetMoveDirection(ballLaunchDirection);
    ballIsServed = true;
  }

  private void SetBallLaunchDirection(GamePlaySide lastPlayerScoredSide)
  {
    if(lastPlayerScoredSide == GamePlaySide.Left)
    {
      ballLaunchDirection = new Vector2(1, 0);
    }
    else
    {
      ballLaunchDirection = new Vector2(-1, 0);
    }
  }

}
