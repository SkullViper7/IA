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
    AudioSource _audioSource;
    public AudioClip _audioClip;
    public bool isFired;

    bool isAudioPlaying;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
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

        if (Input.GetAxis("Fire1") != 0 && !isAudioPlaying)
        {
            _audioSource.PlayOneShot(_audioClip);
            isFired = true;
            isAudioPlaying = true;
            Invoke("ResetAudioStatus", _audioClip.length);
        }
    }

    void ResetAudioStatus()
    {
        isAudioPlaying = false;
    }
}
