using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTests
{

        GameObject prefab;
        GameObject instance;
        HealthController healthController;
        int startingHealth;

    [SetUp]
    public void Setup()

    {
        prefab = Resources.Load<GameObject>("HealthCube");
        Assert.IsNotNull(prefab, "HealthCube prefab not found in Resources");
        instance = Object.Instantiate(prefab);
         // Prefab Instantiation -- happens before each test.
        healthController= instance.GetComponent<HealthController>();
        startingHealth = healthController.GetCurrentHealth();
    }

    [UnityTest]
    public IEnumerator Regen_HealsAfterDelay()
    {
        int damageToBeDone = 53;
        healthController.TakeDamage(damageToBeDone);
        yield return new WaitForSeconds(healthController.RegenDelay + 2.5f); // Eg. RegenDelay is 3f then we wait for 5.5f to check if healing is done.
        Debug.Log(healthController.GetCurrentHealth());
        Assert.That(healthController.GetCurrentHealth(), Is.GreaterThan(startingHealth-damageToBeDone));
    }

    [UnityTest]
    public IEnumerator Regen_DoesNotHealBeforeDelayElapses()
    {
        // HealthController healthController = new GameObject().AddComponent<HealthController>();Old Approach of Instantiating without a prefab
        int damageToBeDone = 51;    
        healthController.TakeDamage(damageToBeDone);
        yield return new WaitForSeconds(healthController.RegenDelay - 1f); //Eg. RegenDealy is 3 seconds. so using less than 3 to test this scenario.
        Assert.AreEqual(startingHealth-damageToBeDone,healthController.GetCurrentHealth());
    }

    [UnityTest]
    public IEnumerator Regen_LastDamageTimeDoesNotChangeWhenZeroDamage(){
        float lastDamageTimeBeforeZeroDamage = healthController.lastDamageTime;
        healthController.TakeDamage(0);
        yield return new WaitForSeconds(healthController.RegenDelay + 2.5f);
        float lastDamageTimeAfterZeroDamage = healthController.lastDamageTime;
        Assert.AreEqual(lastDamageTimeBeforeZeroDamage,lastDamageTimeAfterZeroDamage);
    }

    [TearDown]
    public void Teardown()
    {
        // Clean up: Destroy the object  after every test
        Object.Destroy(instance);
    }
}
