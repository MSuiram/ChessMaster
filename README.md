# 1. Introduction  

Dans le cadre du cours de **Programmation en C#**, nous avons développé une application permettant la **gestion des compétitions et des matches d’une fédération d’échecs**.  
Cette application est destinée aux **administrateurs d’une fédération**, afin de leur offrir un outil centralisé pour gérer les **joueurs**, les **compétitions** ainsi que les **matches à venir ou en cours**.

# 2. Fonctionnalités  

## 2.1 Page d’accueil (Home Page)
- Affichage des compétitions en cours  
- Menu de navigation permettant l’accès aux différentes pages de l’application  

## 2.2 Page Joueurs
- Recherche d’un joueur spécifique  
- Création et ajout de nouveaux joueurs dans la base de données  

## 2.3 Page Compétitions
- Recherche d’une compétition spécifique ou affichage de toutes les compétitions (champ de recherche vide)  
- Affichage des joueurs d’une compétition et désignation du vainqueur  
- Affichage des matches d’une compétition :
  - Définition du gagnant d’un match  
  - Mise à jour du classement **ELO**  
  - Enregistrement des coups joués lors des matches  
- Création d’une compétition et ajout de matches associés  

## 2.4 Page Classement (fonctionnalité bonus)
- Affichage du classement ELO par tranche d’âge :
  - Junior (0–17 ans)  
  - Major (18–64 ans)  
  - Senior (65 ans et plus)  

# 3. Diagramme de classes
Diagramme de Séquence mettant en avant l'affichage des compétitions ainsi que la création d'une d'entre elle
![Texte alternatif](ChessMaster/DiagrammeSéquence.png "Diagramme de Séquence")


# 5. Diagramme d’activité  
Diagramme d'Action mettant en avant la création d'une nouvelle compétition
![Texte alternatif](ChessMaster/DiagrammeAction.png "Diagramme d'Action")


# 6. Adaptabilité de l’application  

Cette application ne se limite pas exclusivement au cadre des échecs. En effet, **la gestion des coups constitue la seule fonctionnalité spécifique à ce sport**.  
Nous avons donc conçu le système de manière à rendre l’enregistrement des coups **optionnel**, afin de permettre la validation et la clôture d’un match sans ceux-ci.

Ainsi, l’application peut être utilisée dans **d’autres contextes sportifs ou compétitifs**, à condition que les rencontres soient des **matches en un contre un (1v1)**.

# 7. Principes SOLID mis en avant  

## 7.1 Open/Closed Principle (OCP)

Chaque fonctionnalité de l’application est conçue de manière **indépendante**. Cela permet de **modifier ou faire évoluer une fonctionnalité sans impacter le reste de l’application**.  
De plus, il est possible d’**ajouter de nouvelles fonctionnalités** sans avoir à modifier l’environnement existant, ce qui respecte pleinement le principe *Open/Closed*.


## 7.2 Single Responsibility Principle (SRP)

À l’exception de la classe **CompetitionViewModel**, chaque *ViewModel* est responsable de la gestion d’**une seule page**.  
Ce découpage favorise une structure de code claire, limite la complexité et évite les classes surchargées en méthodes et en variables.

Cependant, dans un souci de gain de temps, le **CompetitionViewModel** centralise la gestion de toutes les pages liées aux compétitions, dont l’affichage dépend du paramètre `IsVisible`.  
Cette approche entraîne une **augmentation significative du nombre de variables et de méthodes**, rendant la classe moins lisible et moins conforme au principe de responsabilité unique.


# 8. Conclusion  

Nous avons développé une application complète permettant la **gestion d’une fédération d’échecs**, tout en restant suffisamment flexible pour être utilisée dans d’autres contextes impliquant des matches **1v1**.  
L’application offre notamment la gestion des adhérents, des compétitions et des événements organisés par la fédération.

De manière générale, nous avons cherché à **structurer et segmenter notre application** afin de respecter au mieux les **principes SOLID**.  
Néanmoins, une analyse a posteriori met en évidence plusieurs axes d’amélioration, notamment le **redécoupage de la classe CompetitionViewModel**, afin d’améliorer la lisibilité, la maintenabilité et le respect du principe de responsabilité unique.

