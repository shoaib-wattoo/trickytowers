using UnityEngine;
using System.Collections;

public class ShapeMovementController : MonoBehaviour {

    public Transform rotationPivot;
    public float fallingSpeed = 2f;
    public float fastFallingSpeed = 5f;
    Rigidbody2D rigidbody2D;
    public bool isCollided = false;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void ShapeUpdate()
    {
        FreeFall();
    }

    public void RotateClockWise(bool isCw)
    {
        float rotationDegree = (isCw) ? 90.0f : -90.0f;

        transform.RotateAround(rotationPivot.position, Vector3.forward, rotationDegree);
    }

    public void MoveHorizontal(Vector2 direction)
    {
        float deltaMovement = (direction.Equals(Vector2.right)) ? 1.0f : -1.0f;

        // Modify position
        transform.position += new Vector3(deltaMovement, 0, 0);
    }

    public void FreeFall()
    {
        transform.position = new Vector3(
        transform.position.x,
        transform.position.y - (fallingSpeed * Time.deltaTime),
        transform.position.z);
    }
    
    public void InstantFall()
    {
        fallingSpeed = fastFallingSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (isCollided)
            return;

        isCollided = true;
        Services.GameService.currentShape = null;
        rigidbody2D.constraints = RigidbodyConstraints2D.None;
        FindObjectOfType<SpawnManager>().Spawn();
        //Destroy(this);
    }
}
