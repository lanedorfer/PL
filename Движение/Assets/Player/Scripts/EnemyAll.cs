using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAll : MonoBehaviour
{
    public virtual void GetDammage()
    {
        
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
