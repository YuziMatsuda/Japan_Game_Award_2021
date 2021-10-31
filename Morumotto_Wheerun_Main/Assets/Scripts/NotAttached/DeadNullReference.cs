using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const.Component;

namespace DeadException
{
    /// <summary>
    /// コンポーネントを参照した際の例外を回避
    /// </summary>
    public static class DeadNullReference
    {
        /// <summary>
        /// コンポーネント参照例外を回避
        /// </summary>
        /// <param name="gameObject">オブジェクト</param>
        /// <param name="name">スクリプト名</param>
        /// <returns></returns>
        public static bool CheckReferencedComponent(GameObject gameObject, string name)
        {
            var result = false;
            var message = "";
            try
            {
                if (name.Equals(ComponentManager.MOVE_WALLS))
                {
                    var v = gameObject.GetComponent<MoveWalls>().RigidbodyVelocity;
                    result = true;
                }
                else if (name.Equals(ComponentManager.CALAMARI_STATE))
                {
                    var t = gameObject.GetComponent<CalamariState>()._transform;
                    if (t == null)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                else if (name.Equals(ComponentManager.MARMOT_HEALTH))
                {
                    var t = gameObject.GetComponent<MarmotHealth>()._health;
                    result = true;
                }
                else if (name.Equals(ComponentManager.CHARACTER_CONTROLLER))
                {
                    var c = gameObject.GetComponent<CharacterController>();
                    if (c.enabled == true)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(ComponentManager.CALAMARI_MOVE_CONTROLLER))
                {
                    var c = gameObject.GetComponent<CalamariMoveController>();
                    if (c.enabled == true)
                    {
                        var velocity = c.MoveVelocityAngl;
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(ComponentManager.NENCHAK_MOVE_CONTROLLER))
                {
                    var c = gameObject.GetComponent<NenchakMoveController>();
                    if (c.isActiveAndEnabled == true)
                    {
                        var velocity = c.MoveVelocityAngl;
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(ComponentManager.TSURUTSURU_MOVE_CONTROLLER))
                {
                    var c = gameObject.GetComponent<TsuruTsuruMoveController>();
                    if (c.enabled == true)
                    {
                        var velocity = c.MoveVelocityAngl;
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(ComponentManager.CONVEYOR_MOVE_CHARACTER))
                {
                    var c = gameObject.GetComponent<ConveyorMoveCharacter>();
                    if (c.enabled == true)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(ComponentManager.ICE_PLANE))
                {
                    var c = gameObject.GetComponent<IcePlane>();
                    if (c.isActiveAndEnabled == true && c._icePlane == true)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(new PlayerManager().GetType().ToString()))
                {
                    var m = gameObject.GetComponent<PlayerManager>();
                    if (m.isActiveAndEnabled == true)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(new PlayerEffectController().GetType().ToString()))
                {
                    var m = gameObject.GetComponent<PlayerEffectController>();
                    if (m.isActiveAndEnabled == true)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(new DashPanel().GetType().ToString()))
                {
                    var m = gameObject.GetComponent<DashPanel>();
                    if (m.isActiveAndEnabled == true)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(new CalamariHealth().GetType().ToString()))
                {
                    var m = gameObject.GetComponent<CalamariHealth>();
                    if (m.isActiveAndEnabled == true)
                    {
                        result = true;
                        var p = m.Parameter;
                        var a = m.Adhesive;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(new NenchakHealth().GetType().ToString()))
                {
                    var m = gameObject.GetComponent<NenchakHealth>();
                    if (m.isActiveAndEnabled == true)
                    {
                        result = true;
                        var p = m.Parameter;
                        var a = m.Adhesive;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(new TippedSaw().GetType().ToString()))
                {
                    var m = gameObject.GetComponent<TippedSaw>();
                    if (m.isActiveAndEnabled == true)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else if (name.Equals(new CircleRing().GetType().ToString()))
                {
                    var m = gameObject.GetComponent<CircleRing>();
                    if (m.isActiveAndEnabled == true)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                message = e + "";
                result = false;
            }
            catch (MissingComponentException e)
            {
                message = e + "";
                result = false;
            }
            finally
            {
                if (result == false)
                {
                    // 確認の為、デバッグログに出力していたが、他のデバッグ表示で邪魔になる為、一時的にコメントアウト
                    if (0 < message.Length)
                    {
                        //Debug.Log(name + "_Null参照：" + message);
                    }
                    else
                    {
                        //Debug.Log(name + "_Null参照");
                    }
                }
            }

            return result;
        }
    }
}