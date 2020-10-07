using UnityEngine;

public class Paddle : MonoBehaviour, IPaddle
{
  public float movementSpeed = 8;

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
  }

  private void Update()
  {
    CalculateMoveDirection();
  }

  private void FixedUpdate()
  {
    PerformMovement();
  }

  private void CalculateMoveDirection()
  {
    if (playSide == GamePlaySide.Left)
    {
      movementDirection = 0;
      if (Input.GetKey(KeyCode.W))
      {
        movementDirection += 1;
      }
      if (Input.GetKey(KeyCode.S))
      {
        movementDirection -= 1;
      }
    }
    else
    {
      movementDirection = 0;
      if (Input.GetKey(KeyCode.UpArrow))
      {
        movementDirection += 1;
      }
      if (Input.GetKey(KeyCode.DownArrow))
      {
        movementDirection -= 1;
      }
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
