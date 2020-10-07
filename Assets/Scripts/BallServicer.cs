using System;
using System.Collections;
using UnityEngine;

public class BallServicer : MonoBehaviour
{
  [SerializeField] float firstServiceDelayTime = 2f;
  [SerializeField] float inBetweenServiceDelayTime = 1f;
  [SerializeField] Ball ballPrefab;
  [HideInInspector] public bool ballIsServed = false;

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

  public void ServeTheNextBall()
  {
    ballIsServed = false;
    InBetweenService();
  }

  private void StartService()
  {
    startServiceRoutine = StartServiceCounterCoroutine();
    StartCoroutine(startServiceRoutine);
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
    Instantiate(ballPrefab);
    ballIsServed = true;
    GameStatusStatesFactory.GetGameStateMachine().ChangeGameStatus(GameStatusEnum.GameRunning);
  }

  IEnumerator InBetweenServiceCounterCoroutine()
  {
    yield return delayinBetweenServiceWaitForSeconds;
    Instantiate(ballPrefab);
    ballIsServed = true;
  }

}
