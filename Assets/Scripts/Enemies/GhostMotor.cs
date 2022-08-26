using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMotor : MonoBehaviour
{
    [SerializeField] Transform[] setpoints;
    [SerializeField] float threshold;
    [SerializeField] float speed;

    Vector3[] setpoints_perm;
    private int iter;
    private int dir;
    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        setpoints_perm = new Vector3[setpoints.Length];
        iter = 0;
        dir = 1;

        foreach(Transform t in setpoints)
        {
            Debug.Log("Ghost iter:" + t.position);
            setpoints_perm[iter] = t.position;
            iter += 1;
        }

        iter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Ghost dist" + Vector3.Distance(transform.position, setpoints_perm[iter]));
        if (Vector3.Distance(transform.position, setpoints_perm[iter]) < threshold)
        {
            iter += dir*1;
            if(iter > setpoints_perm.Length -1 || iter < 0)
            {
                dir = -dir;
                iter += dir * 1;
            }

            Debug.Log("Ghost iter:" + iter);
        }

        Vector3 directionVector = (setpoints_perm[iter] - transform.position).normalized;

        if(directionVector.x > 0)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }

        if (directionVector.y > 0.1)
        {
            renderer.flipX = false;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90.0f);
        }
        else if(directionVector.y < -0.1)
        {
            renderer.flipX = false;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90.0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0.0f);
        }

        //transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(directionVector.y, directionVector.x)*180.0f / (Mathf.PI));
        transform.position += speed * directionVector;

    }
}
