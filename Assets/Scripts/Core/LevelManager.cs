using System;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using LogiSpark.Models;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public ActiveLevel activeLevel;
    public Transform inventory;

    public TMPro.TextMeshProUGUI scoreDisplay;

    public GameObject gridElementPrefab; // Prefab pour les éléments de la grille

    public Button pauseButton;
    public Button restartButton;
    public Button leaveButton;
    public Button launchButton;

    public GameObject modalePause;

    public GameObject modaleVictory;
    public GameObject modaleDefeat;

    public Button nextLevelButton;

    public Button homeButton;

    public GameObject winStar1;
    public GameObject winStar2;
    public GameObject winStar3;

    public Button playAgain;
    public Button HomeButton2;

    public List<UIGate> gates;
    public CircuitObject source;
    public CircuitObject destination;

    public GameObject[] modalsTutorial;
    public Button[] modalButtons;
    public GameObject warningModal;
    public Button warningButton;

    void Start()
    {
        Level level = GameManager.instance.getCurrentLevel();
        activeLevel = new ActiveLevel(level);
        activeLevel.InstanciateGates();
        
        // Ajouter les portes NOT si disponibles
        if(activeLevel.GetLevel().GetNot() > 0)
        {
            AddGateToInventory("gate_not", activeLevel.GetLevel().GetNot());
        }
        
        if(activeLevel.GetLevel().GetAnd() > 0)
        {
            AddGateToInventory("gate_and", activeLevel.GetLevel().GetAnd());
        }
        
        if(activeLevel.GetLevel().GetOr() > 0)
        {
            AddGateToInventory("gate_or", activeLevel.GetLevel().GetOr());
        }

        if(activeLevel.GetLevel().GetNand() > 0)
        {
            AddGateToInventory("gate_nand", activeLevel.GetLevel().GetNand());
        }

        if(activeLevel.GetLevel().GetXor() > 0)
        {
            AddGateToInventory("gate_xor", activeLevel.GetLevel().GetXor());
        }
        
        if(activeLevel.GetLevel().GetWire() > 0)
        {
            AddGateToInventory("wire_gate", activeLevel.GetLevel().GetWire());
        }
        
        modalePause.SetActive(false);
        modaleVictory.SetActive(false);
        modaleDefeat.SetActive(false);
        warningModal.SetActive(false);

        foreach(var modal in modalsTutorial)
        {
            modal.SetActive(false);
        }

        if (modalsTutorial != null && modalButtons != null && modalsTutorial.Length > 0 && modalButtons.Length > 0){
            
            // Activation de la première modale de tutoriel dans tous les cas
            modalsTutorial[0].SetActive(true);
            pauseButton.interactable = false;
            launchButton.interactable = false;

            // Gestion des modales de tutoriel suivantes
            for (int i = 0; i < modalButtons.Length; i++)
            {
                if (modalButtons[i] == modalButtons[modalButtons.Length - 1])
                {
                    modalButtons[i].onClick.AddListener(() =>
                    {
                        pauseButton.interactable = true;
                        launchButton.interactable = true;
                        modalsTutorial[i].SetActive(false);
                        activeLevel.StartScore();
                    });
                    break;
                }
                modalButtons[i].onClick.AddListener(() =>
                {
                    for (int i = 0; i < modalsTutorial.Length; i++)
                    {
                        if (modalsTutorial[i].activeSelf)
                        {
                            modalsTutorial[i].SetActive(false);

                            int nextIndex = i + 1;
                            if (nextIndex < modalsTutorial.Length)
                            {
                                modalsTutorial[nextIndex].SetActive(true);
                            }
                            break;
                        }
                    }
                });
            }
        }
        else
        {
            activeLevel.StartScore();
        }

        pauseButton.onClick.AddListener(PauseGame);
        restartButton.onClick.AddListener(ResumeGame);
        leaveButton.onClick.AddListener(LeaveGame);
        launchButton.onClick.AddListener(LaunchVerif);
        nextLevelButton.onClick.AddListener(nextLevel);
        homeButton.onClick.AddListener(LeaveGame);
        HomeButton2.onClick.AddListener(LeaveGame);
        playAgain.onClick.AddListener(ReloadGame);
    }

    void Update()
    {
        // Mettre à jour l'affichage du score
        if (scoreDisplay != null)
        {
            scoreDisplay.text = activeLevel.GetInGameScore().ToString();
        }
        else
        {
            Debug.LogError("Score display not found.");
        }
    }

    // Fonction pour ajouter un élément de porte logique à l'inventaire
    private void AddGateToInventory(string gateType, int quantity)
    {
        GameObject gridElement = Instantiate(gridElementPrefab, inventory);
        
        // Mettre à jour l'image
        Transform gateTransform = gridElement.transform.Find("gate");
        if (gateTransform != null)
        {
            // Charger l'image depuis les ressources
            Image image = gateTransform.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = Resources.Load<Sprite>("Graphics/Gates/" + gateType);
            }
            else
            {
                Debug.LogError("Image not found on gate object.");
            }
        }
        else
        {
            Debug.LogError("Gate image not found in prefab.");
        }
        
        // Mettre à jour le texte de quantité
        TMPro.TextMeshProUGUI quantityText = gridElement.transform.Find("quantity").GetComponent<TMPro.TextMeshProUGUI>();
        if (quantityText != null)
        {
            quantityText.text = quantity.ToString();
        }
        else
        {
            Debug.LogError("Quantity text not found in prefab.");
        }

        // Créer un composant bouton et l'ajouter au game object gate
        Button buttonGateTransform = gateTransform.AddComponent<Button>();

        // Lier le script ButtonInventoryGate au game object gate
        ButtonInventoryGate gateController = gateTransform.AddComponent<ButtonInventoryGate>();

        gateController.Initialize(gateType, quantityText, this);

        // L'ajouter à activeLevel
        activeLevel.AddGate(gateType, gateController);
    }

    public void PauseGame()
    {
        AudioManager.Instance.PlayButtonClick();
        AudioManager.Instance.PauseMusic();
        modalePause.SetActive(true);
        activeLevel.GetScoringSystem().Pause();
        launchButton.interactable = false;

    }

    public void ResumeGame()
    {
        AudioManager.Instance.PlayButtonClick();
        AudioManager.Instance.ResumeMusic();
        modalePause.SetActive(false);
        activeLevel.GetScoringSystem().Resume();
        launchButton.interactable = true;
    }

    public async void LeaveGame()
    {
        AudioManager.Instance.PlayButtonClick();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelSelect");
        
        // Empêcher la transition automatique vers la nouvelle scène lorsqu'elle est prête
        asyncLoad.allowSceneActivation = true;
        
        // Attendre que la scène soit complètement chargée
        while (!asyncLoad.isDone)
        {   
            // Attendre le prochain frame
            await System.Threading.Tasks.Task.Yield();
        }
        
        // Maintenant que la scène est chargée, afficher les niveaux
        UIManager.instance.displayLevels();
    }

    public void nextLevel()
    {
        AudioManager.Instance.ResumeMusic();
        int nextLevel = activeLevel.GetLevel().getNumber() + 1;
        if(!GameManager.instance.levelIsLocked(nextLevel)){
            GameManager.instance.setActiveLevel(nextLevel);

            switch (nextLevel)
            {
                case 1:
                    SceneManager.LoadScene("Level_1");
                    break;
                case 2:
                    SceneManager.LoadScene("Level_2");
                    break;
                case 3:
                    SceneManager.LoadScene("Level_3");
                    break;
                case 4:
                    SceneManager.LoadScene("Level_4");
                    break;
                default:
                    SceneManager.LoadScene("Level_1");
                    break;
            }

        }else{
            Debug.Log("Level " + nextLevel + " is locked");
        }
    }

    public void ReloadGame(){
        AudioManager.Instance.ResumeMusic();
        AudioManager.Instance.PlayButtonClick();

        int currentLevel = activeLevel.GetLevel().getNumber();
        GameManager.instance.setActiveLevel(currentLevel);

        switch (currentLevel)
        {
            case 1:
                SceneManager.LoadScene("Level_1");
                break;
            case 2:
                SceneManager.LoadScene("Level_2");
                break;
            case 3:
                SceneManager.LoadScene("Level_3");
                break;
            default:
                SceneManager.LoadScene("Level_1");
                break;
        }
    }

    public void OpenWarning(){
        AudioManager.Instance.PlayButtonClick();
        AudioManager.Instance.PauseMusic();
        pauseButton.interactable = false;
        launchButton.interactable = false;
        warningModal.SetActive(true);
    }

    public void CloseWarning(){
        AudioManager.Instance.PlayButtonClick();
        AudioManager.Instance.ResumeMusic();
        pauseButton.interactable = true;
        launchButton.interactable = true;
        warningModal.SetActive(false);
        activeLevel.GetScoringSystem().Start();
    }

    public void LaunchVerif()
    {
        AudioManager.Instance.PlayButtonClick();
        pauseButton.interactable = false;
        launchButton.interactable = false;
        StartCoroutine(LaunchVerifCoroutine());
    }

    private IEnumerator LaunchVerifCoroutine()
    {
        Debug.Log(activeLevel.GetCircuit().ToString());
        activeLevel.GetScoringSystem().Stop();
        double score = activeLevel.GetScoringSystem().ComputeScore(activeLevel.GetNbDoors());
        bool evaluation;

        try{
            evaluation = activeLevel.Evaluate();
        }catch(InvalidOperationException){
            OpenWarning();

            warningButton.onClick.AddListener(() =>
            {
                CloseWarning();
            });

            yield break;
        }

        if(evaluation){
            // Attendre que la coroutine Lumos() se termine complètement
            yield return StartCoroutine(LumosCoroutine());
            
            Sprite activeState = Resources.Load<Sprite>("Graphics/Modal/Win/LightStar");
            Sprite inactiveState = Resources.Load<Sprite>("Graphics/Modal/Win/ShadowStar");

            if (activeState == null){
                Debug.LogError("Impossible de charger la sprite 'LightStar'");
                yield break;  // Équivalent de "return" dans une coroutine
            }
            if (inactiveState == null){
                Debug.LogError("Impossible de charger la sprite 'ShadowStar'");
                yield break;
            }

            winStar1.GetComponent<Image>().sprite = inactiveState;
            winStar2.GetComponent<Image>().sprite = inactiveState;
            winStar3.GetComponent<Image>().sprite = inactiveState;

            // Activer les étoiles en fonction du score
            if (score >= 0){
                winStar1.GetComponent<Image>().sprite = activeState;
                if (score > 50)
                {
                    winStar2.GetComponent<Image>().sprite = activeState;
                    if (score > 80)
                    {
                        winStar3.GetComponent<Image>().sprite = activeState;
                    }
                }
            }
            AudioManager.Instance.PauseMusic();
            AudioManager.Instance.PlaySFX(1);

            modaleVictory.SetActive(true);
            GameManager.instance.RegisterScore(activeLevel.GetLevel().getNumber(), score);

            if(activeLevel.GetLevel().getNumber()+1 <= 4)
            {
                GameManager.instance.UnlockLevel(activeLevel.GetLevel().getNumber()+1);
            }
        }else{
            AudioManager.Instance.PauseMusic();
            AudioManager.Instance.PlaySFX(0);

            Debug.Log("Défaite");
            modaleDefeat.SetActive(true);
        }
        
        GameManager.instance.progressManager.SaveProgress();
    }

    private IEnumerator LumosCoroutine()
    {
        source.Lumos();
        // Attendre 0.75 seconde
        yield return new WaitForSeconds(0.75f);

        // Appel de la méthode Lumos() sur chaque porte avec délai
        foreach (UIGate gate in gates)
        {
            gate.Lumos();
            yield return new WaitForSeconds(0.75f);
        }

        destination.Lumos();
        yield return new WaitForSeconds(1.25f);
    }
}
