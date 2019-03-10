using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public static UIController instance;

    #region Variables

    [Header("Player info")]
    [SerializeField] Text currencyText;
    [SerializeField] Text scoreText;
    [SerializeField] public Text healthText;

    [Header("Wave info")]
    [SerializeField] public Text waveTimerText;
    [SerializeField] public Text waveCounterText;

    [Header("Tower info")]
    [SerializeField] Text towerNameText;
    [SerializeField] Text towerHealthText;
    [SerializeField] Text towerDamageText;
    [SerializeField] Text towerDamageOverTimeText;
    [SerializeField] Text towerAttackTypeText;
    [SerializeField] Text towerLevelText;
    [SerializeField] Image towerSprite;
    [SerializeField] Tower arrowTower1;
    [SerializeField] Tower incendiaryTower1;
    [SerializeField] Tower frostTower1;
    [SerializeField] Tower laserTower1;

    [Header("Tower build info")]
    [SerializeField] Text towerBuildNameText;
    [SerializeField] Text towerBuildHealthText;
    [SerializeField] Text towerBuildDamageText;
    [SerializeField] Text towerBuildAttackTypeText;
    [SerializeField] Text towerBuildLevelText;
    [SerializeField] Image towerBuildSprite;

    [Header("Enemy info")]
    [SerializeField] Text enemyNameText;
    [SerializeField] Text enemyHealthText;
    [SerializeField] Text enemyDamageText;
    [SerializeField] Image enemySprite;

    [Header("UI Panels")]
    [SerializeField] GameObject standardTabPanel;
    [SerializeField] GameObject buildTabPanel;
    [SerializeField] public GameObject towerTabPanel;
    [SerializeField] public GameObject towerStatBuildPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] public GameObject enemyInfoPanel;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject winScreenPanel;
    [SerializeField] GameObject optionsPanel;

    [Header("Buttons")]
    [SerializeField] Button buildTower1Button;
    [SerializeField] Button buildTower2Button;
    [SerializeField] Button buildTower3Button;
    [SerializeField] Button buildTower4Button;
    [SerializeField] Button upgradeTowerButton;
    [SerializeField] Button easyButton;
    [SerializeField] Button mediumButton;
    [SerializeField] Button hardButton;

    [Header("Misc")]
    [SerializeField] GameObject audioController;
    [SerializeField] GameObject audioOffImage;
    [SerializeField] Text difficultyText;

    #endregion

    void Awake() {
        Application.targetFrameRate = 300;
        instance = this;
        DontDestroyOnLoad(instance);
        currencyText.text = "" + PlayerController.instance.currency;
        scoreText.text = "" + PlayerController.instance.score;
        healthText.text = "" + PlayerController.instance.health;
        waveTimerText.text = "Next wave begins in: 30:00:00";
        waveCounterText.text = "Wave: " + 0;
        buildTower1Button.interactable = false;
        buildTower2Button.interactable = false;
        buildTower3Button.interactable = false;
        buildTower4Button.interactable = false;
        upgradeTowerButton.interactable = false;
        difficultyText.text = "Difficulty: Easy";
        difficultyText.color = Color.green;
    }

    #region UItabs

    public void ActivateMenuTab() {
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
        optionsPanel.SetActive(false);
    }

    public void ActivateBuildTab() {
        standardTabPanel.SetActive(false);
        buildTabPanel.SetActive(true);
        ActivatePossibleBuyButtons();
    }

    public void ActivateTowerTab() {
        standardTabPanel.SetActive(false);
        towerTabPanel.SetActive(true);
        ActivateUpgradeButton();
    }

    public void ActivatePossibleBuyButtons() {
        if(PlayerController.instance.currency >= arrowTower1.price) {
            buildTower1Button.interactable = true;
        }
        if (PlayerController.instance.currency >= incendiaryTower1.price) {
            buildTower2Button.interactable = true;
        }
        if (PlayerController.instance.currency >= frostTower1.price)
        {
            buildTower3Button.interactable = true;
        }
        if (PlayerController.instance.currency >= laserTower1.price) {
            buildTower4Button.interactable = true;
        }
        if(PlayerController.instance.currency < arrowTower1.price) {
            buildTower1Button.interactable = false;
            buildTower2Button.interactable = false;
            buildTower3Button.interactable = false;
            buildTower4Button.interactable = false;

        }
    }
    
    public void ActivateUpgradeButton() {
        if(PlayerController.instance.target != null) { 
        if(PlayerController.instance.currency >= PlayerController.instance.target.GetComponent<TowerController>().currentTower.price) {
            upgradeTowerButton.interactable = true;
        } else {
            upgradeTowerButton.interactable = false;
        }
      }
    }

    public void ActivateOptionsPanel() {
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ReturnToStandardTab() {
        standardTabPanel.SetActive(true);
        if (buildTabPanel.activeInHierarchy) buildTabPanel.SetActive(false);
        else if (towerTabPanel.activeInHierarchy) towerTabPanel.SetActive(false);
    }

    #endregion

    #region Display Functions

    public void DisplayTowerInfo(Tower tower) {
        enemyInfoPanel.SetActive(false);
        towerStatBuildPanel.SetActive(false);
        standardTabPanel.SetActive(false);
        buildTabPanel.SetActive(false);


        towerTabPanel.SetActive(true);
        ActivateUpgradeButton();
        towerNameText.text = tower.name;
        towerHealthText.text = tower.health.ToString();
        towerDamageText.text = tower.projectile.damage.ToString();
        towerDamageOverTimeText.text = "";
        if (tower.damageOverTime > 0) {
            towerDamageOverTimeText.text = tower.damageOverTime + " Damage Over Time";            
        }

        towerAttackTypeText.text = tower.type;
        towerSprite.sprite = tower.icon;
        towerLevelText.text = "Level: " + tower.level;
    }

    public void DisplayTowerBuildInfo(Tower tower) {
        towerStatBuildPanel.SetActive(true);
        towerBuildNameText.text = tower.name;
        towerBuildHealthText.text = tower.health.ToString();
        towerBuildDamageText.text = tower.damage.ToString();
        towerBuildAttackTypeText.text = tower.type;
        towerBuildSprite.sprite = tower.icon;
        towerBuildLevelText.text = "Level: " + tower.level;
    }

    public void DisplayEnemyInfo(EnemyController enemyTarget) {
        enemyInfoPanel.SetActive(true);
        enemyNameText.text = enemyTarget.enemy.name;
        enemyHealthText.text = enemyTarget.health.ToString();
        enemyDamageText.text = enemyTarget.enemy.damage.ToString();
        enemySprite.sprite = enemyTarget.enemy.icon;
    }

    public void DisplayGameOverPanel() {
        gameoverPanel.SetActive(true);
    }

    public void DisplayWinScreen() {
        winScreenPanel.SetActive(true);
    }

#endregion

    #region Tower Functions
    public void UpgradeTowerButton() {
        PlayerController.instance.target.GetComponent<TowerController>().UpgradeTower();
    }

    public void BuildTower(int towerIndex) {
        BuildController.instance.BuildTower(towerIndex);
    }

    public void SellTower() {
        UpdateCurrencyText(PlayerController.instance.target.GetComponent<TowerController>().currentTower.sellValue);
        Destroy(PlayerController.instance.target);
        PlayerController.instance.target = null;
        ReturnToStandardTab();
    }

    #endregion

    #region Value Update Methods
    public void UpdateCurrencyText(int value) {
        PlayerController.instance.currency += value;
        currencyText.text = "" + PlayerController.instance.currency;
    }

    public void UpdateScoreText(int value) {
        PlayerController.instance.score += value;
        scoreText.text = "" + PlayerController.instance.score;
    }

    public void UpdateHealthText(int value) {
        PlayerController.instance.health += value;
        healthText.text = "" + PlayerController.instance.health;
    }
    #endregion

    #region Set Difficulty

    public void SetDifficultyEasy() {
        PlayerController.instance.difficulty = 1;
        difficultyText.text = "Difficulty: Easy";
        difficultyText.color = Color.green;
        Debug.Log("Difficulty is now set to: EASY!");
    }

    public void SetDifficultyMedium() {
        PlayerController.instance.difficulty = 2;
        difficultyText.text = "Difficulty: Medium";
        difficultyText.color = Color.yellow;
        Debug.Log("Difficulty is now set to: MEDIUM!");
    }

    public void SetDifficultyHard() {
        PlayerController.instance.difficulty = 3;
        difficultyText.text = "Difficulty: Hard";
        difficultyText.color = Color.red;
        Debug.Log("Difficulty is now set to: HARD!");
    }

    #endregion

    public void ToggleAudio() {
        audioController.SetActive(!audioController.activeInHierarchy);
        audioOffImage.SetActive(!audioOffImage.activeInHierarchy);
    }

    public void ExitGame() {
        Application.Quit();
    }

}
