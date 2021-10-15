using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed, kekuatanLompat;
    public GameObject player;
    public Rigidbody2D lompat;
    // Start is called before the first frame update
    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position = new Vector2(player.transform.position.x + speed, player.transform.position.y);

        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position = new Vector2(player.transform.position.x - speed, player.transform.position.y);
        }else if (Input.GetKey(KeyCode.UpArrow))
        {
            lompat.AddForce(new Vector2(0, kekuatanLompat));
        }
    }
}
