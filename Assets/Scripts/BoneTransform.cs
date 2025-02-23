using UnityEngine;

public class BoneTransform : MonoBehaviour
{
    [SerializeField] Transform ShoulderBone;
    [SerializeField] Transform ElbowBone;
    [SerializeField] Transform WristBone;
    [SerializeField] Vector3 ShoulderAngles;
    [SerializeField] Vector3 ElbowAngles;
    [SerializeField] Vector3 WristAngles;

    void Start()
    {
        
    }


    void Update()
    {

        //Lock other axis at value
        //set roation according to height
        //clamp value

    }
    private void LateUpdate()
    {
        
        ShoulderAngles.z += (PlayerController.instance.aimVal * 200 * Time.deltaTime);
        ShoulderAngles.z = Mathf.Clamp(ShoulderAngles.z, -200, -50);
        ShoulderBone.localRotation = Quaternion.Euler(ShoulderAngles);    
        
        ElbowBone.localRotation = Quaternion.Euler(ElbowAngles);
        WristBone.localRotation = Quaternion.Euler(WristAngles);
        
    }
}
