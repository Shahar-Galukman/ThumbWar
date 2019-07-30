using UnityEngine;

public class BaseUnit : MonoBehaviour, IUnit, IDamagable
{
    public GameObject unit;
    public Transform enemyBase;
    public Weapon weapon;

    private Rigidbody2D unitrb2d;
    private BaseUnit enemy;
    private Vector2 velocity;

    private float nextHit;

    private int health = 100;
    public int Health { get => health; set { health = value; } }
    public float Speed { get => 0.5f; set { } }
    public float Range { get => 10f; set { } }
    public int HitRange { get => 1; set { } }
    public int Damage { get => 5; set { } }
    public float HitRate { get => 1; set { } }

    // Start is called before the first frame update
    void Start()
    {
        unitrb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector2(enemyBase.position.x, enemyBase.position.y) * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        unitrb2d.velocity = velocity;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.name == "enemy" && collision.name != "enemy")
        // Enemy collided with us, TODO: move to enemy script when created
        {
            if (Vector2.Distance(gameObject.transform.position, collision.gameObject.transform.position) <= HitRange)
            {
                velocity = Vector2.zero * 0;
                weapon.DoHit(this);
            }
        }

        if (enemy != null)
        {
            DamageEnemy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // We met an Enemy
        if (gameObject.name != collision.name && collision.name == "enemy")
        {
            velocity = Vector2.zero * 0;
            enemy = collision.GetComponent<BaseUnit>();
            DamageEnemy();
        } else
        {
            Debug.Log("The fuck I just colllided? " + collision.name);
        }
    }

    private void DamageEnemy()
    {
        if (enemy && enemy.Health > 0)
        {
            if (Time.deltaTime > nextHit)
            {
                nextHit = Time.deltaTime + weapon.HitRate;

                weapon.DoHit(enemy);
            }
        }
        else
        {
            Debug.Log("dead" + new Vector2(enemyBase.position.x, enemyBase.position.y) * Speed);
            enemy = null;
            velocity = new Vector2(enemyBase.position.x, enemyBase.position.y) * Speed;
        }
    }

    public void TakeDamage(int damageTaken)
    {
        Health -= damageTaken;
 
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void DoHit(int damage, BaseUnit unit)
    {
        unit.TakeDamage(damage);
    }
}
