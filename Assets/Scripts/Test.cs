using System.Collections;
using System.Linq;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GeneratorConfig HeroConfig;
    [SerializeField] private GeneratorConfig TrainerConfig;

    void Start()
    {
        Guild guild = new Guild("Famaly");
        guild.RecruitHero(HeroConfig);
        guild.RecruitTrainer(TrainerConfig);

        var heroes = guild.Data.HeroesMap;
        var trainers = guild.Data.TrainersMap;

        foreach (var heroKV in heroes)
        {
            Hero hero = heroKV.Value;

            Debug.Log($"Hero Name  {hero.FullName}");
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
        }

        foreach (var trainerMap in trainers) 
        {
            var trainer = trainerMap.Value;
            Debug.Log($"Trainer Name {trainer.FullName}");
            Debug.Log($"Trainer Description {trainer.Description}");

            foreach (var characteristicMap in trainer.Info.CharacteristicsMap)
            {
                var characteristic = characteristicMap.Value;
                Debug.Log($"Trainer Characteristics Name {characteristic.Name}");
                Debug.Log($"Trainer Characteristics CharacteristicType {characteristic.CharacteristicType}");
                Debug.Log($"Trainer Characteristics Value {characteristic.Value}");
            }   
        }

        /*ImprovementRoom improvementRoom = new("1", "2", new CharacteristicType[] { CharacteristicType.Protection, CharacteristicType.Magic }, heroes);
        improvementRoom.TrySetTrainer(trainer);

        GameTimer gameTimer = new();
        gameTimer.SetAccelerationRatio(5);
        StartCoroutine(TimerStart(gameTimer));
        StartCoroutine(Timer(improvementRoom));
        StartCoroutine(DelayEnableAutoTraining(improvementRoom));*/
    }

    public IEnumerator Timer(ImprovementRoom improvementRoom) 
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
