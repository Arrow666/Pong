using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
  public float startingMovementSpeed = 5f;
  private float currentMoveSpeed;

  private Vector2 movementDirection;
  private Rigidbody2D myRigidBody;

  private void Awake()
  {
    myRigidBody = GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    currentMoveSpeed = startingMovementSpeed;
    movementDirection = new Vector2(1, 0);
    myRigidBody.velocity = movementDirection * currentMoveSpeed;
  }

  public void SetMoveDirection(Vector2 moveDirection)
  {
    transform.position = Vector3.zero;
    gameObject.SetActive(true);

    currentMoveSpeed = startingMovementSpeed;
    movementDirection = moveDirection;
    myRigidBody.velocity = movementDirection * currentMoveSpeed;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    ContactPoint2D contactPoint2D = collision.GetContact(0);
    Vector2 reflectedDirection = Vector2.Reflect(movementDirection, contactPoint2D.normal);
    IPaddle paddle = collision.collider.GetComponent<IPaddle>();

    if (paddle != null)
    {
      if (paddle.Velocity.y > 0)
      {
        reflectedDirection = new Vector2(-movementDirection.x, 1);
        startingMovementSpeed += 0.5f;
      }
      else if (paddle.Velocity.y < 0)
      {
        reflectedDirection = new Vector2(-movementDirection.x, -1);
        startingMovementSpeed += 0.5f;
      }
      else
      {
        startingMovementSpeed -= 0.5f;
      }
      startingMovementSpeed = Mathf.Max(startingMovementSpeed, currentMoveSpeed);
    }

    movementDirection = reflectedDirection;
    myRigidBody.velocity = movementDirection * startingMovementSpeed;
  }


}
