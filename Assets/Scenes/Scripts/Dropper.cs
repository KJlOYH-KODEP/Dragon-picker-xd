using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float CmonSpeed = 10f;
    public float leftRightDistance = 28f;
    public float chanceDirections = 0.01f;
    public float BombDroppingTimes = 1f;
    public GameObject GreenBombPrefab;
    private string bombColor;
    private List<string> BombVariants;

    void Start()
    {
        BombVariants = new List<string>{
        "Green",
        "Red",
        "Black"};
        Invoke("DropBomb", 2f);
    }

    void DropBomb() {
        Vector3 pos = transform.position; 
        if (pos.x > -(leftRightDistance-8f) && pos.x < leftRightDistance-8f) {
            bombColor = BombVariants[Random.Range(0,BombVariants.Count)];
            Debug.Log(bombColor);
            if (bombColor == "Green") {
                DropGreenBomb();
            }
        }
        Invoke("DropBomb", BombDroppingTimes);
    }
    void DropGreenBomb() 
    {
        Vector3 myVector = new 
        Vector3(0.0f, 5.0f, 0.0f);
        GameObject bomb = Instantiate<GameObject>(GreenBombPrefab);
        bomb.transform.position = transform.position + myVector;
    }
    // Update is called once per frame
    void Update()
    {  
        Vector3 rotate = transform.eulerAngles;
        Vector3 pos = transform.position; 
        if (pos.x + speed*Time.deltaTime < -leftRightDistance) 
        {
            speed = 0;
            rotate.y = 90;
            transform.rotation = Quaternion.Euler(rotate);
        }
        else if (pos.x + speed*Time.deltaTime > leftRightDistance) 
        {
            speed = 0;
            rotate.y = -90;
            transform.rotation = Quaternion.Euler(rotate);
        }
        else {
            pos.x += speed * Time.deltaTime; 
            transform.position = pos; 
        }

    }
    void FixedUpdate()
    {
        Vector3 pos = transform.position; 
        if (speed == 0 & Random.value < chanceDirections) {
            if (pos.x<0) { speed = CmonSpeed;}
            else { speed = -CmonSpeed;}
        }
    }
    
}