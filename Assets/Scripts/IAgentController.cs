using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgentController
{

    /// <summary>
    /// This method changes the shape of the prefab object given an input string
    /// </summary>
    /// <param name="s">an input string</param>
    void ChangeShape(string s);

    /// <summary>
    /// This method changes the color of the prefab object given an input string
    /// </summary>
    /// <param name="s">an input string</param>
    void ChangeColor(string s);

    /// <summary>
    /// This method checks whether the file still has lines to read
    /// </summary>
    /// <returns>
    /// <code>true</code> if there is at least one more line in the file,
    /// <code>false</code> otherwise
    /// </returns>
    bool NextStep();
}
