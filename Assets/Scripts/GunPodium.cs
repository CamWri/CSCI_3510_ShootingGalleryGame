using UnityEngine;

public class GunPodium : MonoBehaviour
{
    public int gunIndex;
    public GameObject GunPrefab;
    public Transform gunDisplayTransformLocation;

    public float rotationSpeed = 30f;
    public float floatAmplitude = 0.1f;
    public float floatFrequency = 2f;

    private GameObject displayGun;

    private Vector3 initialDisplayPos;


    private void Start()
    {
        if (GunPrefab != null && gunDisplayTransformLocation != null)
        {
            displayGun = Instantiate(
                GunPrefab,
                gunDisplayTransformLocation.position,
                gunDisplayTransformLocation.rotation,
                gunDisplayTransformLocation
            );
        }

        initialDisplayPos = displayGun.transform.localPosition;
    }

    private void Update()
    {
        if (displayGun != null)
        {
            // Smooth rotation around Y-axis
            displayGun.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

            // Floating motion (up/down)
            float newY = initialDisplayPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            displayGun.transform.localPosition = new Vector3(initialDisplayPos.x, newY, initialDisplayPos.z);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        GunSwitcher switcher = other.GetComponentInChildren<GunSwitcher>();

        if (switcher != null)
        {
            switcher.SwitchGun(gunIndex);
        }
    }
}
