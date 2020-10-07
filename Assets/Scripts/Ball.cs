using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
  public float movementSpeed;

  private Vector2 movementDirection;
  private Rigidbody2D myRigidBody;

  private void Awake()
  {
    myRigidBody = GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    movementDirection = new Vector2(1, 0);
    myRigidBody.velocity = movementDirection * movementSpeed;
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
        movementSpeed += 0.5f;
      }
      else if (paddle.Velocity.y < 0)
      {
        reflectedDirection = new Vector2(-movementDirection.x, -1);
        movementSpeed += 0.5f;
      }
      else
      {
        movementSpeed -= 0.5f;
      }
      movementSpeed = Mathf.Max(5, movementSpeed);
    }

    movementDirection = reflectedDirection;
    myRigidBody.velocity = movementDirection * movementSpeed;
  }


}
