![header](https://hackmd.io/_uploads/B1JX42pg0.jpg)

# Earth Discovery 🧚‍♀️

Karim **CHARLEUX**
Anas **CHHILIF**
Michel **KADILAR**
Damien **STENGEL**
Loïc **PALAYER**

#### Lien pour télécharger le jeu :
[Lien OneDrive Earth Discovery ](https://unice-my.sharepoint.com/:f:/g/personal/karim_charleux_etu_unice_fr/Ehu7bpf0vLxEujFmVdMWOyIBmcew5Zgqa13at0mkJhIyQg?e=3or3mE)
Pour lancer le projet il faut installer 2 packages : 
![image](https://hackmd.io/_uploads/H1-TKpTgC.png)
![image](https://hackmd.io/_uploads/ByUCtppe0.png)
Puis dans le *Project Settings > Graphics > Scriptable Render Pipeline Settings*
![image](https://hackmd.io/_uploads/B1fB9paxR.png)
Séléctionner la version "Ultra PipelineAsset" puis appliquer pour correctement obtenir les textures de notre projet.

## Introduction
Earth Discovery est un jeu vidéo d'aventure narratif et immersif dans lequel le joueur incarne une jeune princesse qui doit traverser 4 planètes, chacune ayant une particularité, pour accomplir sa quête. Chaque planète présente des défis uniques et des mécaniques de jeu spécifiques, le tout lié par une histoire cohérente et des transitions fluides entre les différents environnements.

Afin de consever une immersion maximale, le traditionnel menu permettant de passer d'une planète à l'autre. Au lieu de cela, le joueur est plongé dans une expérience narrative continue, avec des transitions naturelles entre les différentes étapes au fil de l'histoire. Cette approche renforce l'immersion et l'engagement du joueur dans l'univers d'Earth Discovery.


![Planète1](https://hackmd.io/_uploads/BknYJ3pe0.jpg)

## 🌍 Planète 1 : Musée Polytech (Michel & Loic)
### Objectif
L'objectif de cette planète est de guider la princesse à travers un musée  interactif rempli de 5 oeuvres animées

### Mécaniques de jeu
- Interaction avec des objets du musée pour progresser
- Modèles 3D importés de Blender avec leurs animations
- Dialogue poussant à la recherche des modèles Blender importés

### Fonctionnalités implémentées
- Importation des modèles blender de toute l'équipe (2 modèles à taille réelle, 3 vidéos)
- Carte de jeu que le joueur peut explorer
- Fée suivant la princesse afin de lui donner des indications
- Début de dialogue avec la fée Navi

### Ressources
- **Le musée de Polytech** https://assetstore.unity.com/packages/3d/environments/historic/greek-low-poly-pack-lite-136606
    - On a rajouté une grande affiche sur le batiment pour y indiquer que c'est le musée de Polytech avec le "P" de polytech
    
- **La map** https://assetstore.unity.com/packages/3d/environments/boki-low-poly-nature-206385
    - La carte a était modifié pour ajouter des chemins avec Terrain Painter, également supprimé des arbres, feuillages, herbes et cailloux.
- **La fée Navi** https://sketchfab.com/3d-models/fairy-the-legend-of-zelda-botw-ce8425ea1cfb40e492906bb62d970969
    - On a ajouté des particules ainsi qu'une trainée avec un effet de glow par dessus tout pour donnée un effet de surbrillance
- **Princesse** https://assetstore.unity.com/packages/3d/characters/amane-kisora-chan-free-ver-70581


![Planète2](https://hackmd.io/_uploads/SJiSQh6l0.jpg)

## 🌍 Planète 2 : Planète Vitesse (Karim)
### Objectif
Sur cette planète, la princesse doit participer à une course de voitures appelée "PolyTracks Legends". Elle doit surpasser trois intelligences artificielles pour remporter un trophée essentiel afin de retourner sur la planète du musée Polytech et poursuivre sa quête.

### Mécaniques de jeu
- Course de voitures avec **3 agents intelligents**, ils savent tourner grâce à la liste des waypoints qui est tout au long de la carte, ils savent également freiner quand ils vont trop vite, car oui, il est nécessaire avec ce circuit au bout de la ligne droite de freiner pour prendre correctement les 2 grands virages. Quand ils sont bloqués au bout de 1 seconde dans un mur, ils vont comprendre qu'il faut alors reculer jusqu'à être débloqués. 
- Le **controller de la voiture du joueur** est très complet, il peut *drifter* lorsqu'il est dans les virages avec les traces de pneus sur la route, le son des pneus et la fumée. La voiture avance grace à 4 *Wheel Collider* qui roule et qui ont chacun une masse qui simule réellement la friction sur la route avec le poids de la voiture. Le controlleur possède plusieurs paramétrages : il était facile d'avoir le résultat voulu. Il a été nécessaire de modifier les inputs du controller pour remplacer les inputs du clavier par les inputs x et y du joueur via le script *Player Controls*. Des feux de stop, lorsque le joueur freine s'allument en rouge.
- Le jeu possède un **UI menu**, composé d'un bouton "Jouer", un bouton pour mettre en sourdine le son (ça enregistre sa modification dans *PlayerPrefs* pour qu'il le sauvegarde pour la prochaine fois) avec une cinématique en fond réalisé avec *Cinemachine*, un plugin Unity. J'ai utilisé une *virtual camera* qui suit la position d'un Dolly Cart tout fixant la voiture du joueur, le Cart suit un Dolly Track créé spécifiquement, qui permet de faire tout le tour du circuit dans une boucle fluide, dans le but d'avoir un apercu avant de jouer.
- L'**UI pendant la conduite** de la voiture est simple, on a toutes les commandes, la vitesse de la voiture (en km/h) ainsi que le nombre de tours restant. Lorsque que c'est un bot qui termine 1er, il est alors affiché la position du joueur et il est invité à recommencer en tapant Echap, dans le cas où il gagne il la alors un message de félicitation qui l'invite à récupérer son trophée puis retourner sur la planète 1 avec un bouton.

- Le joeur peut à tout moment appuyé sur Echap durant sa partie pour revenir sur le menu, c'est alors que toutes les voitures vont êtres replacé à leurs positions initale ainsi que les compteurs vont être remis à zero. Ça lui permet de recommencer à tout moment quand il fait un mauvais départ par exemple.

### Fonctionnalités implémentées

* Circuit de course avec différents défis et obstacles
* Personnages non-joueurs (PNJ) représentant d'autres pilotes
* Système de classement et de récompenses basé sur les performances
* Intelligence Artificielle (IA) avancée des véhicules adverses (capacité à tourner, ralentir, accélérer, reculer en cas de blocage)
* Cinématique de menu

### Ressources
- **Camera Controller** https://assetstore.unity.com/packages/templates/packs/car-controller-202269
    - J'ai récupéré la cameré de ce controller qui est vraiment bien car elle agréable pour le joeur et possède une fonctionnalité pertinent qui est que la cameré se retourne fluidement quand le joueur recule. J'ai ensuite modifié les paramètres.
- **Car Controller du joueur et la voiture** https://assetstore.unity.com/packages/tools/physics/prometeo-car-controller-209444
    - J'ai récupéré la voiture ainsi que son controller car il est très complet comme dit précedement. J'ai ajouté la gestions des feux de stop et modifié ses inputs et ses paramètres.
- **La map** https://assetstore.unity.com/packages/3d/environments/roadways/cartoon-race-track-oval-175061
    - J'ai modifié les textures pour y ajouter le logo du jeu, modifié les tracés du circuit, fermer les pistes hors du circuit,

- Les sons du jeu sont téléchargés depuis YouTube que j'ai ensuite raccouci et j'ai choisi des sons provenant de Mario Kart pour avoir un univers sonore arcade. 
- J'ai réalisé les logos et modifié les textures avec Adobe Photoshop moi-même.
- J'ai entièrement réalisé les Controllers Car des bots, car j'ai eu certains soucis avec le car controller du joueur. J'ai donc repris la base du TD Racing cars pour ensuite l'améliorer afin d'avoir une IA intéligente qui puisse correctement agir en fonction des événements. Je me suis inspiré du Car Controller du joueur pour avoir un comportement un peu près similaire.
- J'ai réalisé la cinématique du menu avec l'aide d'un tutoriel YouTube https://www.youtube.com/watch?v=W6-lwxQ1tTg&t=463s
- J'ai utilisé aucun autre tutoriel à part le TD Racing Cars

![planète3](https://hackmd.io/_uploads/rJM5126e0.jpg)

## 🌍 Planète 3 : Planète Météo (Damien)

### Objectif
LA princesse arrive dans une salle blanche et doit compléter les objectifs pour atteindre la planète 4.

### Mécaniques de jeu
Dans la salle blanche, un seul élément est présent en plus du téléporteur par lequel la princesse est arrivée : une planète flottante. Lorsqu'elle s'en approche, elle découvre qu'elle peut manipuler à sa guise la planète et sélectionner les capitales affichées sur celle-ci. À la sélection d'une capitale, la sphère la représentant change de couleur pour indiquer son choix, et la météo de celle-ci est affichée (température + icône). Cette météo est récupérée en temps réel grâce à l'API OpenWeatherMap. Elle doit accomplir des missions sous forme d'objectifs pour ensuite pouvoir retourner à la salle blanche. À son retour, la princesse découvre qu'un bout de mur a disparu, ouvrant ainsi le chemin vers un couloir. Ce couloir la mène à la prochaine planète.


### Fonctionnalités implémentées
- Visualisation de la planète
- Manipulation (Zoom/Rotation) de la planète
- Remplissage via csv des capitales
- Sélection de capital pour en afficher la météo
- Système d’objectifs
- Navigation de capitales en capitales
- Connection à une  API


### Ressources
- Pillar (sans modification) https://sketchfab.com/3d-models/doric-twist-pedestal-7936fc9cbb6547459bfecb20910281ec
- Princesse (sans modification) https://assetstore.unity.com/packages/3d/characters/amane-kisora-chan-free-ver-70581
- Controlleur à la 3ème personne (sans modification) https://assetstore.unity.com/packages/tools/game-toolkits/third-person-controller-basic-locomotion-free-82048
- Fond spatial (sans modification) https://assetstore.unity.com/packages/2d/textures-materials/dynamic-space-background-lite-104606
- Téléporteur (sans modification), asset non trouvé

![planète4](https://hackmd.io/_uploads/B1_c13ax0.jpg)

## 🌍 Planète 4 : Planète Laboratoire Savant Fou (Anas)

### Objectif
Pour accomplir sa quête finale, la princesse doit infiltrer le laboratoire d'un savant fou et désactiver ses expériences dangereuses.

### Mécaniques de jeu
Phases d'infiltration et de furtivité
Résolution d'énigmes scientifiques et manipulation d'équipements de laboratoire

### Fonctionnalités implémentées

Environnement de laboratoire futuriste avec des salle thématique

Défis complexes impliquant la manipulation d'objets, leur relâchement à des endroits précis et l'activation d'autres objets

Effets Particules pour simuler feu, eclair et fumée

### Ressources
#### Models:
- Scifi-lab https://sketchfab.com/3d-models/sci-fi-lab-machine-675ae30eaa30470c995023b079569f34
- Lab things https://sketchfab.com/3d-models/lab-things-6ed351eea02e4aefb6c3aad80a763890
- Lab tube https://sketchfab.com/3d-models/lab-tube-for-pal-ae74e0f761464bedb1a5e06635941472
- Science lab cabinet https://sketchfab.com/3d-models/science-lab-cabinet-121829e2dbef45128ba5c9b04d0f03ce
- Dna lab machine https://sketchfab.com/3d-models/dna-lab-machine-07b274281e3c4c6f8c02308b0fc809ad
- Lab glassware https://sketchfab.com/3d-models/lab-glassware-18910c5df5134de784ed6811407e2a05
- Lab bench https://sketchfab.com/3d-models/lab-bench-1ac2a62c52a848bbaf746146dc7253f8
- Sci-fi lab https://sketchfab.com/3d-models/sci-fi-lab-f7626acfa80943bab35568b4852b8ab8
- Autopsy lab https://sketchfab.com/3d-models/autopsy-lab-assets-5ceaaa4482a84774b9922366cfb228e7
#### Tutorial:
- Fire tutorial https://www.youtube.com/watch?v=AoYCliRCQhs
- Lightning tutorial https://www.youtube.com/watch?v=Y0ErHRrlqjs


## Conclusion

Earth Discovery offre une expérience de jeu variée et ludique, combinant des éléments d'aventure, d'apprentissage, de réflexion et d'adresse. Chaque planète présente des défis uniques qui mettent à l'épreuve les capacités du joueur tout en s'immergeant dans des univers thématiques. Grâce à une narration cohérente et des transitions fluides entre les différents environnements, le joueur reste plongé dans l'histoire de la princesse tout au long de sa quête.

Ce projet d'IHM démontre une approche innovante pour nous dans la conception d'un jeu vidéo, en évitant les menus et interfaces traditionnels et en favorisant une expérience narrative continue.
Du point de vue technique, nous ressertons de ce projets tous plus rodés sur de nombreux sujets, de part les spécifications du projet qui nécéssitent de "toucher à tout".

