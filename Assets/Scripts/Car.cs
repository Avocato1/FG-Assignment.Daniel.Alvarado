using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Car : MonoBehaviour
{
   [Header("Wheel Colliders")]
   [SerializeField] private List<WheelCollider> wheelColliders;
   [SerializeField] private float desiredStiffness = 0f;
   private WheelFrictionCurve originalBackLeftSidewaysFriction;
   private WheelFrictionCurve originalBackRightSidewaysFriction;
   [Space]
   [Header("Wheel Meshes")]
   [SerializeField] private List<Transform> wheelMeshes;
   [SerializeField] private List<Transform> groundCheckers;
   [SerializeField] private List<ParticleSystem> tireSmokes;
   [SerializeField] private List<TrailRenderer> tireTrails;
   [Space]
   [Header("Car Settings")]
   [SerializeField] private float breakingForce = 300f;
   [SerializeField] private float maxSteeringAngle = 20f;
   [SerializeField] private float currentBreakingForce = 0f;
   [SerializeField] private float currentTurnAngle = 0f;
   [SerializeField] private float turnSpeed = 15f;
   public TextMeshProUGUI speedText;
   public float maxSpeed = 10f;
   public float acceleration = 75f;
   public float currentAcceleration = 0f;
   public float currentSpeed = 0f;
   private float drive = 0f;
   [Space]
   [Header("References")]
   private PlayerInput input = null;
   public Rigidbody rb = null;
   public GameObject centerOfMass;
   private CountdownTimer countdownTimer;
   [HideInInspector]
   public CarStats carStats;
   private GameManager gameManager;

   public int playerIndex;
   private void Awake()
   {
       originalBackLeftSidewaysFriction = wheelColliders.ElementAt(2).sidewaysFriction;
       originalBackRightSidewaysFriction = wheelColliders.ElementAt(3).sidewaysFriction;
       gameManager = FindObjectOfType<GameManager>();
       playerIndex = gameManager.playerIndex[gameManager.playerCars.IndexOf(gameObject)];
       carStats = GetComponent<CarStats>();
       speedText.text = currentSpeed + " km/h";
      
       countdownTimer = FindObjectOfType<CountdownTimer>();

       input = GetComponent<PlayerInput>();
       rb.centerOfMass = centerOfMass.transform.localPosition;

       input.actions.FindAction("Acceleration").performed += OnMoveInput;
       input.actions.FindAction("Acceleration").canceled += OnMoveInput;
   }

   private void OnEnable()
   {
       input.actions.Enable();
   }


   private void OnDisable()
   {
       input.actions.Disable();
   }


   private void FixedUpdate()
   {
       if (countdownTimer.currentCountDownTime > 0) return;

      
      
       if (carStats.currentHealth <= 0)
       {
           if (carStats.checkpoint == false)
           {
               carStats.healthText.text = carStats.maxHealth.ToString();
               carStats.currentFuel = carStats.maxFuel;
               carStats.currentHealth = carStats.maxHealth;
               rb.velocity = Vector3.zero;
               ResetPosition();
           }
           else if (carStats.checkpoint)
           {
               carStats.healthText.text = carStats.maxHealth.ToString();
               carStats.currentFuel = carStats.maxFuel;
               carStats.currentHealth = carStats.maxHealth;
               rb.position = carStats.checkPoint.transform.position;
               rb.rotation = carStats.checkPoint.transform.rotation;
               rb.velocity = Vector3.zero;
           }
          
       }

       CarSpeed();
       Brake();
       carStats.Fuel();
       UpdateWheel(wheelColliders[0], wheelMeshes[0]);
       ResetPositionButton();
       
       Steering();
       IsGrounded();
   }


   private void CarSpeed()
   {
       currentSpeed = rb.velocity.magnitude * 10f;
  
       if (currentSpeed < 0.01f)
       {
           currentSpeed = 0f;
       }
  
       speedText.text = currentSpeed.ToString("0") + " km/h";
  
       if (rb.velocity.magnitude > maxSpeed)
       {
           rb.velocity = rb.velocity.normalized * maxSpeed;
           currentSpeed = maxSpeed;
       }
       currentAcceleration = drive * acceleration;
  
       wheelColliders.ForEach(wheelCollider => wheelCollider.motorTorque = currentAcceleration);
   }
   private void Steering()
   {
       currentTurnAngle = maxSteeringAngle * input.actions.FindAction("Steering").ReadValue<float>();
       for (int i = 0; i < 2; i++)
       {
           wheelColliders.ElementAt(i).steerAngle = currentTurnAngle * Time.deltaTime * turnSpeed; 
       }
   }

   private void Brake()
   {
       var brakeValue = input.actions.FindAction("Brake").ReadValue<float>();
       if (brakeValue > 0f && currentSpeed > 0f && IsGrounded())
       {
           //Play tire smoke and tire trails
           tireSmokes.ForEach(tireSmoke => tireSmoke.Play());
           tireTrails.ForEach(tireTrail => tireTrail.emitting = true);
         
         
           currentBreakingForce = breakingForce;
          
           var backLeftSidewaysFriction = wheelColliders.ElementAt(2).sidewaysFriction;
           backLeftSidewaysFriction.stiffness = desiredStiffness;
           wheelColliders.ElementAt(2).sidewaysFriction = backLeftSidewaysFriction;


           var backRightSidewaysFriction = wheelColliders.ElementAt(3).sidewaysFriction;
           backRightSidewaysFriction.stiffness = desiredStiffness;
           wheelColliders.ElementAt(3).sidewaysFriction = backRightSidewaysFriction;
       }
       else
       {
              //Stop tire smoke and tire trails
          tireSmokes.ForEach(tireSmoke => tireSmoke.Stop());
          tireTrails.ForEach(tireTrail => tireTrail.emitting = false);
          
           currentBreakingForce = 0f;
           wheelColliders.ElementAt(2).sidewaysFriction = originalBackLeftSidewaysFriction;
           wheelColliders.ElementAt(3).sidewaysFriction = originalBackRightSidewaysFriction;
       }
       wheelColliders.ElementAt(0).brakeTorque = currentBreakingForce;
       wheelColliders.ElementAt(1).brakeTorque = currentBreakingForce;
      
   }

   void UpdateWheel(WheelCollider col, Transform trans)
   {
       Vector3 position;
       Quaternion rotation;
       col.GetWorldPose(out position, out rotation);
       
       trans.position = position;
       trans.rotation = rotation;
   }


   public void OnMoveInput(InputAction.CallbackContext context)
   {
       drive = context.ReadValue<float>();
   }
   
   public void ResetPositionButton()
   {
       var resetValue = input.actions.FindAction("Reset").ReadValue<float>();
       if (resetValue > 0)
       {
           rb.position = gameManager.spawnPoints[playerIndex].transform.position;
           rb.rotation = gameManager.spawnPoints[playerIndex].transform.rotation;
           if (carStats.checkpoint)
           {
               var transform1 = rb.transform;
               transform1.position = carStats.checkPoint.transform.position;
               transform1.rotation = carStats.checkPoint.transform.rotation;
               rb.velocity = Vector3.zero;
           }
       }
   }
   
   public void ResetPosition()
   {
       {
           rb.position = gameManager.spawnPoints[playerIndex].transform.position;
           rb.rotation = gameManager.spawnPoints[playerIndex].transform.rotation;
           if (carStats.checkpoint)
           {
               var transform1 = rb.transform;
               transform1.position = carStats.checkPoint.transform.position;
               transform1.rotation = carStats.checkPoint.transform.rotation;
               rb.velocity = Vector3.zero;
           }
       }
   }
  
    bool IsGrounded()
    {
           foreach (Transform groundChecker in groundCheckers)
           {
               if (Physics.Raycast(groundChecker.position, Vector3.down, 0.1f))
               {
                   return true;
               }
           }
           return false;
    }
 
}