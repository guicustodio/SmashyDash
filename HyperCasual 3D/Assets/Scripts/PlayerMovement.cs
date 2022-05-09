using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private int dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private int jumpForce = 8;

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpForce;

        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(DashTime());
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2) 
            {
                rb.velocity = Vector3.up * jumpForce;
            }
            else if (touch.position.x > Screen.width / 2) 
            {
                StartCoroutine(DashTime());
            }
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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }

        if (col.gameObject.CompareTag("Goal"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("SampleScene");
        }

    }




}
