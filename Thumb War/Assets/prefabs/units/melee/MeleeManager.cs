using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeManager : MonoBehaviour, IUnit
{
    public int Health { get => 100; set { } }
    public float Speed { get => 0.3f; set { } }
    public float Range { get => 5f; set { } }
    public int HitRange { get => 1; set { } }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = HitRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
