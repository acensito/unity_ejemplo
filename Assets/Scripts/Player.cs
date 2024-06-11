

using UnityEngine;

public class Player : MonoBehaviour
{
    bool canJump;
    [SerializeField] float speed = 50;
    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        //mover al jugador izquierda derecha de la manera mas sencilla con transform.Translate
        if (Input.GetKey("right")) {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey("left")) {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //    mover al jugador izquierda derecha con Rigidbody2D

        // ****************************************************************************************
        // if (Input.GetKey("right")) {
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000 * Time.deltaTime);
        // }

        // if (Input.GetKey("left")) {
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000 * Time.deltaTime);
        // }

        if (Input.GetKeyDown("up") && canJump) {
            rb.AddForce(Vector2.up * 100f);
            canJump = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {
        // if (collision.gameObject.tag == "Ground") {
        if (collision.gameObject.CompareTag("Ground")) {
            canJump = true;
            Debug.Log("Tocando el suelo");
        }

        if (collision.gameObject.tag == "Finish") {
            Debug.Log("Colisionando con la meta");
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Finish")) {
            Debug.Log("Entrando en la meta");
        }
    }

}
