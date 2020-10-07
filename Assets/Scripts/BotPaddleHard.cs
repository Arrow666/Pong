using System.Collections;
using UnityEngine;

public class BotPaddleHard : MonoBehaviour, IPaddle
{
  public float movementSpeed = 8;
  public GameObject gameObjectToFollow;

  private int movementDirection;
  private float movementBounds;

  public Vector2 Velocity => velocity;
  public GamePlaySide playSide { get; set; }

  private Rigidbody2D myRigidBody;
  private Vector2 velocity;

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
    }
  }

  private void Update()
  {
    if (gameObjectToFollow == null)
      return;
    CalculateMoveDirection();
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
    if (gameObjectToFollow.transform.position.y > myRigidBody.position.y + 0.1f)
    {
      movementDirection += 1;
    }
    if (gameObjectToFollow.transform.position.y < myRigidBody.position.y - 0.1f)
    {
      movementDirection -= 1;
    }

    if (Mathf.Abs(gameObjectToFollow.transform.position.x) > 7.5f)
    {
      movementDirection *= -1;
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

