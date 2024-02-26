using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationManager : MonoBehaviour
{
    public GameObject agent2D;
    public GameObject agent3D;
    public GameObject[] planePrefabs;
    

    public TextMeshProUGUI text;
    
    public TMP_InputField directoryInputField;

    private GameObject _is2DAgentToggle;
    private GameObject _is3DAgentToggle;

    public bool is2D;
    public int indexPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _is2DAgentToggle = GameObject.Find("Is2DToggle");
        _is3DAgentToggle = GameObject.Find("Is3DToggle");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StupidButton()
    {
        string appDirectory = Application.persistentDataPath;
        text.gameObject.SetActive(true);
        text.text = appDirectory;
        text.color = Color.red;
        Debug.Log(appDirectory);
    }
    
    /// <summary>
    /// This method is called by the Button Manager to generate agents
    /// </summary>
    public void GenerateAgents()
    {
        if (_is2DAgentToggle.GetComponent<Toggle>().isOn)
        {
            is2D = true;
        }

        if (_is3DAgentToggle.GetComponent<Toggle>().isOn)
        {
            is2D = false;
        }

        if (indexPrefab!=0)
        {
            GameObject chosenPrefab = planePrefabs[indexPrefab];
            Instantiate(chosenPrefab, chosenPrefab.transform.position, chosenPrefab.transform.rotation);
        }
        
        string directoryPath = directoryInputField.text;
        InstantiateAgentsFromDirectory(directoryPath);
    }

    /// <summary>
    /// This method is used to instantiate agents starting from a given directory
    /// </summary>
    /// <param name="directoryPath">a given directory</param>
    private void InstantiateAgentsFromDirectory(string directoryPath)
    {
        DirectoryInfo dir = new DirectoryInfo(directoryPath);
        FileInfo[] infos = dir.GetFiles("*.csv");
        foreach (FileInfo info in infos)
        {
            InstantiateAgentFromFile(info.FullName);
        }
    }
    
    /// <summary>
    /// This method is used to decide which type of agent should be instantiated
    /// starting from a given file path
    /// </summary>
    /// <param name="file">a given file path</param>
    private void InstantiateAgentFromFile(string file)
    {
        if (is2D)
        {
            InstantiateAgent(agent2D, file);
        }
        else
        {
            InstantiateAgent(agent3D, file);
        }
    }

    /// <summary>
    /// This method is used to instantiate the agent
    /// given an agent prefab type and a corresponding agent file
    /// </summary>
    /// <param name="agentPrefab">an agent prefab type</param>
    /// <param name="file">a corresponding agent file</param>
    private void InstantiateAgent(GameObject agentPrefab, string file)
    {
        GameObject newAgent = Instantiate(agentPrefab);
        if (agentPrefab == agent2D)
        {
            Agent2DController controller2D = newAgent.GetComponent<Agent2DController>();
            controller2D.sourceFilePath = file;
        }

        if (agentPrefab == agent3D)
        {
            Agent3DController controller3D = newAgent.GetComponent<Agent3DController>();
            controller3D.sourceFilePath = file;
        }
    }
    
    
}
