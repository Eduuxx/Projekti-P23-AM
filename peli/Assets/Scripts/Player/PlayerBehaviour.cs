using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] HealBarScript _healthBar;
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
            // Check if using a medkit would heal for too much hp
            if (playerEntity.HP + 30 > playerEntity.maxHP)
            {
                // In that case just set HP to max hp
                playerEntity.HP = playerEntity.maxHP;
            }
            else
            {
                playerEntity.HP += 30;
            }
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }
    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }
}
