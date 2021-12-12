using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wAbilityPrefab : MonoBehaviour
{
     [SerializeField]float speed;
     Transform target;
    void Start()
    {  target=GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>().transform;
      
    }

    // Update is called once per frame
    void Update()
    {  if (target != null)
        {
            Vector3 targetPos = target.position;
            transform.LookAt(targetPos);
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance > 2f)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }
            else Destroy(this.gameObject);

        }
       
    }
}
