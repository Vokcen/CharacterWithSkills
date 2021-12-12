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
    public GameObject qAbility;
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


        Animations();
        QSkill();

    }
    private void Animations()
    {
        if (control.velocity.magnitude <= 5f)
        {
            anim.SetBool("isRunning", false);

        }
        else anim.SetBool("isRunning", true);
    }
    void QSkill()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetLayerWeight(1, 1f);
            anim.SetTrigger("AutoAtack");
            GameObject w = Instantiate(qAbility, transform.position, qAbility.transform.rotation);

        }
    }
    void WSkill()
    {
        
    }
    void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        start = Camera.main.transform.position;
        end = ray.GetPoint(10000f);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            transform.LookAt(target);

            anim.SetLayerWeight(1, 1f);
            anim.SetTrigger("AutoAtack");
            GameObject projectile = Instantiate(kunai, transform.position, kunai.transform.rotation);




        }
        if (Physics.Raycast(ray, out hit, 10000f, ground))
        {

            if (Input.GetMouseButton(1))
            {

                control.speed = speed;


                control.SetDestination(hit.point);



            }





        }


    }




}



