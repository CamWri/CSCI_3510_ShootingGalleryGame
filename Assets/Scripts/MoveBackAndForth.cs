using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    [Header("Movement Offset")]
    public float xOffset = 2f;
    public float yOffset = 0f;

    public float zOffset = 0f;


    [Header("Movement Settings")]
    public float speed = 2f; // Speed of the back-and-forth movement

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingToTarget = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(xOffset, yOffset, zOffset);
    }

    void Update()
    {
        // Move toward the current target position
        transform.position = Vector3.MoveTowards(
            transform.position,
            movingToTarget ? targetPos : startPos,
            speed * Time.deltaTime
        );

        // If close enough to target, reverse direction
        if (Vector3.Distance(transform.position, movingToTarget ? targetPos : startPos) < 0.01f)
        {
            movingToTarget = !movingToTarget;
        }
    }
}
