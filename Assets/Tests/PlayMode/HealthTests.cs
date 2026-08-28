using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTests
{

    [UnityTest]
    public IEnumerator Regen_HealsAfterDelay()
    {
        HealthController healthController= new GameObject().AddComponent<HealthController>();
        healthController.TakeDamage(55);
        yield return new WaitForSeconds(5.5f);
        Debug.Log(healthController.getCurrentHealth());
        Assert.That(healthController.getCurrentHealth(), Is.GreaterThan(45));
    }

    [UnityTest]
    public IEnumerator Regen_DoesNotHealBeforeDelayElapses()
    {
        HealthController healthController = new GameObject().AddComponent<HealthController>();
        healthController.TakeDamage(55);
        yield return new WaitForSeconds(1f); //RegenDealy is 3 seconds. so using less than 3 to test this scenario.
        Debug.Log(healthController.getCurrentHealth());
        Assert.AreEqual(45,healthController.getCurrentHealth());
    }

    [UnityTest]
    public IEnumerator Regen_LastDamageTimeDoesNotChangeWhenZeroDamage(){
        HealthController healthController = new GameObject().AddComponent<HealthController>();
        float lastDamageTimeBeforeZeroDamage = healthController.lastDamageTime;
        healthController.TakeDamage(0);
        yield return new WaitForSeconds(5.5f);
        float lastDamageTimeAfterZeroDamage = healthController.lastDamageTime;
        Assert.AreEqual(lastDamageTimeBeforeZeroDamage,lastDamageTimeAfterZeroDamage);
    }
}
