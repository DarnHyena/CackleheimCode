using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
public class SnapPointMaker : MonoBehaviour
{
    public GameObject m_ObjectToParentSnapsTo;
    public BoxCollider m_SnapBoundsCollider;
    
    public void GrabVerticesAssignSnaps()
        {
            var vertices = GetColliderVertexPosRotated();
            AttachSnapPoints(m_ObjectToParentSnapsTo, vertices);
            CleanUpClones();
        }
        private Vector3[] GetColliderVertexPosRotated()
        {
            Vector3[] vertices = new Vector3[8];
            BoxCollider col = m_SnapBoundsCollider;
            var trans = m_ObjectToParentSnapsTo.transform;
            var min = col.center - col.size * 0.5f;
            var max = col.center + col.size * 0.5f;
            vertices[0] = trans.TransformPoint(new Vector3(min.x, min.y, min.z));
            vertices[1] = trans.TransformPoint(new Vector3(min.x, min.y, max.z));
            vertices[2] = trans.TransformPoint(new Vector3(min.x, max.y, min.z));
            vertices[3] = trans.TransformPoint(new Vector3(min.x, max.y, max.z));
            vertices[4] = trans.TransformPoint(new Vector3(max.x, min.y, min.z));
            vertices[5] = trans.TransformPoint(new Vector3(max.x, min.y, max.z));
            vertices[6] = trans.TransformPoint(new Vector3(max.x, max.y, min.z));
            vertices[7] = trans.TransformPoint(new Vector3(max.x, max.y, max.z));
            return vertices;
        }
        private void AttachSnapPoints(GameObject objecttosnap, Vector3[] vector3s)
        {
            foreach (var VARIABLE in vector3s)
            {
                var snappoint = Instantiate(new GameObject("_snappoint"), VARIABLE, Quaternion.identity, objecttosnap.transform);
                snappoint.tag = "snappoint";
                snappoint.layer = 10;
            }
        }

        private void CleanUpClones()
        {
            var temp = FindObjectsOfType<GameObject>();
            foreach (var VARIABLE in temp)
            {
                if (VARIABLE.name == "_snappoint" && VARIABLE.transform.position == Vector3.zero)
                {
                    DestroyImmediate(VARIABLE);
                }
            }

            temp = FindObjectsOfType<GameObject>();
            foreach (var VARIABLE in temp)
            {
                if (VARIABLE.name == "_snappoint(Clone)")
                {
                    VARIABLE.name = "_snappoint";
                    VARIABLE.SetActive(false);
                }
            }
        }
}
#endif