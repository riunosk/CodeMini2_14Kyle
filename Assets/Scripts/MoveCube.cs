using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    int speed = 10;
    bool moveLimit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveLimit == false && transform.position.z < 25)
        {
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
        else
		{
            moveLimit = true;
		}
        if (moveLimit == true && transform.position.z > 1)
		{
            transform.Translate(0, 0, -Time.deltaTime * speed);
		}
        else
		{
            moveLimit = false;
		}
    }
}
