using UnityEngine;

public class Bow : Weapon
{
    public Arrow arrow;

    void Awake()
    {
        Damage = 3;
        HitRate = 0.3f;
    }

    public override void DoHit(BaseUnit unit)
    {
        Debug.Log("Arrow");
        Arrow instance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector2(0, 0)));
        instance.gameObject.SetActive(true);
        instance.GetComponent<Rigidbody2D>().velocity = Vector2.right;

        unit.TakeDamage(Damage);
    }
}
