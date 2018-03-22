using UnityEngine;

public class AttackRocket : MonoBehaviour, IAttackBehavior
{
    public void Attack(Transform targetPosition, float damageAmount)
    {
        Debug.Log("Firering Rocket");
    }
}
