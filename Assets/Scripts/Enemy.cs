using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        EventManager.SendEnemyKilled();
    }
}
