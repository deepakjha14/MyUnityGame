using UnityEngine;
using System.Collections;

public class CactusSpwan : MonoBehaviour {
    public float spwTime=0;
    public float spnRate = 1;
    public float randomDelay = 2;
    public Transform preFab;
    public AnimationCurve animCurve;
    public float curveLengthInSecond;
    private float startTime;
    private float posOnCurve;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > spwTime)
        {
            Instantiate(preFab, transform.position, Quaternion.identity);
            //spwTime = Time.time + spnRate + Random.Range(1, randomDelay);
            posOnCurve = (Time.time - startTime) / curveLengthInSecond;

            if (posOnCurve > 1f)
            {
                startTime = Time.time;
                posOnCurve = 1f;
            }
            spwTime = Time.time + animCurve.Evaluate(posOnCurve);
        }        
	}
}
