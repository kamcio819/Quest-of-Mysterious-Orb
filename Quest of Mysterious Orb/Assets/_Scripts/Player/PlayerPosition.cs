using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{

        [System.Serializable]
        public struct Box
        {
            public Vector3 size;
            public Vector3 offset;
            public Collider[] Overlap(Vector3 pos, Quaternion rot, int LayerMask)
            {
                Vector3 centerOfRactangle = offset;

                float alpha = rot.eulerAngles.y;
                float sin = Mathf.Sin(alpha * Mathf.PI / 180);
                float cos = Mathf.Cos(alpha * Mathf.PI / 180);

                return Physics.OverlapBox(new Vector3(centerOfRactangle.z * cos + centerOfRactangle.x * sin, centerOfRactangle.y, centerOfRactangle.x * cos - centerOfRactangle.z * sin) + pos,
                    size / 2, rot, LayerMask);
            }
        }
        [SerializeField]
        private Box PositionDetector;

    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private SpawnManager spawnManager;

    private void Start()
    {
        StartCoroutine(CheckOverlaps(layerMask, transform.position, transform.rotation));
    }

    private IEnumerator CheckOverlaps(int layerMask, Vector3 position, Quaternion rotation)
        {

        //spawnManager.currentPlayerChunk = PositionDetector.Overlap(position, rotation, layerMask)[0].transform.parent.parent.gameObject ;
        Debug.Log(PositionDetector.Overlap(position, rotation, layerMask)[0].transform);
        Debug.Log(PositionDetector.Overlap(position, rotation, layerMask)[0].transform.parent);
        Debug.Log(PositionDetector.Overlap(position, rotation, layerMask)[0].transform.parent.parent.gameObject);
        yield return new WaitForSeconds(10);

        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            {
                Vector3 centerOfRactangle = PositionDetector.offset;

                float alpha = transform.rotation.eulerAngles.y;
                float sin = Mathf.Sin(alpha * Mathf.PI / 180);
                float cos = Mathf.Cos(alpha * Mathf.PI / 180);


                Vector3 size = PositionDetector.size;


                Gizmos.DrawCube(new Vector3(centerOfRactangle.z * cos + centerOfRactangle.x * sin, centerOfRactangle.y, centerOfRactangle.x * cos - centerOfRactangle.z * sin) + transform.position,
                    Mathf.Abs(sin) > 0.9f ? new Vector3(PositionDetector.size.z, PositionDetector.size.y, PositionDetector.size.x) : new Vector3(PositionDetector.size.x, PositionDetector.size.y, PositionDetector.size.z));
            }
        }
    }
