using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class PrimaryWeapons : MonoBehaviour
{
    [SerializeField] private List<GameObject> firePoints;
    [SerializeField] private GameObject projectile;

    private void OnFire(InputValue value)
    {
        foreach (var firePoint in firePoints)
        {
            if (value.Get<float>() == 1)
            {
                Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
            }
        }
    }
}
