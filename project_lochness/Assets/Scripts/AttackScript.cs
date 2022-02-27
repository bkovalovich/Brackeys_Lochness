using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject shark;
    public GameObject driftWood;
    public SharkScript sharkScript;
    public DriftWoodScript driftWoodScript;
    public float strength = 1;
    private bool attackable;
    private bool sharkTarget;
    private bool driftTarget;
    
    void Start()
    {
        sharkScript = shark.GetComponent<SharkScript>();
        driftWoodScript = driftWood.GetComponent<DriftWoodScript>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && attackable)
        {
            if (sharkTarget)
            {
                //sharkScript.Damage(strength);
            }
            if (driftTarget)
            {
                driftWoodScript.Damage(strength);
            }
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        attackable = true;
        if (col.gameObject.CompareTag("shark"))
        {
            sharkTarget = true;
        }
        if (col.gameObject.CompareTag("driftwood"))
        {
            driftTarget = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("shark"))
            sharkTarget = false;

        if (col.gameObject.CompareTag("driftwood"))
            driftTarget = false;

    }
}
