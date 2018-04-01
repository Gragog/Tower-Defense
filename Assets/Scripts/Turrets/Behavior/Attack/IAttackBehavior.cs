using UnityEngine;

public interface IAttackBehavior {

    bool Attack(GameObject targetPosition, float damageAmount);
}
