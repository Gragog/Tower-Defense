using UnityEngine;

public interface IAttackBehavior {

    void Attack(Transform targetPosition, float damageAmount);
}
