using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG_Main : ParallaxBackground_0
{
    public override void MoveCamera()
    {
        _camera.position =
            new Vector3(player.transform.position.x + 7f,
                _camera.position.y,
                _camera.position.z);
    }

    public override void SetLayerSpeed()
    {
        for (int i = 0; i < 5; i++)
        {
            float temp = (_camera.position.x * (1 - Layer_Speed[i]));
            float distance = _camera.position.x * Layer_Speed[i];
            Layer_Objects[i].transform.position =
                new Vector2(startPos[i] + distance, _camera.position.y + 3f);
            if (temp > startPos[i] + boundSizeX * sizeX)
            {
                startPos[i] += boundSizeX * sizeX;
            }
            else if (temp < startPos[i] - boundSizeX * sizeX)
            {
                startPos[i] -= boundSizeX * sizeX;
            }
        }
    }
}
