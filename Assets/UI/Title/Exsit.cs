using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exsit : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick() {
        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
