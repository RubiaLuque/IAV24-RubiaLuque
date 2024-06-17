using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class UIManager : MonoBehaviour
{
    public int numGhosts;
    private int actualGhosts;

    public TextMeshProUGUI _text;
    public TextMeshProUGUI chrono;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        actualGhosts = numGhosts;
        _text = GameObject.Find("NumGhosts").GetComponent<TextMeshProUGUI>();
        chrono = GameObject.Find("Chrono").GetComponent<TextMeshProUGUI>();
        string s = (actualGhosts + "/" + numGhosts);
        _text.text = s;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        _text.text = (actualGhosts + "/" + numGhosts).ToString();
        chrono.text = ((int)timer).ToString();
    }

    public void DeadGhost()
    {
        actualGhosts--;
        _text.text = (actualGhosts + "/" + numGhosts).ToString();
    }
}
