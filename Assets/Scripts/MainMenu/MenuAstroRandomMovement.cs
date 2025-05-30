using System.Collections;
using UnityEngine;

public class MenuAstroRandomMovement : MonoBehaviour
{
    float chanceToMovePercent = 100f;
    float chanceToChangeDirectionPercent = 33f;
    public bool isMovingThisFrame;
    float maxDistXPos = 200;
    float maxDistXNeg = -400;
    float maxDistY = 115;
    float angle;

    public Vector2 motion;

    public Transform characterXf;
    public Transform rotationXf;

    void Start()
    {

        StartCoroutine(MoveCharacter(characterXf));
        StartCoroutine(RotateCharacter(rotationXf));

    }

    IEnumerator MoveCharacter(Transform tXf)
    {
        while (true)
        {
            float dist = Random.Range(20, 120);

            motion = CalculateMotion(dist);

            if (motion.x > maxDistXPos)
            {
                motion.x = maxDistXPos;
            }
            else if (motion.x < maxDistXNeg)
            {
                motion.x = maxDistXNeg;
            }
            if (Mathf.Abs(motion.y) > maxDistY) motion.y = maxDistY * Mathf.Sign(motion.y);

            tXf.LeanMoveLocal(new Vector2(motion.x + 744, motion.y - 289), 1.5f).setEaseInOutSine();

            yield return new WaitForSecondsRealtime(1.5f);
        }
    }

    IEnumerator RotateCharacter(Transform rXf)
    {
        while (true)
        {
            rXf.LeanRotateZ(angle, 20f).setEaseInOutSine();

            yield return new WaitForSecondsRealtime(20f);
        }
    }

    Vector2 CalculateMotion(float dist)
    {
        float distX = 0f;
        float distY = 0f;

        if (Random.Range(0, 100) <= chanceToMovePercent)
        {
            isMovingThisFrame = true;
            if (Random.Range(0, 100) <= chanceToChangeDirectionPercent)
            {
                angle = Random.Range(1, 360);
            }

            distX = Mathf.Cos(angle) * dist;
            distY = Mathf.Sin(angle) * dist;
        }
        else
        {
            isMovingThisFrame = false;

        }

        return new Vector2(distX, distY);
    }
}
