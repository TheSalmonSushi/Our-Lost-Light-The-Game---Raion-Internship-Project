using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] protected KeyCode whichObject; //keybind untuk menentukan object yang ingin diputar
    [SerializeField] protected KeyCode rotateLeft; //keybind untuk rotasi ke ke kiri atau ccw
    [SerializeField] protected KeyCode rotateRight; //keybind untuk rotasi ke kanan atau cw
    [SerializeField] protected KeyCode moveLeft; //keybind untuk gerak ke kiri
    [SerializeField] protected KeyCode moveRight; //keybind untuk gerak ke kanan
    [SerializeField] protected KeyCode moveUp; //keybind untuk gerak ke atas
    [SerializeField] protected KeyCode moveDown; //keybind untuk gerak ke bawah
    [SerializeField] protected float speed; //angka kecepatan pergerakan object
    [SerializeField] protected Vector2 direction;
    private float x, y, z;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputGetkeyMovement();
    }

    public void InputGetkeyMovement()
    {
        if (Input.GetKey(whichObject) && Input.GetKey(rotateLeft))
        {
            z++;
            Rotate();
        }
        if (Input.GetKey(whichObject) && Input.GetKey(rotateRight))
        {
            z--;
            Rotate();
        }

        if (Input.GetKey(whichObject) && Input.GetKey(moveLeft))
        {
            direction.x = -1;
            Move();
        }
        if (Input.GetKey(whichObject) && Input.GetKey(moveRight))
        {
            direction.x = 1;
            Move();
        }
        if (Input.GetKey(whichObject) && Input.GetKey(moveUp))
        {
            direction.y = 1;
            Move();
        }
        if (Input.GetKey(whichObject) && Input.GetKey(moveDown))
        {
            direction.y = -1;
            Move();
        }
        direction.x = 0;
        direction.y = 0;
    }


    public void Rotate()
    {
        transform.localRotation = Quaternion.Euler(0, 0, z);
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
