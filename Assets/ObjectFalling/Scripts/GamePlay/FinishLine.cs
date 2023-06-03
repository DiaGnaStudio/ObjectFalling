using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiaGna.ObjectFalling.GroundUtility;
using DiaGna.ObjectFalling.BrickUtility;

namespace DiaGna.ObjectFalling.Gameplay
{
    public class FinishLine : MonoBehaviour
    {
        private void OnEnable()
        {
            Ground.Instance.GroundRotator.OnEndRotation += CheckBricksHeight;
        }
        private void OnDisable()
        {
            Ground.Instance.GroundRotator.OnEndRotation -= CheckBricksHeight;
        }

        private void CheckBricksHeight(Brick brick)
        {
            Debug.Log("brick Hight =" + brick.GetBrickHight() + "   finish Hight =" + transform.position.y);
            bool isReached = brick.GetBrickHight() > transform.position.y;
            if (isReached)
            {
                Debug.Log("Win");
                //Todo: Win
            }
        }
    }
}
