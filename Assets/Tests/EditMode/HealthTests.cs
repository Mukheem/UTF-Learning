using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewHealth_StartsAtMaxHealth()
    {
       Health health = new Health(100);
       Assert.AreEqual(100, health.CurrentHealth);
    }

    [Test]
    public void TakeDamage_ReducesCurrentHealth()
    {
       Health health = new Health(100);
       health.TakeDamage(30);
       Assert.AreEqual(70, health.CurrentHealth);
    }

    [Test]
    public void TakeDamage_CannotGoBelowZero(){
        Health health = new Health(100);
        health.TakeDamage(150);
        Assert.AreEqual(0, health.CurrentHealth);
    }

    [Test]
    public void TakeDamage_NegativeAmount_IsIgnored(){
        Health health = new Health(100);
        health.TakeDamage(-10);
        Assert.AreEqual(100, health.CurrentHealth);
    }

    [Test]
    public void Heal_IncreasesCurrentHealth(){
        Health health = new Health(100);
        health.TakeDamage(50);
          health.Heal(20);
        Assert.AreEqual(70, health.CurrentHealth);
    }

    [Test]
    public void Heal_WhenDead_DoesNothing(){
        Health health = new Health(100);
        health.TakeDamage(200);
          health.Heal(50);
        Assert.AreEqual(0, health.CurrentHealth);
    }

    [Test]
    public void Heal_CannotExceedMaxHealth(){
        Health health = new Health(100);
        health.TakeDamage(20);
          health.Heal(30);
        Assert.AreEqual(100, health.CurrentHealth);
    }
    
}
