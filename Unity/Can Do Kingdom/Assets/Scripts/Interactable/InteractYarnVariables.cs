using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;

public class InteractYarnVariables : MonoBehaviour
{
    private Yarn.Unity.InMemoryVariableStorage storage;

    [SerializeField] string variableName;
    [SerializeField] string value;
    [SerializeField] Value.Type type;

    private void Awake()
    {
        storage = FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
    }

    public void UpdateVariable()
    {
        Value v = new Value(value);
        storage.SetValue($"${variableName}", v);
        return;
    }
}
