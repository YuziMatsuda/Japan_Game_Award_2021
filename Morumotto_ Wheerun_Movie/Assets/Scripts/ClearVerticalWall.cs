using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller.WallVertical;

/// <summary>
/// 縦向きの壁を移動する際の透明ブロック
/// </summary>
public class ClearVerticalWall : MonoBehaviour
{
    /// <summary>壁に対してどの位置に配置するか</summary>
    [SerializeField, Range(0, 3)] private int _position = (int)WallRunVerticalMode.TOP;
    /// <summary>壁に対してどの位置に配置するか</summary>
    public int Position {
        get {
            return _position;
        }
    }
}