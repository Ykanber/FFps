using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{

    // uiConnection
    ExpLwHealthUI ui;
    [SerializeField] TextMeshProUGUI materialText;

    //skill system
    public int upgradeMaterial;
    public int hpLevel;
    public int pistolMastery;
    public int rifleMastery;
    public int deathCount;


    //level system
    public int level;
    public int currentExp;
    public int[] expToNextLevel;

    public int[] levelToGunChange;


    float moveSpeed = 15;
    float upDownLookSpeed = -5;
    float leftRightLookSpeed = 8;


    [SerializeField] float jumpHeight = 1f;

    CharacterController characterController;
    Vector2 inputVec;
    public Transform head;
    Vector3 JumpVector;

    Vector3 lookVector;

    //crouching
    bool isCrouching;
    Vector3 crouchingScale = new Vector3(1f, 0.4f, 1f);
    Vector3 currentScale = new Vector3(1f, 1f, 1f);
    Vector3 gunScale = new Vector3(0.3f, 1.6f, 2f);
    Vector3 gunCrouchScale = new Vector3(0.3f, 3.2f, 2f);

    
    

    public GameObject Gun;

    void Awake()
    {
        LoadPlayer();
        GunMasterySet();
        ui = FindObjectOfType<ExpLwHealthUI>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        materialText.text = upgradeMaterial.ToString();
    }


    void Update()
    {
        HandleMove();
    }

    private void LateUpdate()
    {
        HandleLook();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVec = context.ReadValue<Vector2>();
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        lookVector.x = input.x;
        lookVector.z = input.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if(context.performed && characterController.isGrounded)
        {
            JumpVector.y = jumpHeight;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {

        if (context.performed && !isCrouching)
        {
            moveSpeed = 30f;
        }
        else if (context.canceled)
        {
            moveSpeed = 15f;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.localScale = crouchingScale;
            moveSpeed = 5f;
            Gun.transform.localScale = gunCrouchScale;
        }
        else if (context.canceled)
        {
            transform.localScale = currentScale;
            moveSpeed = 15f;
            Gun.transform.localScale = gunScale;
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        bool shoot = context.ReadValueAsButton();
        if (context.performed || context.canceled)
        {
            Gun.GetComponent<Gun>().Shoot(shoot);
        }
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        bool reload = context.ReadValueAsButton();
        if (reload && context.performed)
        {
            Gun.GetComponent<Gun>().Reload();
        }
    }
    void HandleMove()
    {
        Vector3 tempVec = inputVec.x * transform.right + inputVec.y * transform.forward;
        tempVec *= moveSpeed;

        if (!characterController.isGrounded)
        {
            JumpVector.y += Physics.gravity.y * 0.2f;
        }
        tempVec += JumpVector;
        characterController.Move(tempVec * Time.deltaTime);
    }

    void HandleLook()
    {
        Vector3 bodyTransform = transform.rotation.eulerAngles;

        bodyTransform.y += lookVector.x * Time.deltaTime * leftRightLookSpeed;

        transform.localRotation = Quaternion.Euler(0,bodyTransform.y, 0);

        Vector3 headTransform = head.transform.rotation.eulerAngles;

        headTransform.x += lookVector.z * Time.deltaTime * upDownLookSpeed;

        if (headTransform.x > 45 && headTransform.x < 180)
        {
            headTransform.x = 45;
        }
        else if (headTransform.x < 315 && headTransform.x > 180)
        {
            headTransform.x = 315;
        }
        head.transform.localRotation = Quaternion.Euler(headTransform.x, 0, 0);
    }

    public void addExperience(int amount)
    {
        currentExp += amount;
        if(currentExp >= expToNextLevel[level])
        {
            currentExp = 0;
            level += 1;
            ui.ChangeLwText(level+1);
        }
        ui.ChangeexpSlider((float)currentExp / expToNextLevel[level]);
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();

        hpLevel = playerData.hpLevel;
        pistolMastery = playerData.pistolMastery;
        rifleMastery = playerData.rifleMastery;
        deathCount = playerData.deathCount;
        upgradeMaterial = playerData.upgradeMaterial;
    }

    void GunMasterySet()
    {
        Gun gun = Gun.GetComponent<Gun>();
        if(gun.gunType == GunTypes.Pistol)
        {
            gun.gunMasteryVariable = pistolMastery;
        }
        else
        {
            gun.gunMasteryVariable = rifleMastery;
        }
        gun.AddMasteryDamage();
    }

    public void IncreaseUpgradeMaterial()
    {
        upgradeMaterial++;
        materialText.text = upgradeMaterial.ToString();
    }
}
