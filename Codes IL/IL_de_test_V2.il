var int age
var int reponse
var int test_egalite
ldc 20
ldc 20
ceq
stloc test_egalite
ldc 18
stloc age
WRITE "Je suis un texte de test"
WRITE "1 pour recommencer le text"
READ
stloc reponse
brtrue 10
WRITE "Oki salut !"
READ	