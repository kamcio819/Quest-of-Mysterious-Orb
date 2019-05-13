using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// klasa do wykrywania i zarządzania chunkami
/// </summary>
public class Chunk : MonoBehaviour{
	public Transform[] chestPoints;	  ///< <summary> Obiekty symbolizujące potencjalne punkty ze skrzyniami </summary>
	public Transform[] spawnerPoints; ///< <summary> Obiekty symbolizujące potencjalne punkty ze spawnerami </summary>

	/**
	 * @summary rozsiewa po chunku rudy odpowiednich materiałów (lub kupy śmieci)
	 * @param oreNumbers ilość rud kazdego typu do rozrzucenia	 
	*/
	public void SpreadResources(int[] oreNumbers){
		///TODO: zrobić to
	}
    [System.Serializable]
	public struct Box{ 
		public Vector3 size;
		public Vector3 position;
		public Collider[] Overlap(Vector3 pos, Quaternion rot, int LayerMask){
			Vector3 dest = position;
            float a = -rot.eulerAngles.y * Mathf.PI / 180;

            float cos = Mathf.Cos(a);
			float sin = Mathf.Sin(a);
			dest = new Vector3(dest.x * cos - dest.z*sin, 0, dest.x*sin+dest.z*cos);
			return Physics.OverlapBox(dest+pos, size/2, rot, LayerMask);	
		}
	}
	public Box[] chunkColliders;
	/// <summary>
	/// sprawdza kolizje
	/// </summary>
	/// <param name="layerMask">maska kolizji</param>
	/// <param name="simPos">pozycja chunka, dla której jest to liczone</param>
	/// <param name="rot">rotacja czanka dla której jest tom liczone</param>
	/// <returns>czy wykryto kolizje</returns>
	public bool CheckOverlaps(int layerMask, Vector3 simPos, Quaternion rot){ 
		foreach(Box b in chunkColliders){ 
			if(b.Overlap(simPos, rot, layerMask).Length > 0)
				return true;			
		} 	
		return false;
	}


	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.magenta;
		foreach (Box b in chunkColliders)
		{
			Vector3 dest =  b.position;
			float a =- transform.rotation.eulerAngles.y*Mathf.PI/180;

			float cos = Mathf.Cos(a);
			float sin = Mathf.Sin(a);
			dest = new Vector3(dest.x * cos - dest.z * sin,dest.y, dest.x * sin + dest.z * cos);
			Gizmos.DrawCube(dest + transform.position, Mathf.Abs(sin) > 0.9f? new Vector3(b.size.z, b.size.y, b.size.x) : new Vector3(b.size.x,b.size.y, b.size.z));
		}
		
	}


}

