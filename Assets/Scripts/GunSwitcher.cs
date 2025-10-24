using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject[] guns;
    private int currentGunIndex = 0;


    private void Awake() {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
            gun.SetActive(false);
        }
    }

    private void Start()
    {
        SelectGun(currentGunIndex);
    }

    public void SelectGun(int index)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(i == index);
        }

        currentGunIndex = index;
    }

    public void SwitchGun(int podiumGunIndex)
    {
        SelectGun(podiumGunIndex);
    }
}