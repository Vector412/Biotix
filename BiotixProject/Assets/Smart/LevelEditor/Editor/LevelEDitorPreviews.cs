using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Smart
{
	public partial class LevelEditor
    {

        private List<GameObject> previews = new List<GameObject>();

        public void CreatePreviews()
        {
            DeletePreviews();

            int count = size.x * size.y * size.z;

            GameObject result;

            for (int i = 0; i < count; i++)
            {
                result = GetObject() as GameObject;

                if (null == result) { continue; }

                result = PrefabUtility.InstantiatePrefab(result) as GameObject;

                if (null == result) { continue; }

                DisablePreviewColliders(result);
                result.transform.Rotate(angle);
                result.hideFlags = HideFlags.HideInHierarchy;

                previews.Add(result);
            }
        }

        void DisablePreviewColliders(GameObject go)
        {
            Collider[] col = go.GetComponentsInChildren<Collider>();

            for (int i = 0; i < col.Length; i++)
            {
                col[i].enabled = false;
            }
        }

        void DeletePreviews()
        {
            for (int i = 0; i < previews.Count; i++)
            {
                DestroyImmediate(previews[i]);
                previews[i] = null;
            }

            previews.Clear();
        }

        void UpdatePreviews(Vector3[] pos)
        {
            for (int i = 0; i < previews.Count; i++)
            {
                previews[i].transform.position = pos[i];
            }
        }

        void PreviewGUIChanged()
        {
            if(active && mode == Mode.Create)
            {
                CreatePreviews();

                return;
            }
            
            if(!active || mode != Mode.Create)
            {
                DeletePreviews();
            }
        }
    }
}
