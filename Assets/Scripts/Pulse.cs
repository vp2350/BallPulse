using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{

    public AnimationCurve expandCurve;
    public float expandAmount;
    public float expandSpeed;

    Vector3 m_startSize;
    Vector3 m_targetSize;
    float m_scrollAmount;

    // Start is called before the first frame update
    void Start()
    {
        InitPulseEffectVariables();
    }

    void InitPulseEffectVariables()
    {
        m_startSize = transform.localScale;
        m_targetSize = m_startSize * expandAmount;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get mouse position
        transform.localPosition = new Vector3(mousePos.x, mousePos.y, -1);
        MakeCursorPulse();
    }

    public void MakeCursorPulse()
    {
        m_scrollAmount += Time.deltaTime * expandSpeed;
        float _percent = expandCurve.Evaluate(m_scrollAmount);

        transform.localScale = Vector2.Lerp(m_startSize, m_targetSize, _percent);
    }
}
