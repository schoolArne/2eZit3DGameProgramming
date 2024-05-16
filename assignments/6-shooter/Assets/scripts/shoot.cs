using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject bulletPrefab;
    public Camera mainCamera; // Reference to the main camera
    public int finalBulletSpeed = 800;
    public float shootRate = 0.1f;
    public AudioClip shootSound;
    private float timer = 0f;

    void Update () {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= shootRate)
        {
            ShootProjectile();
            timer = 0f;
        }
    }

    void ShootProjectile()
    {
        Vector3 spaceshipForward = transform.forward;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 shootingDirection;

        if (Physics.Raycast(ray, out hit))
        {
            shootingDirection = hit.point - transform.position;
        }
        else
        {
            shootingDirection = ray.direction;
        }
        float angle = Vector3.Angle(spaceshipForward, shootingDirection);
        Vector3 cross = Vector3.Cross(spaceshipForward, shootingDirection);
        if (cross.y < 0)
        {
            angle = -angle;
        }
        Vector3 finalShootingDirection = Quaternion.Euler(0, angle, 0) * spaceshipForward;
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(finalShootingDirection));
        newBullet.transform.Rotate(Vector3.right, 90f);
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = finalShootingDirection.normalized * finalBulletSpeed;
        bulletRigidbody.useGravity = false;
        PlayShootSound(shootSound);
    }

    private void PlayShootSound(AudioClip audioClipToPLay)
    {
        GameObject soundObject = new GameObject("TemporarySoundObject");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = audioClipToPLay;
        audioSource.volume = 0.08f;
        soundObject.transform.position = transform.position;
        audioSource.Play();
    }
}