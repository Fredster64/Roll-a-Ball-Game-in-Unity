using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeGame : MonoBehaviour {

	// Update is called once per frame
    // Quits if escape is pressed
	void Update ()
    {
        if ( Input.GetKey("escape") )
            Application.Quit();
	}
}
