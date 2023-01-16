using TMPro;
using UnityEngine;

public class SecondaryWeaponStatus : MonoBehaviour
{
    private TextMeshProUGUI secondaryWeaponStatusText;

    void Start()
    {
        secondaryWeaponStatusText = GetComponent<TextMeshProUGUI>();
        EventManager.OnLaserShot.AddListener(DisplaySecondaryWeaponsStatus);
    }
    private void DisplaySecondaryWeaponsStatus(float reloadTime, int shotsValue)
    {
        if (shotsValue == 3)
        {
            secondaryWeaponStatusText.text = $"Laser Shots\r\nShots left: {shotsValue}\r\nMax clip capacity";
        }
        else
        {
            secondaryWeaponStatusText.text = $"Laser Shots\r\nShots left: {shotsValue}\r\nReloading: {(int)reloadTime}";
        }
    }
}
