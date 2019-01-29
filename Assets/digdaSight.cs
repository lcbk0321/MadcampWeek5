using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class digdaSight : MonoBehaviour
{

   // public GameObject control = GameObject.FindWithTag("Map3Control");


    [SerializeField] private bool m_bDebugMode = false;

    [Header("View Config")]
    [Range(0f, 360f)]
    [SerializeField] private float m_horizontalViewAngle = 60f; // 시야각
    [SerializeField] private float m_viewRadius = 1f; // 시야 범위
    [Range(-180f, 180f)]
    [SerializeField] private float m_viewRotateZ; // 시야각의 회전값

    [SerializeField] private LayerMask m_viewTargetMask;       // 인식 가능한 타켓의 마스크
    [SerializeField] private LayerMask m_viewObstacleMask;     // 인식 방해물의 마스크 

    private List<Collider2D> hitedTargetContainer = new List<Collider2D>(); // 인식한 물체들을 보관할 컨테이너

    private float m_horizontalViewHalfAngle = 0f; // 시야각의 절반 값

    //public GameObject control;

    public GameObject m_monster;
    Mesh mesh;
    MeshFilter meshFilter;
    MeshCollider meshCollider;
    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    int i;
    public float intervalDegree = 5;
    float beginDegree;
    float endDegree;
    float beginRadian;
    float endRadian;
    float uvRadius = 0.5f;
    Vector2 uvCenter = new Vector2(0.5f, 0.5f);
    float currentIntervalDegree = 0;
    float limitDegree;
    int count;
    int lastCount;

    float beginCos;
    float beginSin;
    float endCos;
    float endSin;

    int beginNumber;
    int endNumber;
    int triangleNumber;

    // Use this for initialization 
    void Start()
    {
        m_viewRadius = 7;
        transform.position = m_monster.transform.position;
        mesh = new Mesh();
        meshFilter = (MeshFilter)GetComponent("MeshFilter");
        meshCollider = (MeshCollider)GetComponent("MeshCollider");
    }

    // Update is called once per frame 
    void Update()
    {
        m_viewRotateZ = (m_viewRotateZ + 1) % 360;
        currentIntervalDegree = Mathf.Abs(intervalDegree);

        count = (int)(Mathf.Abs(m_horizontalViewAngle) / currentIntervalDegree);
        if (m_horizontalViewAngle % intervalDegree != 0)
        {
            ++count;
        }
        if (m_horizontalViewAngle < 0)
        {
            currentIntervalDegree = -currentIntervalDegree;
        }

        if (lastCount != count)
        {
            mesh.Clear();
            vertices = new Vector3[count * 2 + 1];
            triangles = new int[count * 3];
            uvs = new Vector2[count * 2 + 1];
            vertices[0] = Vector3.zero;
            uvs[0] = uvCenter;
            lastCount = count;
        }

        i = 0;
        beginDegree = m_viewRotateZ + 76;
        limitDegree = m_horizontalViewAngle + m_viewRotateZ + 76;

        while (i < count)
        {
            endDegree = beginDegree + currentIntervalDegree;

            if (m_horizontalViewAngle > 0)
            {
                if (endDegree > limitDegree)
                {
                    endDegree = limitDegree;
                }
            }
            else
            {
                if (endDegree < limitDegree)
                {
                    endDegree = limitDegree;
                }
            }

            beginRadian = Mathf.Deg2Rad * beginDegree;
            endRadian = Mathf.Deg2Rad * endDegree;

            beginCos = Mathf.Cos(beginRadian);
            beginSin = Mathf.Sin(beginRadian);
            endCos = Mathf.Cos(endRadian);
            endSin = Mathf.Sin(endRadian);

            beginNumber = i * 2 + 1;
            endNumber = i * 2 + 2;
            triangleNumber = i * 3;

            vertices[beginNumber].x = beginCos * m_viewRadius;
            vertices[beginNumber].y = 0;
            vertices[beginNumber].z = beginSin * m_viewRadius;

            vertices[endNumber].x = endCos * m_viewRadius;
            vertices[endNumber].y = 0;
            vertices[endNumber].z = endSin * m_viewRadius;

            triangles[triangleNumber] = 0;

            if (m_horizontalViewAngle > 0)
            {
                triangles[triangleNumber + 1] = endNumber;
                triangles[triangleNumber + 2] = beginNumber;
            }
            else
            {
                triangles[triangleNumber + 1] = beginNumber;
                triangles[triangleNumber + 2] = endNumber;
            }

            if (m_viewRadius > 0)
            {
                uvs[beginNumber].x = beginCos * uvRadius + uvCenter.x;
                uvs[beginNumber].y = beginSin * uvRadius + uvCenter.y;
                uvs[endNumber].x = endCos * uvRadius + uvCenter.x;
                uvs[endNumber].y = endSin * uvRadius + uvCenter.y;

            }
            else
            {
                uvs[beginNumber].x = -beginCos * uvRadius + uvCenter.x;
                uvs[beginNumber].y = -beginSin * uvRadius + uvCenter.y;
                uvs[endNumber].x = -endCos * uvRadius + uvCenter.x;
                uvs[endNumber].y = -endSin * uvRadius + uvCenter.y;
            }

            beginDegree += currentIntervalDegree;
            ++i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter.sharedMesh = mesh;
        meshFilter.sharedMesh.name = "CircularSectorMesh";
        meshCollider.sharedMesh = mesh;
        meshCollider.sharedMesh.name = "CircularSectorMesh";
        //FindViewTargets();
    }

    private void Awake()
    {
        m_horizontalViewHalfAngle = m_horizontalViewAngle * 0.5f;
    }

    /*private void OnDrawGizmos()
    {
        if (m_bDebugMode)
        {
            m_horizontalViewHalfAngle = m_horizontalViewAngle * 0.5f;

            Vector3 originPos = transform.position;

            Gizmos.DrawWireSphere(originPos, m_viewRadius);

            Vector3 horizontalRightDir = AngleToDirZ(m_horizontalViewHalfAngle + m_viewRotateZ);
            Vector3 horizontalLeftDir = AngleToDirZ(-m_horizontalViewHalfAngle + m_viewRotateZ);
            Vector3 lookDir = AngleToDirZ(m_viewRotateZ);

            Debug.DrawRay(originPos, horizontalLeftDir * m_viewRadius, Color.cyan);
            Debug.DrawRay(originPos, lookDir * m_viewRadius, Color.green);
            Debug.DrawRay(originPos, horizontalRightDir * m_viewRadius, Color.cyan);
            
        }
    }*/

    /*public Collider2D[] FindViewTargets()
    {
        hitedTargetContainer.Clear();

        Vector3 originPos = transform.position;
        Collider2D[] hitedTargets = Physics2D.OverlapCircleAll(originPos, m_viewRadius, m_viewTargetMask);
        Debug.Log(hitedTargets.Length);
        foreach (Collider2D hitedTarget in hitedTargets)
        {
            Vector3 targetPos = hitedTarget.transform.position;
            Vector3 dir = (targetPos - originPos).normalized;
            Vector3 lookDir = AngleToDirZ(m_viewRotateZ);

            // float angle = Vector3.Angle(lookDir, dir)
            // 아래 두 줄은 위의 코드와 동일하게 동작함. 내부 구현도 동일
            float dot = Vector3.Dot(lookDir, dir);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (angle <= m_horizontalViewHalfAngle)
            {
                RaycastHit2D rayHitedTarget = Physics2D.Raycast(originPos, dir, m_viewRadius, m_viewObstacleMask);
                if (rayHitedTarget)
                {
                    if (m_bDebugMode)
                    {
                        Debug.DrawLine(originPos, rayHitedTarget.point, Color.yellow);
                        Debug.Log("hit a player");
                    }
                    Debug.Log("hit a player");
                }
                else
                {
                    hitedTargetContainer.Add(hitedTarget);

                    if (m_bDebugMode)
                        Debug.DrawLine(originPos, targetPos, Color.red);
                }
            }
        }

        if (hitedTargetContainer.Count > 0)
            return hitedTargetContainer.ToArray();
        else
            return null;
    }*/

    // -180~180의 값을 Up Vector 기준 Local Direction으로 변환시켜줌.
    private Vector3 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.y) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
    }
}
