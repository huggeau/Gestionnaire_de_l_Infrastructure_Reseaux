# Gestionnaire d'Infrastructure Reseau

  Voici un exemple de projet que j'ai du effectuer lors de mon stage de première année de BST CIEL, il s'agit d'un logiciel C# en Windows Form permettant de visualiser les connections réseaux d'une infrastructure afin de savoir si certain matériel réseau est déféctueux ou éteint. 

  Le programme fonctionne avec une base de donnée contenant les adresses ip des différentes machines du réseau.
  
  Toute information importante que m'avais donné mon maitre de stage tels que les addresses IP, le lien vers leur base de donnes, etc... ont été enlevé, il sera donc à vous de remplir toute ces partie la afin de pouvoir l'incruster à votre réseaux.

  Il vous faudra le package NuGet " MySqlConnector " car, dans mon cas, j'utilisais une base de données mariadb et non sqlite.

  ce programme étant entièrement fais en C# et n'utilisant pas de FrameWork, je sais que cela aurait pu être fais d'une façon plus pratique ouplus optimisé mais j'ai fais avec ce que j'ai appris et avec mon seule intellect ( et celui de mes collègues et d'Internet aussi )

  j'espère qu'avec toute les commentaires qui se trouve dans mon code, vous comprendrez ce que font mes méthodes ou mes classes.

  voici le schéma de la base de données que j'avais utilisé:

  Table : 
  - Site // contient tout les infrastructure qui sont relié au réseau
  - Materiel_reseau // contient tout les éléments du réseau ( donc les switchs, imprimantes, etc )
  - etage // contient le nombre d'étage sur lequel les éléments sont posé ( ce sont les étage d'un batiment )
  - categorie_de_materiel // contient toute les categories de materiel

Lien entre les tables :
materiel_Reseau contient 3 clé étrangère dont :
- 1 clef id_etage relié a l'id de l'étage
- 1 clef id_categorie_de_materiel relié l'id de la catégorie du matériel
- 1 clef id_site relié a l'id du site


Merci de votre lecture et bonne lecture et apprentissage du fonctionnement de mon code.

Cordialement Goisot Hugo
 
