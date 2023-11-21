using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public static Test instance;
    [SerializeField] private GeneratorConfig HeroConfig;
    [SerializeField] private GeneratorConfig TrainerConfig;

    void Start()
    {
        Hero hero = new ("Andrey", "Panchenko", 30, 30, HeroConfig);
        Hero hero1 = new("Andrey1", "Panchenko1", 30, 50, HeroConfig);

        Debug.Log($"Hero Name  {hero.FirstName} {hero.SecondName}");
        Debug.Log($"Hero Age {hero.Age}");

        Debug.Log($"Hero Agility Value {hero.Info.Agility.Value}");
        Debug.Log($"Hero Agility MaxValue {hero.Info.Agility.MaxValue}");

        Debug.Log($"Hero Intellect Value {hero.Info.Intellect.Value}");
        Debug.Log($"Hero Intellect MaxValue {hero.Info.Intellect.MaxValue}");

        Debug.Log($"Hero Stamina Value {hero.Info.Stamina.Value}");
        Debug.Log($"Hero Stamina MaxValue {hero.Info.Stamina.MaxValue}");

        Debug.Log($"Hero Magic Value {hero.Info.Magic.Value}");
        Debug.Log($"Hero Magic MaxValue {hero.Info.Magic.MaxValue}");

        Debug.Log($"Hero Charisma Value {hero.Info.Charisma.Value}");
        Debug.Log($"Hero Charisma MaxValue {hero.Info.Charisma.MaxValue}");

        Debug.Log($"Hero Luck Value {hero.Info.Luck.Value}");
        Debug.Log($"Hero Luck MaxValue {hero.Info.Luck.MaxValue}");

        Debug.Log($"Hero Speed Value {hero.Info.Speed.Value}");
        Debug.Log($"Hero Speed MaxValue {hero.Info.Speed.MaxValue}");

        Debug.Log($"Hero Protection Value {hero.Info.Protection.Value}");
        Debug.Log($"Hero Protection MaxValue {hero.Info.Protection.MaxValue}");

        Debug.Log($"Hero MagicalProtection Value {hero.Info.MagicalProtection.Value}");
        Debug.Log($"Hero MagicalProtection MaxValue {hero.Info.MagicalProtection.MaxValue}");

        Debug.Log($"Hero Intuition Value {hero.Info.Intuition.Value}");
        Debug.Log($"Hero Intuition MaxValue{hero.Info.Intuition.MaxValue}");

        Debug.Log($"Hero Adaptation Value {hero.Info.Adaptation.Value}");
        Debug.Log($"Hero Adaptation MaxValue {hero.Info.Adaptation.MaxValue}");

        Debug.Log($"Hero Inspiration Value {hero.Info.Inspiration.Value}");
        Debug.Log($"Hero Inspiration MaxValue {hero.Info.Inspiration.MaxValue}");

        Debug.Log($"Hero Composure Value {hero.Info.Composure.Value}");
        Debug.Log($"Hero Composure MaxValue {hero.Info.Composure.MaxValue}");

        Debug.Log($"Hero Teamwork Value {hero.Info.Teamwork.Value}");
        Debug.Log($"Hero Teamwork MaxValue {hero.Info.Teamwork.MaxValue}");

        Debug.Log($"Hero Reputation Level {hero.Info.Reputation.Level}");
        Debug.Log($"Hero Reputation Progress {hero.Info.Reputation.Progress}");

        Debug.LogError($"Hero Reputation Progress {hero.Info.AverageValueCharacteristic}");
        Debug.LogError($"Hero Reputation Progress {hero1.Info.AverageValueCharacteristic}");

        Trainer trainer = new ("Андрей", "Панченко", 30, "", TrainerConfig);

        Debug.Log($"Trainer Name  {trainer.FirstName} {trainer.SecondName}");
        Debug.Log($"Trainer Description {trainer.Description}");
        Debug.Log($"Trainer Age {trainer.Age}");

        foreach (var characteristic in trainer.Info.CharacteristicsMap) 
        {
            var Characteristic = characteristic.Value;
            Debug.Log($"Trainer Characteristics Name {Characteristic.Name}");
            Debug.Log($"Trainer Characteristics Description {Characteristic.Description}");
            Debug.Log($"Trainer Characteristics CharacteristicType {Characteristic.CharacteristicType}");
            Debug.Log($"Trainer Characteristics Value {Characteristic.Value}");
        }

        ImprovementRoom improvementRoom = new("1", "2", new CharacteristicType[] { CharacteristicType.Protection, CharacteristicType.Magic }, new List<Hero> { hero, hero1 });
        improvementRoom.TrySetTrainer(trainer);

        GameTimer gameTimer = new();
        gameTimer.SetAccelerationRatio(5);
        StartCoroutine(TimerStart(gameTimer));
        StartCoroutine(Timer(improvementRoom, hero));
        StartCoroutine(DelayEnableAutoTraining(improvementRoom));
    }

    public IEnumerator Timer(ImprovementRoom improvementRoom, Hero hero) 
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            improvementRoom.StateMachine.Update();
            improvementRoom.StateMachine.Handle();

        }
    }

    public IEnumerator TimerStart(IUpdatable gameTime)
    {
        while (true)
        {
            yield return null;
            gameTime.Update(Time.deltaTime);
        }
    }

    public IEnumerator DelayEnableAutoTraining(ImprovementRoom improvementRoom)
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            improvementRoom.Data.EnableAutoTraining();
        }
    }

}
