using UnityEngine;

public class BlinkingUI : MonoBehaviour
{
  public GameObject gameObjectToBlink;
  private void OnEnable()
  {
    if (gameObjectToBlink != null)
    {
      InvokeRepeating("StartBlinkingPlayerWhoWon", 0.8f, 0.8f);
    }
    else
    {
      Debug.LogWarning($"BlinkingUI : gameObjectToBlink is not set in inspector", this);
    }
  }

  private void OnDisable()
  {
    CancelInvoke("StartBlinkingPlayerWhoWon");
  }

  public void StartBlinkingPlayerWhoWon()
  {
    bool activeToggle = !gameObjectToBlink.activeInHierarchy;
    gameObjectToBlink.SetActive(activeToggle);
    Debug.Log($"Player won");
  }
}
