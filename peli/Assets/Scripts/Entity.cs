using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHP;
    public bool alive;
    private float hp;

    public HealBarScript _healthBar;

    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;

            // Check Death
            if (hp <= 0f)
            {
                alive = false;
                onDeath();
            }
        }
        
    }

    public virtual void onDeath() {}

    public void takeDamage(int damageCount) 
    {
        HP = hp - damageCount;
    }

    public void healDamage(int healCount)
    {
        HP = hp + healCount;
    }

    public void healFully()
    {
        HP = maxHP;
    }

    public void kill()
    {
        HP = 0f;
    }

    public void updateHealthBar()
    {
        _healthBar.SetHealth((int) hp);
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }
}
