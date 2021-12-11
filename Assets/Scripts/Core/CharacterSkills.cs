using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkills : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 start;
    Vector3 end;
        
 public LayerMask  ClickLayerMask;
    public GameObject kunai;
    [SerializeField] float qSpeed;
    public float distance;


    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        start = Camera.main.transform.position;
        end = ray.GetPoint(10000f);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100000f, ClickLayerMask, QueryTriggerInteraction.Collide))
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {  Debug.Log("work");
                Instantiate(kunai,kunai.transform.position+hit.point, kunai.transform.rotation);
                
                
            }


        }
    }
}







