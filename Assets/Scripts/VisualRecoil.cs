using UnityEngine;

public class VisualRecoil : MonoBehaviour

{
    Vector3 targetPos;
    Vector3 currentPos;

    [SerializeField] float recoilAmount;
    [SerializeField] float recoilTurnAmount;

    //Settings
    [SerializeField] float returnSpeed;
    [SerializeField] float snappiness;


    void Update()
    {
        targetPos = Vector3.Lerp(targetPos, Vector3.zero, returnSpeed * Time.deltaTime);
        currentPos = Vector3.Slerp(currentPos, targetPos, snappiness * Time.fixedDeltaTime);
        transform.localPosition = currentPos;
    }

    public void RecoilFire()
    {
        targetPos += new Vector3(0, 0, recoilAmount);
    }
}
