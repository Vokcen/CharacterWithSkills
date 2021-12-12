using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
    NavMeshAgent control;
    public Animator anim;

    public float speed = 5.0f;
    Vector3 start;
    Vector3 end;

    public GameObject kunai;
    [SerializeField] float qSpeed;
    public float distance;
    public LayerMask ground;
    public Transform target;

    void Start()
    {
        control = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {



        Move();

        rayccc();
        Animations();

    }
    private void Animations()
    {
        if (control.velocity.magnitude <= 5f)
        {
            anim.SetBool("isRunning", false);

        }
        else anim.SetBool("isRunning", true);
    }

    void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        start = Camera.main.transform.position;
        end = ray.GetPoint(10000f);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Q))
        {



            anim.SetLayerWeight(1, 1f);
            anim.SetTrigger("AutoAtack");
            GameObject projectile = Instantiate(kunai, transform.position, kunai.transform.rotation);




        }
        if (Physics.Raycast(ray, out hit, 10000f, ground))
        {

            if (Input.GetMouseButton(0))
            {

                control.speed = speed;


                control.SetDestination(hit.point);



            }





        }


    }
    void AnimState()
    {
        anim.SetLayerWeight(1, 1f);
        anim.SetTrigger("AutoAtack");

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



