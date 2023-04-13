using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FixMath.NET;


public enum MoveDir
{
    Up,
    Down,
    Left,
    Right,
}

[System.Serializable]
public class MoveCommand
{
    [SerializeField] MoveDir dir = MoveDir.Up;
    [SerializeField] int count = 0;

    public MoveDir Dir => dir;
    public int Count => count;
}

public class TestScript : MonoBehaviour
{
    [SerializeField] List<MoveCommand> moveCommands;

    Fix64 speed = (Fix64)12.12542729f;
    int commandIndex = 0;
    bool isMoveEnd = false;

    int testCount = 0;
    const int maxTestCount = 100;
    List<FixVector3> testResult = new List<FixVector3>();

    FixVector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = FixVector3.Zero;
        commandIndex = 0;
        isMoveEnd = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoveEnd) return;

        FixVector3 dir = FixVector3.Zero;

        switch(moveCommands[commandIndex].Dir)
        {
            case MoveDir.Up:
                dir = FixVector3.Forward;
                break;
            case MoveDir.Down:
                dir = FixVector3.Back;
                break;
            case MoveDir.Left:
                dir = FixVector3.Left;
                break;
            case MoveDir.Right:
                dir = FixVector3.Right;
                break;
        }

        pos += dir * (speed * (Fix64)moveCommands[commandIndex].Count);

        transform.position = pos.ToVector3();

        ++commandIndex;

        if(commandIndex == moveCommands.Count)
        {
            ++testCount;
            testResult.Add(pos);
            Debug.Log($"IsMoveEnd x : {pos.x} y : {pos.y}, z : {pos.z}");
            pos = FixVector3.Zero;
            commandIndex = 0;
            if(testCount >= maxTestCount)
            {
                isMoveEnd = true;
                bool isSame = true;
                for(int i = 1; i < testResult.Count; ++i)
                {
                    if(Fix64.Equals(testResult[i - 1].x, testResult[i].x) == false ||
                        Fix64.Equals(testResult[i - 1].y, testResult[i].y) == false ||
                        Fix64.Equals(testResult[i - 1].z, testResult[i].z) == false)
                    {
                        isSame = false;
                        break;
                    }
                }

                Debug.Log($"IsSame : {isSame}");
            }
        }
    }
}
