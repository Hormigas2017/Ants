using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour, IAttack {

    public void Attack()
    {
        print("I'm being attacked");
    }
}
