using UnityEngine;

public class AttackRocket : MonoBehaviour, IAttackBehavior
{
    public bool Attack(GameObject target, float damageAmount)
    {
        Debug.Log("Shooting at " + target.name + " dealing " + damageAmount + " damage!");

        return false;
    }
}
