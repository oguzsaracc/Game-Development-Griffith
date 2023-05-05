using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAgentPlayerScript : MonoBehaviour
{
    //public Transform goal;

    private UnityEngine.AI.NavMeshAgent agent;

    public float projectileLifetime;
    public float projectileSpeed;
    public Transform shootPoint;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //on right mouse button click raycast from mouse position to navmesh
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
            }
        }

        //on left mouse button click fire projectile from shootPoint to mouse position
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                //instantiate projectile at shootpoint
                GameObject projectile = Instantiate(this.projectile, shootPoint.transform.position, Quaternion.identity);
                projectile.GetComponent<ProjectileScript>().projectileType = 1;
                projectile.GetComponent<ProjectileScript>().projectileLife = projectileLifetime;
                projectile.GetComponent<Rigidbody>().AddForce((new Vector3(hit.point.x - shootPoint.transform.position.x, shootPoint.transform.position.y, hit.point.z - shootPoint.transform.position.z)).normalized * projectileSpeed, ForceMode.Impulse);
            }
        }

    }
}