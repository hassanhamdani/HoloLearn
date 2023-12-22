using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForceWrap : MonoBehaviour
{
    private TMP_Text responseTMP;
    // Start is called before the first frame update
    void Start()
    {
        responseTMP = GetComponent<TMP_Text>();
    responseTMP.enableWordWrapping = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
