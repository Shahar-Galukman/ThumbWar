using UnityEngine;

public abstract class Weapon : MonoBehaviour, IHit
{
    public int Damage { get => 5; set { } }
    public float HitRate { get; set; } = 1f;

    public virtual void DoHit(BaseUnit unit)
    {
        Debug.Log("Weapon");
        unit.TakeDamage(Damage);
    }
}
