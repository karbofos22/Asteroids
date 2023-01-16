using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryWeapon : MonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject laserShot;
    [SerializeField] private float laserShotReloadTime = 10;

    private int shotsMaxValue = 3;
    private int shotsCurrentValue = 3;
    private int reloadTime = 10;

    private void Update()
    {
        EventManager.SendLaserShotStatus(laserShotReloadTime, shotsCurrentValue);
        ShotReload();
    }
    private void OnLaserShot(InputValue value)
    {
            if (value.Get<float>() == 1 && shotsCurrentValue > 0)
            {
                Instantiate(laserShot, firePoint.transform.position, firePoint.transform.rotation);
                shotsCurrentValue--;
            }
    }
    private void ShotReload()
    {
        if (shotsCurrentValue < shotsMaxValue)
        {
            laserShotReloadTime -= Time.deltaTime;

            if (laserShotReloadTime <= 0)
            {
                shotsCurrentValue++;
                laserShotReloadTime = reloadTime;
            }
        }
    }
}
