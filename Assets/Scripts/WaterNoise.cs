using System.Collections.Generic;
using UnityEngine;

public class WaterNoise : MonoBehaviour
{
	public float power = 3;
	public float scale = 1;
	public float timeScale = 1;

	private float offsetX;
	private float offsetY;
	private MeshFilter mf;

	//Creating noise of water
	void Start()
	{
		mf = GetComponent<MeshFilter>();
		MakeNoise();
	}
	void Update()
	{
		MakeNoise();
		offsetX += Time.deltaTime * timeScale;
		if (offsetY <= 0.1) offsetY += Time.deltaTime * timeScale;
		if (offsetY >= power) offsetY -= Time.deltaTime * timeScale;
	}
	void MakeNoise()
	{
		Vector3[] verticies = mf.mesh.vertices;
		for (int i = 0; i < verticies.Length; i++)
		{
			verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
		}
		mf.mesh.vertices = verticies;
	}
	float CalculateHeight(float x, float y)
	{
		float xCord = x * scale + offsetX;
		float yCord = y * scale + offsetY;
		return Mathf.PerlinNoise(xCord, yCord);
	}
}