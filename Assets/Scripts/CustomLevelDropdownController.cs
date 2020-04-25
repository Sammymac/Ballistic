using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomLevelDropdownController : MonoBehaviour { 

    Dropdown m_Dropdown;
    public string defaultText;

    // Start is called before the first frame update
    void Start() {
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });

        this.PopulateDropdown(m_Dropdown);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void PopulateDropdown(Dropdown dropdown) {
        var levels = new List<string> { "level1" }; // FIXME Remove hardcoding
        List<string> options = new List<string>();
        dropdown.AddOptions(levels);
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change) {
        string levelName = change.captionText.text;
        if (levelName.StartsWith("level")) {
            SceneManager.LoadScene(change.value);
        }
    }

}
