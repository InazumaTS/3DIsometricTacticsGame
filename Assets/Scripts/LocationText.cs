using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationText : MonoBehaviour
{
    [SerializeField]
    TMP_Text locationText;
    private void Start()
    {
        locationText = GetComponent<TMP_Text>();
    }
    // Start is called before the first frame update
    public void LocationShow(Vector2 position)
    {
        locationText.text = $"( {position.x},{position.y} )";
    }
}
