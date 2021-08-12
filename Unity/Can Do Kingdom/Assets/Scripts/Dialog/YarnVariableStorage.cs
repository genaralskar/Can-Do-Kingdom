using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;

public class YarnVariableStorage : Yarn.Unity.VariableStorageBehaviour
{


    // Store a value into a variable
    public override void SetValue(string variableName, Yarn.Value value)
    {
        // 'variableName' is the name of the variable that 'value' 
        // should be stored in.
    }

    // Return a value, given a variable name
    public override Value GetValue(string variableName)
    {
        // 'variableName' is the name of the variable to return a value for
        return null;
    }

    // Return to the original state
    public override void ResetToDefaults()
    {
        
    }
}
