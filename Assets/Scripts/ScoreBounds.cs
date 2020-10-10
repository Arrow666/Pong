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
      gameManager.UpdateScore(GamePlaySide.Right);// Right Player Scored
    }
    else
    {
      gameManager.UpdateScore(GamePlaySide.Left);// Left Player Scored
    }
    collision.gameObject.SetActive(false);
  }
}
