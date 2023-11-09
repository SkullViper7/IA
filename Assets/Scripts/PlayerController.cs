using UnityEngine;

/// <summary>
/// Ecoute les entr�es utilisateurs et d�place le personnage du joueur
/// en fonction.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Composant Unity permettant de d�placer facilement un objet dans
    /// un niveau.
    /// </summary>
    CharacterController _characterController;

    /// <summary>
    /// Vitesse de d�placement (en m/s) du personnage.
    /// </summary>
    [SerializeField]
    float _moveSpeed;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 inputDirection = new Vector3()
        {
            x = Input.GetAxis("Horizontal"),
            y = 0,
            z = Input.GetAxis("Vertical")
        };

        Vector3 velocity = inputDirection * _moveSpeed * Time.deltaTime;

        _characterController.Move(velocity);
    }
}
