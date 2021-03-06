/* (John Mordi, Luke Alcazar, George Tang, Ashton Lively) 
 * (Player Controller) 
 * (Project 6) 
 * (Basic Player movement as well as how the player interacts with the world) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    private float mouseX, mouseY, dmg = 1;
    public GameObject projectile, meleeAtk;
    public Camera cam;
    private bool focused = false;
    private bool rngAtkCD = true, meleeAtkCD = true;
    public GameObject attackPoint;
    Vector3 checkPoint;
    float jumps;

    public Text winCondition;
    public Text cooldown;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        checkPoint = gameObject.transform.position;
        jumps = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = "Mouse Y: " + mouseY + " Mouse X: " + mouseX;
        //if (Input.GetAxisRaw("Mouse X") != 0 && Input.GetAxisRaw("Mouse Y") != 0)
        //{
        if(gameObject.transform.position.y < -70)
        {
            gameObject.transform.position = checkPoint;
            FindObjectOfType<InGameUIManager>().UpdatePlayerHealth();
        }
        if (Input.GetMouseButtonDown(0) && meleeAtkCD) 
        {
            meleeAtkCD = false;
            StartCoroutine(MeleeAtk());
        }
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
        if (Input.GetKeyDown(KeyCode.W) && jumps != 0)
        {
            rigidBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            jumps--;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector2.left * 10 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //gameObject.transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector2.right * 10 * Time.deltaTime);
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
        //temp.x -= 9;
        Vector2 delta = gameObject.transform.localPosition - temp;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));

        cooldown.text = "Ranged Cooldown: ---";
        yield return new WaitForSeconds(1);
        cooldown.text = "Ranged Cooldown: O--";
        yield return new WaitForSeconds(1);
        cooldown.text = "Ranged Cooldown: OO-";
        yield return new WaitForSeconds(1);
        cooldown.text = "Ranged Cooldown: OOO";

        rngAtkCD = true;

        yield break;
    }

    public IEnumerator MeleeAtk()
    {
        Vector2 mos = Input.mousePosition;
        Vector3 temp = cam.ScreenToWorldPoint(Input.mousePosition);
        //temp.x -= 9;
        Vector2 delta = temp - gameObject.transform.localPosition;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        attackPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        attackPoint.transform.Translate(Vector2.right * 3.5f);

        Collider2D[] enemiesHit = Physics2D.OverlapCapsuleAll(attackPoint.transform.position, new Vector2(2f, 0.5f), CapsuleDirection2D.Horizontal, 0);
        
        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.tag == "Enemy")
            {
                Debug.Log("We hit" + enemy.name);
                enemy.GetComponent<Enemy>().TakeDamage(dmg);
            }
        }
            
            

        GameObject spawned = Instantiate(meleeAtk, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, angle-90)), gameObject.transform);
        spawned.transform.Translate(Vector2.up * 3);

        yield return new WaitForSeconds(0.5f);
        attackPoint.transform.rotation = Quaternion.Euler(Vector3.zero);
        attackPoint.transform.position = gameObject.transform.position;
        Destroy(spawned);

        



        //yield return new WaitForSeconds(0.15f);

        //Destroy(spawned);

        //yield return new WaitForSeconds(0.15f);

        meleeAtkCD = true;


        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            checkPoint = collision.transform.position;
        }

        if(collision.tag == "Win")
        {
            winCondition.text = "YOU WIN!";
            winCondition.gameObject.SetActive(true);
            Time.timeScale = 0;
            FindObjectOfType<GameManager>().pauseMenu.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform" && collision.gameObject.transform.position.y <= gameObject.transform.position.y)
        {
            jumps = 2;
        }
    }

    public Vector3 GetCheckpoint()
    {
        return checkPoint;
    }
}