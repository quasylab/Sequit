using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private GameManager _gameManager;
    private CameraMovement _cameraMovement;
    private SimulationManager _simulationManager;
    
    public GameObject titleCanva;
    public GameObject planePrefab;
    public GameObject inputCanva;

    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        _simulationManager = GameObject.Find("SimulationManager").GetComponent<SimulationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartApplication()
    {
        Debug.Log("Starting app...");
        titleCanva.gameObject.SetActive(false);
        _gameManager.isGameActive = true;
        _gameManager.actionMenu.SetActive(true);
        _gameManager.inputCanva.SetActive(true);
    }
    
    public void QuitApplication()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void ChangeCamera()
    {
        Debug.Log("Changing Camera...");
        if (_cameraMovement.eagleEyeCam)
        {
            _cameraMovement.SetRotativeCam();
        }
        else
        {
            _cameraMovement.SetEagleEyeCam();
        }
    }

    public void ZoomOut()
    {
        _cameraMovement.ZoomOut();
    }

    public void ZoomIn()
    {
        _cameraMovement.ZoomIn();
    }

    public void ControlGame()
    {
        _gameManager.ControlGame();
    }

    public void ChangeSpeedGame()
    {
        if (_gameManager.isGameActive)
        {
            
        }
        _gameManager.ChangeSpeedGame();
    }

    public void ChoosePlane(int i)
    {
        _simulationManager.indexPrefab = i;
    }
    
    public void LoadStandardPlane()
    {
        Debug.Log("Loading Standard Plane...");
        if (GameObject.Find("StandardPlane(Clone)") != null)
        {
            GameObject go = GameObject.Find("StandardPlane(Clone)");
            Debug.Log("Destroying...");
            Destroy(go);
        }
        Instantiate(planePrefab, planePrefab.transform.position, planePrefab.transform.rotation);
    }

    public void Add2DAgent()
    {
        Debug.Log("Adding a 2D agent...");
        inputCanva.SetActive(true);
        _simulationManager.is2D = true;
        //_simulationManager.Add2DAgent();
    }

    public void Add3DAgent()
    {
        Debug.Log("Adding a 3D agent...");
        inputCanva.SetActive(true);
        _simulationManager.is2D = false;
        //_simulationManager.Add3DAgent();
    }

    public void OpenInputFieldMenu()
    {
        inputCanva.SetActive(true);
    }

    public void GenerateAgents()
    {
        Debug.Log("Generating Agents...");
        inputCanva.SetActive(false);
        _simulationManager.GenerateAgents();
    }
}
