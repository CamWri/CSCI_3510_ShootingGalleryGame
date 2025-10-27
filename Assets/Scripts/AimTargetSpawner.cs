using UnityEngine;

public class AimTargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // The reference to the active target in the scene

    // Move the target to a random position within this cube’s bounds
    public void MoveTarget()
    {
        if (targetPrefab == null) return;

        // Get cube bounds
        Vector3 center = transform.position;
        Vector3 size = transform.localScale;

        // Random position inside the cube
        Vector3 randomPos = center + new Vector3(
            Random.Range(-size.x / 2f, size.x / 2f),
            Random.Range(-size.y / 2f, size.y / 2f),
            Random.Range(-size.z / 2f, size.z / 2f)
        );

        // Move the target object (the one in the scene)
        targetPrefab.transform.position = randomPos;
    }
}
