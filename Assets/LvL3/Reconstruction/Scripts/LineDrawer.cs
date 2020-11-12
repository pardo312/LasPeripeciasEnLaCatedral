using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : IntEventInvoker
{
    [SerializeField] private GameObject drawingPointsParent;
    private List<GameObject> drawingPoints;

    private LineRenderer lineRenderer;
    private Vector2 currentMousePosition;

    private GameWonEvent gameWonEvent;

    private bool stop = false;

    private void Start()
    {
        GetDrawingPoints();
        InitializeLineRenderer();
        InitializeGameWonEvent();
    }

    private void InitializeGameWonEvent()
    {
        gameWonEvent = new GameWonEvent();
        unityEvents.Add(EventName.gameWonEvent, gameWonEvent);
        EventManager.AddInvoker(EventName.gameWonEvent, this);
    }

    void Update()
    {
        if (!stop)
        {
            DrawCurrentMousePosition();
            MouseObjectHit();
        }
    }

    private void GetDrawingPoints()
    {
        Transform parentTransform = drawingPointsParent.transform;
        drawingPoints = new List<GameObject>();

        foreach (Transform child in parentTransform)
        {
            drawingPoints.Add(child.gameObject);
        }
    }

    private void SetLineRendererPoint(Vector3 point)
    {
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(point.x, point.y, 0f));
        if(lineRenderer.positionCount > drawingPoints.Count + 1)
        {
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
            gameWonEvent.Invoke(0);
            enabled = false;
        }
    }

    private void AddLineRendererPoint()
    {
        lineRenderer.positionCount++;
        DrawCurrentMousePosition();
    }

    private void InitializeLineRenderer()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        Vector3 initPointPosition = drawingPoints[0].transform.position;
        SetLineRendererPoint(initPointPosition);
        AddLineRendererPoint();
    }

    private void DrawCurrentMousePosition()
    {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SetLineRendererPoint(currentMousePosition);
    }

    private void MouseObjectHit()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == null)
            {
                return;
            }

            GameObject collidedObject = hit.collider.gameObject;
            if (drawingPoints.Contains(collidedObject))
            {
                Vector3 collidedObjectPosition = collidedObject.transform.position;

                if ((lineRenderer.positionCount - 1 == drawingPoints.Count && collidedObject == drawingPoints[0]) ||
                    (drawingPoints[lineRenderer.positionCount - 1] == collidedObject))
                {
                    SetLineRendererPoint(collidedObjectPosition);
                    AddLineRendererPoint();
                    AudioManager.Play(AudioClipName.GoodInput);
                }
                else
                {
                    SetLineRendererPoint(collidedObjectPosition);
                    StartCoroutine(Fail());
                    AudioManager.Play(AudioClipName.BadInput);
                }
            }
        }
    }

    private IEnumerator Fail()
    {
        stop = true;
        lineRenderer.endColor = Color.red;
        yield return new WaitForSeconds(0.5f);
        lineRenderer.endColor = Color.white;
        stop = false;
    }
}
