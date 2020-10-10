using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDownOnGameToBegun : MonoBehaviour
{
  [SerializeField] Text countDownText;
  private float startValue = 0.4f;
  private float endValue = 1.2f;
  IEnumerator easeInBackRoutine;

  public void DisplayCountDown(float totalTimeForCountDown)
  {
    if (easeInBackRoutine != null)
    {
      StopCoroutine(easeInBackRoutine);
    }
    easeInBackRoutine = EaseInOutBackCoRoutine(totalTimeForCountDown);
    StartCoroutine(easeInBackRoutine);
  }

  public void StopCountDown()
  {
    countDownText.gameObject.SetActive(false);
    if (easeInBackRoutine != null)
    {
      StopCoroutine(easeInBackRoutine);
    }
  }

  IEnumerator EaseInOutBackCoRoutine(float totalTimeForCountDown)
  {
    countDownText.gameObject.SetActive(true);

    countDownText.text = totalTimeForCountDown.ToString();
    while (totalTimeForCountDown >= 0)
    {
      float currentRemainingTime = startValue;
      while (currentRemainingTime < 1.0f)
      {
        currentRemainingTime += Time.deltaTime;
        float c = currentRemainingTime < 0.1f
        ? (Mathf.Pow(2 * currentRemainingTime, 2) * ((endValue + 1) * 2 * currentRemainingTime - endValue)) / 2f
        : (Mathf.Pow(2 * currentRemainingTime - 2, 2) * ((endValue + 1) * (currentRemainingTime * 2 - 2) + endValue) + 2) / 2f;

        countDownText.transform.localScale = new Vector2(c, c);
        yield return null;
      }

      totalTimeForCountDown -= 1;
      countDownText.transform.localScale = new Vector2(1, 1);
      countDownText.text = (totalTimeForCountDown > 0) ? totalTimeForCountDown.ToString() : "GO !!";
      if (totalTimeForCountDown < 0)
      {
        countDownText.gameObject.SetActive(false);
      }
    }

  }

}
