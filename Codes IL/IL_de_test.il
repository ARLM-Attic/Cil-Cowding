var int nb1
var int nb2
WRITE "Tapez nb mystere"
READ int
stlloc.nb1
WRITE "Tapez nb"
READ int
stlloc nb2
ldc nb1
ldc nb2
cgt
WRITE "C'est moins"
ldc nb1
ldc nb2
clt
WRITE "C'est plus"
ldc nb1
ldc nb2
ceq
WRITE "Bravo, vous avez gagné"