using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHP;
    public bool alive;
    public string name;
    private float hp;

    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            Debug.Log(gameObject.name + " has currently " + hp + " hp.");

            if (hp <= 0f)
            {
                alive = false;
                Debug.Log(gameObject.name + " died ");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }
}
