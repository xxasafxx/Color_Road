using UnityEngine;

[ExecuteInEditMode]
public class WorldCurver2 : MonoBehaviour
{
	[Range(-0.1f, 0.1f)]
	public float curveStrengthX = 0.1f;

	[Range(-0.1f, 0.1f)]
	public float curveStrengthY = 0.1f;

	int x_CurveStrengthID;
	int y_CurveStrengthID;



	private void OnEnable()
    {
		x_CurveStrengthID = Shader.PropertyToID("curveStrengthX");
		y_CurveStrengthID = Shader.PropertyToID("curveStrengthY");
	}

	void Update()
	{
		Shader.SetGlobalFloat(x_CurveStrengthID, curveStrengthX);
		Shader.SetGlobalFloat(y_CurveStrengthID, curveStrengthY);
	}

	
}
