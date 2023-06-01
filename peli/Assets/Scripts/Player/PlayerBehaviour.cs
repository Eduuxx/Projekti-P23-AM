using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Entity playerEntity;

    void Start()
    {
        playerEntity = GetComponent<Entity>();
    }

    
    void Update()
    {
        // Using a medkit
        if (Input.GetKeyDown("4"))
        {
            // TODO SIMPLE INVENTORY FOR MEDKITS
            Debug.Log("4 pressed");
            // Check if using a medkit would heal over max hp
            if (playerEntity.HP + 30 > playerEntity.maxHP)
            {
                // In that case just set HP to max hp
                playerEntity.healFully();
            }
            else
            {
                playerEntity.healDamage(30);
                playerEntity.updateHealthBar();
            }
        }
    }
}
