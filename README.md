# Logispark

## Arborescence des fichiers 

**Prefabs/**

Contient des objets préfabriqués réutilisables dans le jeu.
- Buttons/ : Stocke les préfabriqués des boutons utilisés dans l'interface.

**Resources/**

Stocke les fichiers accessibles dynamiquement via Resources.Load().
- Graphics/Backgrounds/ : Contient les arrière-plans du jeu.
- Graphics/Buttons/ : Contient les textures et assets graphiques des boutons.
- Graphics/Others/ : Divers autres assets graphiques.

**Scenes/**

- Regroupe les différentes scènes du jeu.
- Menu.unity : Scène du menu principal.
- LevelSelect.unity : Scène de sélection des niveaux.
- Game.unity : Scène principale du jeu.

**Scripts/**

Stocke tous les scripts du projet, organisés par fonction.
- **Core/**
    - Scripts fondamentaux du jeu.
    - GameManager.cs : Gère les états du jeu (début, pause, fin, etc.).
    - LevelManager.cs : Gestionnaire des niveaux et de leur progression.
    - UIManager.cs : Contrôle l'affichage et la mise à jour de l'interface utilisateur.
- **Circuit/**
    - Scripts liés aux circuits logiques et aux portes logiques.
    - Circuit.cs : Classe principale gérant les circuits.
    - LogicGate.cs : Classe mère des portes logiques.
    - GateTypes/ : Contient les types spécifiques de portes logiques (AND, OR, NOT, etc.).
- **Tiles/**
    - Scripts gérant les tuiles utilisées dans le jeu.
    - TileManager.cs : Responsable de la gestion et du placement des tuiles.
    - CircuitTile.cs : Classe représentant une tuile spéciale pour les circuits.
- **UI/**
    - Scripts dédiés à l'interface utilisateur.
    - MainMenu.cs : Gère le menu principal.
    - LevelSelect.cs : Contrôle la sélection des niveaux.
    - GameUI.cs : Affiche les éléments de l'interface durant la partie.

