using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
    NavMeshAgent control;

    public float speed = 5.0f;
    Vector3 start;
    Vector3 end;

    public GameObject kunai;
    [SerializeField] float qSpeed;
    public float distance;
 
    void Start()
    {
        control = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        



        Move();
        rayccc();

    }
    private void FixedUpdate() {
        
    }
    void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        start = Camera.main.transform.position;
        end = ray.GetPoint(10000f);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            if (Input.GetMouseButton(1))
            {



                control.SetDestination(hit.point);



            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                kunai = Instantiate(kunai, transform.position, kunai.transform.rotation);
                Rigidbody rgKunai = kunai.GetComponent<Rigidbody>();
                rgKunai.AddForce(hit.point * qSpeed);







            }


        }

    }
    void rayccc()
    {

        // OR
        // Vector3 end = start + ray.direction * 10000;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(start, end);

    }


}



