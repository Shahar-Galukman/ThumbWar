using UnityEngine;

public class RangerManager : Bow, IUnit
{
    public int Health { get => 100; set { } }
    public float Speed { get => 0.1f; set { } }
    public float Range { get => 10f; set { } }
    public int HitRange { get => 4; set { } }

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
