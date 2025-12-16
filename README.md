# 1. Introdution : 
Dans le cadre du cours de Programmation en C#, nous avons du créer une application de gestion des matches et compétitions d'une fédération d'échecs! Celui-ci pourra être utilisé par les administrateurs d'une fédération quelconque afin d'y administrer ses joueurs, ainsi que les compétitions et matches à venir! 

# 2. Fonctionnalités : 
##### 1. Home Page avec :
   * Affichage des compétitions en cours
   * Menu de navigation inter-pages
##### 2. Page joueur avec :
   * Possibilité de rechercher un joueur en particulier
   * Possibilité de créer et ajouter un nouveau joueur a la db
##### 3. Page Compétitions :
   * Possibilité de rechercher une compétition en particulier/toutes les compétitions (champ vide)
   * Afficher les joueurs d'une Compétition -> définir l'un d'entre eux comme gagnant de la compétition
   * Afficher les matches d'une Compétition -> définir le gagnant d'un match, mettre a jour les ELO et enregistrer les coups des matches
   * Créer une Compétition et y ajouter des matches
##### 4. Page Classement (Fonctionnalité Bonus): 
   * Affichage du Classement Elo en fonction de la tranche d'age Junior(0-17), Major(18-64)  et Senior(65+)

# 3. Diagramme de Classe
# 4. Diagramme de Séquence 
# 5. Diagramme d'Activité
# 6. Adaptabilité 
Cette app ne se limite pas à l'usage dans le cadre des échecs. En effet, seul les coups sont une fonctionnalité exclusive aux échecs! Nous avons donc fait en sorte que ceux-ci ne soient pas obligatoires a l'enregistrement et la cloture d'un match afin de rendre l'application utilisable dans des cadres externes! 
# 7. Principes SOLID mis en avant 
1.
