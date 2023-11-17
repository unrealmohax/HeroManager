using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneratorConfig", menuName = "Gamplay/GeneratorConfig/ Create new generator config")]
public class GeneratorConfig : ScriptableObject, IGeneratorConfig
{
    [SerializeField] private List<ConfigData> _configDatas;
    [SerializeField, Range(0, 99)] protected int _maxValue;
    public IReadOnlyList<ConfigData> WeightValues => _configDatas;
    public int MaxValue => _maxValue;
}

[Serializable]
public struct ConfigData 
{
    [Range(0, 90)] public int Value;
    [Range(0, 100)] public float ChanceValue;
}