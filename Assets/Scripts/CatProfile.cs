using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenuAttribute(menuName = "Scriptable Objects/Cat Profile", order = 0)]
public class CatProfile : ScriptableObject
{
	public CatType type;
	public int score;
}