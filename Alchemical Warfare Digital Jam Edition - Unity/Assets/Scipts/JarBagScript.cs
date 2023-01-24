/*
 * Data structure that holds jar prefabs based on an input set of int indexes
 * Should be attached to the player object
 * In the game manager script, instantiate it by calling its constructor with an array of int jar indexes
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarBagScript : MonoBehaviour
{
    public float throwCooldown = 1.0f;
    private float cooldownTime = 0f;
    public float baseJarVelocityMultiplier = 1.0f;

    public KeyCode rightJarThrowKey;
    public KeyCode leftJarThrowKey;

    public GameObject[] jarPrefabs;

    private List<GameObject> jarPool;
    private GameObject leftJar;
    private GameObject rightJar;

    public KeyCode playerJumpKey = KeyCode.W;
    public KeyCode playerLeftKey = KeyCode.A;
    public KeyCode playerRightKey = KeyCode.D;

    private Vector3 lastFacingDirection = Vector3.right;

    JarBagScript(int[] j)
    {
        for(int x = 0; x < j.Length; x++)
        {
            jarPool.Add(Instantiate(jarPrefabs[x]));
            jarPool[x].SetActive(false);
        }
    }

    private void Update()
    {
        if (cooldownTime > 0f)
        {
            cooldownTime -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(rightJarThrowKey))
        {
            ThrowJar(rightJar);
            rightJar = GenerateJar();
        }
        else if (Input.GetKeyDown(leftJarThrowKey))
        {
            ThrowJar(leftJar);
            leftJar = GenerateJar();
        }


        if (Input.GetKeyDown(playerLeftKey))
        {
            lastFacingDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(playerRightKey))
        {
            lastFacingDirection = Vector3.right;
        }
    }

    // Generates a jar from the pool, returns null if the pool is empty, removes the jar from the pool once generated
    public GameObject GenerateJar()
    {
        if(jarPool.Count == 0)
        {
            Debug.Log("Jar pool empty");
            return null;
        }

        int x = Random.Range(0, jarPool.Count);
        GameObject jar = jarPool[x];
        jarPool.Remove(jar);

        return jar;
    }

    private void ThrowJar(GameObject jar)
    {
        Vector3 jarInitialVelocity = lastFacingDirection;

        if (Input.GetKeyDown(playerLeftKey))
        {
            jarInitialVelocity = Vector3.left;
        }
        else if (Input.GetKeyDown(playerRightKey))
        {
            jarInitialVelocity = Vector3.right;
        }

        if (Input.GetKeyDown(playerJumpKey))
        {
            jarInitialVelocity += Vector3.up;
        }

        jarInitialVelocity.Normalize();
        jarInitialVelocity *= baseJarVelocityMultiplier;

        jar.GetComponent<JarScript>().SetVelocity(jarInitialVelocity);
    }
}
