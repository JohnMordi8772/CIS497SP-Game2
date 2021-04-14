using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    private float mouseX, mouseY;
    public GameObject projectile;
    public Camera cam;
    private bool focused = false;
    private bool rngAtkCD = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (focused)
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y");
        }
        //text.text = "Mouse Y: " + mouseY + " Mouse X: " + mouseX;
        //if (Input.GetAxisRaw("Mouse X") != 0 && Input.GetAxisRaw("Mouse Y") != 0)
        //{
        if (Input.GetMouseButtonDown(1) && rngAtkCD)
        {
            //float yRot = 0;
            //if (mouseY == 0)
            //{
            //    yRot = 0;
            //}
            //else
            //{
            //    yRot = Mathf.Atan(-mouseY / mouseX);
            //}
            //Debug.Log(cam.ScreenToWorldPoint(Input.mousePosition));
            //Debug.Log(delta.x + ", " + delta.y);
            rngAtkCD = false;
            StartCoroutine(RngAtk());
            //if (mouseX > 0)
            //    Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, yRot * (180f / Mathf.PI))));
            //else
            //    Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, yRot * (180f / Mathf.PI) + 180f)));
            //} 

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector2.left * 5 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //gameObject.transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }

    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Confined;
        focused = true;
        //Cursor.visible = false;
    }

    private void OnApplicationPause(bool pause)
    {
        focused = false;
    }

    public IEnumerator RngAtk()
    {
        Vector2 mos = Input.mousePosition;
        Vector3 temp = cam.ScreenToWorldPoint(Input.mousePosition);
        temp.x -= 9;
        Vector2 delta = gameObject.transform.localPosition - temp;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));

        yield return new WaitForSeconds(3);

        rngAtkCD = true;

        yield break;
    }
}