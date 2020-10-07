using System.Collections;
using UnityEngine;

public class BotPaddleEasy : MonoBehaviour, IPaddle
{
  public float movementSpeed = 8;
  public GameObject gameObjectToFollow;

  private int movementDirection;
  private float movementBounds;

  public Vector2 Velocity => velocity;
  public GamePlaySide playSide { get; set; }

  private Rigidbody2D myRigidBody;
  private Vector2 velocity;
  private IEnumerator calculationCoroutine;


  private void Awake()
  {
    myRigidBody = GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    movementBounds = 5 - (transform.localScale.y * 0.5f);
    var ball = FindObjectOfType<Ball>();
    if (ball == null)
    {
      Debug.LogWarning($"NO GameObjectToFollow", this);
      InvokeRepeating("SearchForTheBall", 0.1f, 0.1f);
      return;
    }
    gameObjectToFollow = ball.gameObject;
    calculationCoroutine = IrregularCalculateDirection();
    StartCoroutine(calculationCoroutine);
  }

  private void SearchForTheBall()
  {
    if (gameObjectToFollow == null)
    {
      var ball = FindObjectOfType<Ball>();
      if (ball == null)
      {
        Debug.LogWarning($"Searching for GameObjectToFollow...", this);
        return;
      }
      gameObjectToFollow = ball.gameObject;
      calculationCoroutine = IrregularCalculateDirection();
      StartCoroutine(calculationCoroutine);
    }
  }

  IEnumerator IrregularCalculateDirection()
  {
    while (gameObjectToFollow != null)
    {
      CalculateMoveDirection();
      yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));//Following Duration
      movementDirection = 0;
      yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));//No movement Duration
    }
  }

  private void FixedUpdate()
  {
    if (gameObjectToFollow == null)
    {
      myRigidBody.MovePosition(new Vector2(myRigidBody.position.x, 0));
      return;
    }
    PerformMovement();
  }

  private void CalculateMoveDirection()
  {
    movementDirection = 0;
    if (gameObjectToFollow.transform.position.y > myRigidBody.position.y)
    {
      movementDirection += 1;
    }
    if (gameObjectToFollow.transform.position.y < myRigidBody.position.y)
    {
      movementDirection -= 1;
    }
  }

  private void PerformMovement()
  {
    velocity = new Vector2(0, movementDirection) * movementSpeed * Time.fixedDeltaTime;
    myRigidBody.position += velocity;
    ClampPaddlePosition();

    void ClampPaddlePosition()
    {
      if (myRigidBody.position.y > movementBounds)
      {
        velocity = Vector2.zero;
        myRigidBody.MovePosition(new Vector2(myRigidBody.position.x, movementBounds));
      }
      else if (myRigidBody.position.y < -movementBounds)
      {
        velocity = Vector2.zero;
        myRigidBody.MovePosition(new Vector2(myRigidBody.position.x, -movementBounds));
      }
    }

  }

}
