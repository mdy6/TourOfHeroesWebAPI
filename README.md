domaine pour react tour of heroes.
DDD archi hexa et micro service


Journal des héros
- il existe 4 types d'origine de pouvoir : air terre eau feu 
- le profil d'un héro permet de voir ses caractérisiques et statistique ( nom, type de pouvoir, force, nombre d'action, sa côte de popularité, liste d'article sur ce héro
- Un héro a un profil sur lequel on peut voir son actualité
-on peut voir l'actualité à la une sur la page d'accueil
- chaque article publié sur un héros est favorable ou défavorable ( si le nombre de j'aime sur l'article est supérieur au nombre de je n'aime pas, le héro gagne un point sinon il en perd un)
- la côte de popularité d'un héro peut être négatif
-un article a pour propriété : le titre, le héro associé( on pourra y associé plusieurs héros à l'avenir) un nombre j'aime et un nombre de je n'aime pas, la date de publication 
-la force va de 0 à 10
use case:

2 roles utilisateurs:
- lecteur
-auteur d'article sur les héros


=> en tant qu'auteur je publie les articles sur les héros et je notifie mes lecteurs
=> en tant qu'auteur je crée les différents héro
=> en tant qu'auteur je supprime les différents héro
=> en tant que lecteur je peux voir les articles sur le réseau
=> en tant que lecteur je peux mettre j'aime sur un article 
=> en tant que lecteur je peux mettre je n'aime sur un article 
=> en tant que lecteur je reçois des notifications quand un article est publié
=> en tant que lecteur j'ai accès au profil du héro
=> en tant que héros quand je n'ai aucune article publié mon nombre de point est à 0
=> en tant que héro quand j'ai un article avec 0 j'aime et plus de 0 j'aime pas je perds un point
=> en tant que héro quand j'ai un article avec strictement plus 0 j'aime et 0 j'aime pas je gagne 1 point
=> en tant que héro quand j'ai un  article avec 0 j'aime  et 0 je n'aime pas, je gagne 0 point
=> la côte de popularité est calculé dynamiquement en fonction du nombre j'aime ou je n'aime pas sur un article associé au héro, si le nombre de j'aime et je n'aime pas sur un article évolu dans le temps le nombre de point du héro aussi 
si le nombre de j'aime est égale au nombre de je n'aime pas alors la popularité passé à 0
=> quand un héro est supprimé tout les article associé sont supprimé
=> quand l'article est mise à jour les lecteurs sont notifié
=> quand la popularité d'un héro augmente les lecteurs sont notifié