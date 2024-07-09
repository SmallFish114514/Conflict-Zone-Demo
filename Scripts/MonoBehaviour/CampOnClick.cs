using System.Collections;
using UnityEngine;
public class CampOnClick : MonoBehaviour
{
    private ICamp mCamp;
    public ICamp camp { set { mCamp = value; } }
    private void OnMouseUpAsButton()
    {
        GameFacade.Instance.ShowCampInfo(mCamp);
    }    
}
