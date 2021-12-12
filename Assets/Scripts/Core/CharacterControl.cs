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
    [SerializeField] ParticleSystem holding;
    public GameObject kunai;
    public GameObject qAbility;
    [SerializeField] float qSpeed;
    public float distance;
    public LayerMask ground;
    public Transform target;
    public GameObject clone;
    public ParticleSystem Smoke;
      [SerializeField]ParticleSystem Mega;
    [SerializeField] GameObject clone1, clone2;

    public void Start()
    {
        control = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public virtual void Update()
    {



        Move();


        Animations();
        QSkill();
        WSkill();
        ESkill();
         Rskill();
    }
    public void Animations()
    {
        if (control.velocity.magnitude <= 5f)
        {
            anim.SetBool("isRunning", false);

        }
        else anim.SetBool("isRunning", true);
    }
    public void QSkill()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetLayerWeight(1, 1f);
            anim.SetLayerWeight(2, 0f);
            anim.SetTrigger("AutoAtack");
            GameObject w = Instantiate(qAbility, transform.position, qAbility.transform.rotation);

        }
    }
    void WSkill()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            float weight = Mathf.Lerp(0f, 1f, 1f);
            anim.SetLayerWeight(1, 0f);
            anim.SetLayerWeight(2, weight);
            anim.SetTrigger("Hold");
            ParticleSystem wS = Instantiate(holding, transform.position, holding.transform.rotation);

        }

    }
    public void ESkill()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ParticleSystem e = Instantiate(Smoke, transform.position, Smoke.transform.rotation);
            clone.gameObject.SetActive(true);
        }

    }
    void Rskill()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            clone1.gameObject.SetActive(true);
            clone2.gameObject.SetActive(true);
            ParticleSystem r=Instantiate(Mega,transform.position,Mega.transform.rotation);
        }
    }
    private void Move()
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
                anim.SetLayerWeight(2, 0);
                control.speed = speed;


                control.SetDestination(hit.point);



            }





        }


    }




}



