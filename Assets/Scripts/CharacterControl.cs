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
    public LayerMask ground;
 
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

             
        if (Physics.Raycast(ray, out hit, 10000f,ground))
        { 

            if (Input.GetMouseButton(0))
            {



                control.SetDestination(hit.point);



            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
           
                   GameObject projectile=Instantiate(kunai,transform.position,kunai.transform.rotation);
                              projectile.GetComponent<Rigidbody>().AddForce(transform.forward*qSpeed,ForceMode.Impulse);





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



