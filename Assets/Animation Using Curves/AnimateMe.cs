using UnityEngine;
using System.Collections;

public class AnimateMe : MonoBehaviour {

    public float animationTime = 2, yMag;
    public AnimationCurve yCurve;

    private bool isAnimating = false;

    void OnGUI()
    {
        if(!isAnimating && GUI.Button(new Rect(0, 0, 100, 50),"Animate"))
        {
            StartCoroutine(StartAnimation());
        }

        if (!isAnimating && GUI.Button(new Rect(150, 0, 100, 50), "Restart"))
        {
            LoadingSceneManager.LoadLevel(0);
        }
    }

    private IEnumerator StartAnimation()
    {
        isAnimating = true;
        float timeLapsed = 0;
        float fact = 0;
        Vector3 initPos = transform.position;

        while(timeLapsed <= animationTime)
        {
            fact = timeLapsed / animationTime;
            timeLapsed += Time.deltaTime;
            print(fact);
            transform.position = initPos + (Vector3)MotionFunc(fact);

            yield return null;
        }
        transform.position = initPos;
        isAnimating = false;

        yield return null;
    }

    Vector2 MotionFunc(float fact)
    {
        float y = yCurve.Evaluate(fact) * yMag;
        return new Vector2(0, y);
    }
}
