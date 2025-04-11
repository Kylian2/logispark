# LogiSpark

## À propos

Notre jeu propose une approche interactive de la logique mathématique à travers différents
puzzles. Chaque niveau présente un circuit électrique composé de fils reliant une source
d’énergie à un ou plusieurs appareils (four, radio, machine à laver, etc.). À certains
emplacements du circuit, le joueur peut placer des portes logiques (ET, OU, XOR, etc.). Pour
réussir, le joueur doit judicieusement placer les portes logiques afin d’acheminer le courant
jusqu’aux appareils.

LogiSpark est un jeu conçu pour les appareils mobile et développé avec Unity.

## Auteurs
- Kylian Richard
- Esteban Rodrigues
- Mathieu Guiborat-Bost

*Dernière mise à jour: 11 avril 2025*

## Prérequis
- Unity Hub installé sur votre ordinateur
- Connexion internet pour télécharger Unity Editor
- Code source du jeu (disponible sur https://github.com/Kylian2/logispark)

## Installation

### 1. Installation de l'éditeur Unity
- Ouvrez Unity Hub
- Allez dans la rubrique "Installs"
- Cliquez sur "Install Editor"
- Installez la version 6000.0.35f1 de Unity

### 2. Ajout du projet
- Dans Unity Hub, allez dans la rubrique "Projects"
- Cliquez sur "Add"
- Sélectionnez "Add project from disk"
- Naviguez et sélectionnez le dossier contenant le code source

## Configuration du projet

### 1. Vérification des scènes
- Ouvrez le projet logispark en double-cliquant dessus dans la liste des projets
- Allez dans "File" → "Build profiles" → "Scene List"
- Vérifiez que les scènes suivantes sont présentes et cochées:
  - Menu
  - LevelSelect
  - Level_1
  - Level_2
  - Level_3
  - Level_4

### 2. Ajout de scènes manquantes (si nécessaire)
- Naviguez dans le dossier logispark/Assets/Scenes via la rubrique "Project"
- Ouvrez la scène manquante en double-cliquant dessus
- Retournez dans "File" → "Build profiles" → "Scene List"
- Cliquez sur "Add Open Scene" pour l'ajouter à la liste

## Exécution du projet

### 1. Configuration du simulateur
- Cliquez sur l'onglet "Simulator" (à côté de l'onglet "Scene")
- Sélectionnez "Apple iPhone 12" comme appareil pour assurer un affichage correct
- Si nécessaire, cliquez sur "Rotate" pour positionner l'appareil à l'horizontal

### 2. Lancement du jeu
- Cliquez sur le bouton "Play" en haut de l'interface pour exécuter le projet
- Le jeu devrait maintenant démarrer dans le simulateur

## Remarques importantes
- Ce projet est conçu pour les appareils mobiles, l'utilisation du simulateur est essentielle
- Un mauvais choix d'appareil dans le simulateur peut entraîner des problèmes d'affichage
- Assurez-vous que toutes les scènes sont correctement ajoutées avant de lancer le jeu
