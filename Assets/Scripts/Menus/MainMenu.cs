using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI version;

    // Start is called before the first frame update
    void Start()
    {
        version.text = "V " + Application.version;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
