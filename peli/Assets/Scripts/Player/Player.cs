using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public StaminaBarScript _staminaBar;
    public bool isExhausted;
    public float maxStamina = 100;
    private float stamina;

    public float Stamina
    {
        get
        {
            return stamina;
        }
        set
        {
            stamina = value;
            isExhausted = stamina <= 0f ? true : false;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set HP and Stamina to max on the start of a new game
        HP = maxHP;
        Stamina = maxStamina;
    }

    public void takeStamina(float staminaToReduce) 
    {
        Stamina = stamina - staminaToReduce;
    }

    public void giveStamina(float staminaToGive)
    {
        Stamina = stamina + staminaToGive;
    }
    
    public void updateStaminaBar()
    {
        _staminaBar.SetStamina((float) stamina);
    }
}
