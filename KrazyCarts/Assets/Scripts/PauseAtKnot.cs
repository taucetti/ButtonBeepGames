using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class PauseAtKnot : MonoBehaviour
{
    public float stopTime = 5f;
    private SplineAnimate splineAnimator;
    private Spline path;
    private Vector3 beginning;
    private Vector3 midpoint;

    // Start is called before the first frame update
    void Start()
    {
        splineAnimator = GetComponent<SplineAnimate>();
        path = splineAnimator.Container.Spline;

        float3 knot = path[0].Position;
        beginning = new Vector3(knot.x, knot.y, knot.z);

        knot = path[path.Count / 2].Position;
        midpoint = new Vector3(knot.x, knot.y, knot.z);

        Debug.Log(beginning + "\t" + midpoint);

        //float pos = 0f;

        Debug.Log(path.EvaluatePosition<Spline>(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        float time = splineAnimator.NormalizedTime;
        time = time - math.floor(time);
        //Debug.Log(transform.position);
        //if (transform.position.Equals(beginning) || transform.position.Equals(midpoint))
        //Debug.Log(time + "\t" + splineAnimator.NormalizedTime);
        if (Mathf.Approximately(time, 0.5f))
        {
            Debug.Log("At one of the ends");
            StartCoroutine(StopAndStart());
        }
    }

    IEnumerator StopAndStart()
    {
        splineAnimator.Pause();
        yield return new WaitForSeconds(stopTime);
        splineAnimator.Play();
    }
}
