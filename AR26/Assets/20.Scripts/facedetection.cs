
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class facedetection : MonoBehaviour
{
    public GameObject positioncube;

    private ARFaceManager afm;
    private ARFace face = null;

    private int index = 0;

    // 생성된 큐브 저장
    private List<GameObject> cubes = new List<GameObject>();

    void Awake()
    {
        afm = GetComponent<ARFaceManager>();

        afm.trackablesChanged.AddListener(args =>
        {
            // 새 얼굴 인식
            foreach (var f in args.added)
            {
                face = f;
                index = 0;
            }

            // 얼굴 추적 종료
            foreach (var kf in args.removed)
            {
                if (kf.Value == face)
                {
                    face = null;
                    index = 0;
                }
            }
        });
    }

    public void onclick()
    {
        if (face == null) return;

        // 얼굴 정점 가져오기
        var vertices = face.vertices;

        if (vertices.Length == 0) return;

        // 마지막 정점이면 처음부터 시작
        if (index >= vertices.Length)
        {
            index = 0;
        }

        // 정점의 월드 좌표 계산
        Vector3 pos = face.transform.TransformPoint(vertices[index]);

        // 새로운 큐브 생성
        GameObject newCube = Instantiate(
            positioncube,
            pos,
            Quaternion.identity
        );

        // 생성된 큐브 저장
        cubes.Add(newCube);

        // 다음 정점으로 이동
        index++;
    }
}
