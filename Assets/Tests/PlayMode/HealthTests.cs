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
}
