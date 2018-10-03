using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force;
    public int life;
    private Rigidbody rigid;
    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
            rigid.AddForce(Vector3.up * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit !!");

        --life;

        StartCoroutine(blink(2));
    }

    IEnumerator blink(int steps)
    {
        for (int i = 1; i <= steps; i++)
        {
            rend.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds((float) 0.25);
        
            rend.material.SetColor("_Color", Color.blue);
            yield return new WaitForSeconds((float) 0.25);
            
        }
    }
}