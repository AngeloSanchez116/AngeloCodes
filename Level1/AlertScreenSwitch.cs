using UnityEngine;

public class AlertScreenSwitch : MonoBehaviour
{
    public Material mat_Red;
    public Material mat_Blue;
    private float timer = 0.5f;
    private float resettime = 0f;
    public float timesetter;
    public bool matSwap;
    public bool startMatSwap = false;

    public MeshRenderer matRend;
    public Material _defaultMat;

    private void OnEnable()
    {
        TurnOnAlertOnTrigger.OnAlarmActivate += OnGobalAlarmActived;
        ResetLevel.OnLevelReset += OnGobalAlarmDeactivated;
    }

    private void OnDisable()
    {
        TurnOnAlertOnTrigger.OnAlarmActivate -= OnGobalAlarmActived;
        ResetLevel.OnLevelReset -= OnGobalAlarmDeactivated;
    }

    private void Start()
    {
        matRend = GetComponent<MeshRenderer>();
        _defaultMat = matRend.material;
    }
    // Update is called once per frame
    void Update()
    {
        if (matRend != null) {

            if (startMatSwap == true) {

                timer -= Time.deltaTime;

                if (timer < resettime && matSwap == true)
                {
                    matRend.material = mat_Blue;
                    timer = timesetter;
                    matSwap = false;
                }
                else if (timer < resettime && matSwap == false)
                {
                    matRend.material = mat_Red;
                    timer = timesetter;
                    matSwap = true;
                }
            }
        }
    }

    void OnGobalAlarmActived() {

        startMatSwap = true;
    }

    void OnGobalAlarmDeactivated() {

        startMatSwap = false;
        matRend.material = _defaultMat;
    }
}
