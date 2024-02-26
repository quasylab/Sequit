using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameObject titleCanva;
    public GameObject actionMenu;
    public GameObject shortcutMenu;
    public GameObject inputCanva;

    public TextMeshProUGUI panelText;

    public bool isGameActive;
    private bool _isActionMenuActive;

    private int _actualTimeScaleModifier;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        _isActionMenuActive = false;
        actionMenu.SetActive(false);
        _actualTimeScaleModifier = 1;
        inputCanva.SetActive(false);
        shortcutMenu.SetActive(false);
        
        panelText.text = _actualTimeScaleModifier+"X";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isGameActive)
        {
            if (_isActionMenuActive)
            {
                CloseActionMenu();
            }
            else
            {
                OpenActionMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseActionMenu();
            shortcutMenu.SetActive(false);
            titleCanva.SetActive(true);
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ControlGame();
        }

        /*
        if (Input.GetKeyDown(KeyCode.Alpha3) && isGameActive)
        {
            Time.timeScale = 2f;
        }
        */

        if (Input.GetKeyDown(KeyCode.Alpha1) && isGameActive)
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && isGameActive)
        {
            ChangeSpeedGame();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            OpenCloseShortcutMenu();
        }
    }

    private void OpenCloseShortcutMenu()
    {
        if (shortcutMenu.activeInHierarchy)
        {
            shortcutMenu.SetActive(false); 
            ResumeGame();
        }
        else
        {
            shortcutMenu.SetActive(true);
            PauseGame();
        }
        
    }

    /// <summary>
    /// This method is used to open the lateral action menu
    /// </summary>
    private void OpenActionMenu()
    {
        _isActionMenuActive = true;
        actionMenu.SetActive(true);
    }
    
    /// <summary>
    /// This method is used to open the lateral action menu
    /// </summary>
    private void CloseActionMenu()
    {
        _isActionMenuActive = false;
        actionMenu.SetActive(false);
    }

    public void ControlGame()
    {
        if (isGameActive)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    
    private void PauseGame()
    {
        isGameActive = false;
        Time.timeScale = 0f;
    }
    
    private void ResumeGame()
    {
        isGameActive = true;
        ChangeTimeScale();
    }

    public void ChangeSpeedGame()
    {
        if (_actualTimeScaleModifier == 4)
        {
            _actualTimeScaleModifier = 0;
        }
        else
        {
            _actualTimeScaleModifier++;
        }

        panelText.text = Mathf.Pow(2, _actualTimeScaleModifier) / 2 +"X";
        ChangeTimeScale();
    }

    private void ChangeTimeScale()
    {
        Time.timeScale = Mathf.Pow(2, _actualTimeScaleModifier) / 2;
    }
}
