using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAtack : MonoBehaviour
{
    Transform target;
    public float speed;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    private void Update()
    {
        if (target != null)
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
