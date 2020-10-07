using UnityEngine;

public class ScoreBounds : MonoBehaviour
{
  public bool leftBound;
  GameManager gameManager;

  private void Start()
  {
    gameManager = FindObjectOfType<GameManager>();
    if(gameManager == null)
    {
      Debug.LogError($"No GameManager Found in scene", this);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (leftBound == true)
    {
      gameManager.UpdateScore(GamePlaySide.Left);
    }
    else
    {
      gameManager.UpdateScore(GamePlaySide.Right);
    }
    collision.gameObject.SetActive(false);
  }
}
