using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
public class Eye : MonoBehaviour {

	public enum LookAxis {
		XPositive = 0,
		YPositive,
		ZPositive,
		XNegative,
		YNegative,
		ZNegative
	}

	public Transform m_EyeBone;
	public LookAxis m_LookAxisInObjectSpace;

	private Renderer m_Renderer;
	private MaterialPropertyBlock m_PropertyBlock;

	void Awake(){
		m_Renderer = GetComponent<Renderer>();
		m_PropertyBlock = new MaterialPropertyBlock();
	}

	Vector3 GetLookVector(Transform bone){
		switch(m_LookAxisInObjectSpace) {
			case LookAxis.XPositive: return bone.right;
			case LookAxis.YPositive: return bone.up;
			case LookAxis.ZPositive: return bone.forward;
			case LookAxis.XNegative: return -bone.right;
			case LookAxis.YNegative: return -bone.up;
			case LookAxis.ZNegative: return -bone.forward;
			default: return Vector3.zero;
		}
	}

	void Update () {
		if(m_Renderer == null || m_PropertyBlock == null || m_EyeBone == null) return;
	
		m_PropertyBlock.SetVector("_EyeLookVector", GetLookVector(m_EyeBone));
		m_Renderer.SetPropertyBlock(m_PropertyBlock);
	}

}
