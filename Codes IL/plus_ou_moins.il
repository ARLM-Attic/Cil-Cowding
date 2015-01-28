var int nb_mys
var int nb_test
ldstr "Bonjour et bienvenue dans le Plus ou Moins OTD !"
WRITE
ldstr "Joueur 1, tapez le nb mystere !"
WRITE
READ
conv int
stloc nb_mys
ldstr "Tapez le nb mystere !"
WRITE
READ
conv int
stloc nb_test
ldloc nb_mys
ldloc nb_test
cgt
brfalse 21
ldstr "C'est moins !"
WRITE
br 9
ldloc nb_mys
ldloc nb_test
clt
brfalse 28
ldstr "C'est plus !"
WRITE
br 9
ldloc nb_mys
ldloc nb_test
ceq
brfalse 34
ldstr "C'est ça !"
WRITE
ldstr "C'est une superbe demo n'est-ce pas ?"
WRITE