using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour{

	public Transform[] spawnerPoints; ///< <summary> Punkty spawnu </summary>

    [HideInInspector]
    public bool mainPath; /// <summary> Informacja czy chunk jest w głównej ścieżce </summary>

    [System.Serializable] 
	public struct Box{ 
		public Vector3 size;
		public Vector3 offset;
		public Collider[] Overlap(Vector3 pos, Quaternion rot, int LayerMask){
            Vector3 centerOfRactangle = offset;

            float alpha = rot.eulerAngles.y;
            float sin = Mathf.Sin(alpha * Mathf.PI / 180);
            float cos = Mathf.Cos(alpha * Mathf.PI / 180);
           
            return Physics.OverlapBox(new Vector3(centerOfRactangle.z * cos + centerOfRactangle.x * sin, centerOfRactangle.y, centerOfRactangle.x * cos - centerOfRactangle.z * sin)+pos, 
                size/2, rot, LayerMask);	
		}
	}
	public Box[] chunkColliders;

	public bool CheckOverlaps(int layerMask, Vector3 position, Quaternion rotation){
        foreach (Box box in chunkColliders){ 
			if(box.Overlap(position, rotation, layerMask).Length > 0)
				return true;			
		} 	
		return false;
	}


	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		foreach (Box box in chunkColliders)
		{
            Vector3 centerOfRactangle = box.offset;

            float alpha = transform.rotation.eulerAngles.y;
            float sin = Mathf.Sin(alpha * Mathf.PI / 180);
            float cos = Mathf.Cos(alpha * Mathf.PI / 180);


            Vector3 size = box.size;


            Gizmos.DrawCube(new Vector3(centerOfRactangle.z * cos + centerOfRactangle.x * sin, centerOfRactangle.y, centerOfRactangle.x * cos - centerOfRactangle.z * sin) + transform.position,
                Mathf.Abs(sin) > 0.9f ? new Vector3(box.size.z, box.size.y, box.size.x) : new Vector3(box.size.x, box.size.y, box.size.z));
        }
	}
}

