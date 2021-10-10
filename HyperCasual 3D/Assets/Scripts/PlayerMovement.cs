using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private int dashForce;
    [SerializeField] private float dashDuration;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * 5;

        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(DashTime());
        }

    }

    IEnumerator DashTime()
    {
        rb.AddForce(new Vector3(dashForce, this.transform.position.y, this.transform.position.z ));
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector3.zero;
    }

    public void OnTriggerEnter(Collider other)
    {
        float pos = other.transform.position.x;
        if (other.gameObject.CompareTag("Collider"))
            {
            this.transform.position = new Vector3(pos, this.transform.position.y, this.transform.position.z);
            Destroy(other.gameObject, 0.2f);
            }
    }





}
