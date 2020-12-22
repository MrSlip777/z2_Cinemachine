using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineChangebyKey : MonoBehaviour
{
    public float mMouseX = 0.0f; 

    [SerializeField]
    CinemachineFreeLook mFreeLook = null;

    [SerializeField]
    KeyCode KeyCounterclockwise = KeyCode.G;

    [SerializeField]
    KeyCode KeyClockwise = KeyCode.F;

    private float prelimitValue = 0.0f;
    private float limitValue = 0.0f;
    


	void Start ()
	{
		Cinemachine.CinemachineCore.GetInputAxis = Rotateby90degrees;
	}

    //90度ずつ回転
	public float Rotateby90degrees(string axisName)
	{
		if(axisName == "Mouse X")
		{
            if(prelimitValue == limitValue){
                if(Input.GetKeyDown(KeyCounterclockwise)){
                    mMouseX = 1.0f;

                    if(limitValue > -180){
                        limitValue -= 90;
                        
                    }
                    else{
                        limitValue = 90;
                    }
                }
                else if(Input.GetKeyDown(KeyClockwise)){
                    mMouseX = -1.0f;

                    if(limitValue < 180){
                        limitValue += 90;
                        
                    }
                    else{
                        limitValue = -90;
                    }
                }
                else{
                    
                }
            }

            if(mMouseX == 1.0f){
                if(-180.0f == limitValue){
                    limitValue = 180.0f;
                }

                if((mFreeLook.m_XAxis.Value < limitValue && limitValue != 180.0f)|| (mFreeLook.m_XAxis.Value > 0.0f && limitValue == 180.0f)){
                    mFreeLook.m_XAxis.Value = limitValue;
                    
                    mMouseX = 0.0f;
                    prelimitValue = limitValue;
                }
                
            }
            else if(mMouseX == -1.0f){
                if(180.0f == limitValue){
                    limitValue = -180.0f;
                }

                if((mFreeLook.m_XAxis.Value > limitValue && limitValue != -180.0f)|| (mFreeLook.m_XAxis.Value < 0.0f && limitValue == -180.0f)){
                    mFreeLook.m_XAxis.Value = limitValue;
                    mMouseX = 0.0f;
                    prelimitValue = limitValue;
                }
               
            }
            else{
                mFreeLook.m_XAxis.Value = limitValue;
            }

            return mMouseX;

		}
		else if (axisName == "Mouse Y")
		{
            return 0;
		}

		return 0;       
	}
}