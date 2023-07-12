using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI pHealth, eHealth;
    [SerializeField] private GameObject eHealthContainer, actionContainer, targetContainer;
    [SerializeField] private Button actionButton, targetButton;
    private GameManager gameManager;
    private int worldScene = 1;
    public int killCount = 0;

    private Queue<CharacterInfo> turnOrder = new Queue<CharacterInfo>();
    private bool awaitCommand = false;
    private int comboLength = 0;

    private List<CharacterAction> actions = new List<CharacterAction>();
    private CharacterInfo target;
    private PlayerInfo player;

    private void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void Start() {
        player = gameManager.player;
        var characters = new List<CharacterInfo> { player }.Concat(gameManager.enemies);
        var sortedCharacters = characters.OrderByDescending(c => c.speed);
        turnOrder = new Queue<CharacterInfo>(sortedCharacters);

        for (int i = 0; i < gameManager.enemies.Count; i++)
        {
            EnemyInfo enemy = gameManager.enemies[i];

            TextMeshProUGUI enemyHealthText = Instantiate(eHealth, eHealthContainer.transform);

            enemyHealthText.rectTransform.anchoredPosition = new Vector3(0, -i * 100);

            Button selectEnemy = Instantiate(targetButton, targetContainer.transform);

            selectEnemy.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = enemy.characterName;

            selectEnemy.onClick.AddListener(() => PickTarget(enemy));
        }

        for (int i = 0; i < player.CountActions(); i++)
        {
            CharacterAction currentAction = player.GetAction(i);

            Button selectAction = Instantiate(actionButton, actionContainer.transform);

            selectAction.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentAction.Name;

            selectAction.onClick.AddListener(() => PickAction(currentAction));
        }

        targetContainer.SetActive(false);
        actionContainer.SetActive(false);

        UpdateActions();
        UpdateHealth();

        StartCoroutine(BattleSequence());
    }

    private void PickTarget(CharacterInfo target)
    {
        this.target = target;
        awaitCommand = false;
    }

    private void PickAction(CharacterAction action)
    {
        if (action.Cost <= player.combo - comboLength) 
        {
            actions.Add(action);
            comboLength += action.Cost;
        }

        if (comboLength < player.combo) UpdateActions();

        else awaitCommand = false;
    }

    private void UpdateHealth()
    {
        pHealth.text = player.characterName + "'s Health: " + player.health;

        for (int i = 0; i < gameManager.enemies.Count; i++)
        {
            eHealthContainer.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = gameManager.enemies[i].characterName + "'s Health: " + gameManager.enemies[i].health;
        }
    }

    private void UpdateActions()
    {
        Button[] buttonList = actionContainer.transform.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttonList.Length; i++) 
        {
            buttonList[i].interactable = player.GetAction(i).Cost <= player.combo - comboLength;
        }
    }

    private IEnumerator BattleSequence()
    {
        while (true){
            if (turnOrder.Count > 0)
            {
                CharacterInfo activeCharacter = turnOrder.Peek();

                if (activeCharacter == player){
                    awaitCommand = true;
                    actionContainer.SetActive(true);
                    while (awaitCommand)
                    {
                        
                        yield return null;
                    }
                    awaitCommand = true;
                    actionContainer.SetActive(false);
                    targetContainer.SetActive(true);
                    while (awaitCommand)
                    {


                        yield return null;
                    }

                    targetContainer.SetActive(false);

                    foreach (CharacterAction a in actions)
                    {
                        Debug.Log($"{activeCharacter.characterName} used {a.Name} at {target.characterName}");
                        activeCharacter.DoAction(a, target);
                    }

                    

                    if (target.health <= 0)
                    {
                        killCount++;

                        if (killCount >= gameManager.enemies.Count) EndBattle();

                        int targetIndex = gameManager.enemies.IndexOf(target as EnemyInfo);
                        
                        targetContainer.transform.GetChild(targetIndex).GetComponent<Button>().interactable = false;

                        var newTurnOrder = new Queue<CharacterInfo>(turnOrder.Where(x => x != target));
                        turnOrder = newTurnOrder;
                        
                    }

                } else {
                    actions.Add(activeCharacter.GetAction(0));

                    Debug.Log($"{activeCharacter.characterName} used {actions[0].Name} at {player.characterName}"); // Display the action's name
                    activeCharacter.DoAction(actions[0], player);

                    if (player.health <= 0) EndBattle();
                }

                NextTurn(activeCharacter);

                yield return new WaitForSeconds(1);

            }
            
            
        }
        
    }

    private void NextTurn(CharacterInfo activeCharacter)
    {
        UpdateHealth();
        UpdateActions();

        turnOrder.Dequeue();
        turnOrder.Enqueue(activeCharacter);

        actions.Clear();
        comboLength = 0;
    }

    public void EndBattle()
    {
        Debug.Log("End Battle");

        StopAllCoroutines();

        gameManager.enemies.Clear();

        SceneManager.LoadScene(worldScene);
    }
}