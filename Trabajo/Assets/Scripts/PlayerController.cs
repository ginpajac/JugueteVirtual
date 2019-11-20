using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Text countText;
    public Text wintext;
    public float speed;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        wintext.text = "";
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        rb2d.AddForce(movement*speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Puntos: " + count.ToString();
        if (count >= 12)
        {
            wintext.text = "Ganaste!";
        }
    }
}
 