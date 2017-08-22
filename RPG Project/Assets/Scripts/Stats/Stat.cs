using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Class used for all stats where we want to be able to add/remove modifiers */

[System.Serializable]
public class Stat {

	[SerializeField]
	private int baseValue;	// Starting value

	// List of modifiers that change the baseValue
	private List<int> modifiers = new List<int>();

	// Get the final value after applying modifiers
	public int GetValue ()
	{
		int finalValue = baseValue;
		modifiers.ForEach(x => finalValue += x);
		return finalValue;
	}

	// Add new modifier
	public void AddModifier (int modifier)
	{
		if (modifier != 0)
			modifiers.Add(modifier);
	}

	// Remove a modifier
	public void RemoveModifier (int modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);
	}

}
