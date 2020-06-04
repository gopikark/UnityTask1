using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawline : MonoBehaviour
{
    private LineRenderer lr;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform dest;

    public float lineDrawSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, origin.position);
        lr.SetWidth(.45f, .45f);

        dist = Vector3.Distance(origin.position, dest.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(counter<dist)
        {
            counter += .1f/lineDrawSpeed;
            float x = Mathf.Lerp(0, dist, counter);
            Vector3 pa = origin.position;
            Vector3 pb = dest.position;

            Vector3 pall = x * Vector3.Normalize(pb - pa) + pa;
            lr.SetPosition(1, pall);
        }
    }
}
