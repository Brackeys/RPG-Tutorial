using UnityEngine;

/* Tint the object when hovered. */

public class ColorOnHover : MonoBehaviour {

	public Color color;

	Color previousColor;

	Renderer rend;

	void Start ()
	{
		rend = GetComponent<Renderer>();
    }

	void OnMouseEnter ()
	{
		previousColor = rend.material.color;
        rend.material.color *= color;
	}

	void OnMouseExit()
	{
		rend.material.color = previousColor;
	}

}
