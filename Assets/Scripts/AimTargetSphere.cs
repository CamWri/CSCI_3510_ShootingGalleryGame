using UnityEngine;

public class AimTargetSphere : Target
{
    private GameObject spawnZone;
    private AimTargetSpawner spawner;

    private void Start()
    {
        spawnZone = GameObject.FindWithTag("Spawner");
        spawner = spawnZone.GetComponent<AimTargetSpawner>();
    }

    public override void Process(RaycastHit hit)
    {
        spawner.MoveTarget();
        effectScript.Play(hit, hitSound, hitEffect, effectDuration);
    }
}
