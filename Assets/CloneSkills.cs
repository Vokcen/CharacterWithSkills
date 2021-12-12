using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkills : CharacterControl
{
    // Start is called before the first frame update


    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }
    private void OnEnable()
    {
         StartCoroutine(timer());
    }
    IEnumerator timer()
    {   Instantiate(Smoke,this.transform.position,Smoke.transform.rotation);
        yield return new WaitForSeconds(4f);
         Instantiate(Smoke,this.transform.position,Smoke.transform.rotation);
         this.gameObject.SetActive(false);
    }
}
