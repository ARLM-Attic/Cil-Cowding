function void main () {
locals_init(
int age
)
// On affiche le message
ldstr "Quel age as-tu ?";
write;

// On récupère l'age et on la place dans la var locale
read;
stloc 0;

// On remet le message 
ldstr "Tu as :";
write;
ldloc 0;
write;
ldstr "ans :D";
write;

ret;
}
