using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CheckAttack()
    {
        if (Input.GetKey("space"))
        {
            isAttacking = true;

        }
        else
        {
            isAttacking = false;
        }
    }

    //public void OnTriggerEnter2D(Collider2D col)
    //{
    //    if(isAttacking && col.gameObject.tag == "Diver")
    //    {
    //        Destroy(col.gameObject);
    //    }
    //}

        // Update is called once per frame
        void Update()
    {
        CheckAttack();
    }
}
