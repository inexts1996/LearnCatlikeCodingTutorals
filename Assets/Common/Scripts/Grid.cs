using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    [SerializeField]
    private int xSize = 10;
    [SerializeField]
    private int ySize = 5;
    private Vector3[] vertices;
    private void Awake()
    {
        StartCoroutine(Generate());
    }
    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        // 计算网格顶点坐标（基于对象本地坐标系）
        for (int y = 0, i = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y, 0);
                yield return wait;
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDrawGizmos()
    {
        if (vertices == null) return;
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
