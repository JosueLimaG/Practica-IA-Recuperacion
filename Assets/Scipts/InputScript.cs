using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputScript : MonoBehaviour
{
    private Rigidbody rigid;
    private float x, y, z;
    public float sensibilidad = 25f;
    public GameObject victoria;

	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        x = Input.GetAxis("Mouse X");
        z = Input.GetAxis("Mouse Y");
        y = 0;
        rigid.velocity = new Vector3(z * sensibilidad, y * sensibilidad, -x * sensibilidad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Final")
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            victoria.SetActive(true);
        }
    }
}
