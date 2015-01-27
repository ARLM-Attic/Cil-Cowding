function void main () {

locals_init()

call message;

ldc 42;
call boucle_jeu;


// On a fini le jeu
ldstr "Oki salut !";
write;
ret;
}

// Fct qui affiche le message de debut
function void message() {
	locals_init()
	ldstr "Bonjour et bienvenu dans ce superbe Plus ou Moins !";
	write;

	ret;

}


function void boucle_jeu(int random) {
	locals_init(
		int nb
	)
	// Début de la boucle de jeu OTD
	#boucle_de_jeu

	// Get number
	ldstr "Donne un nombre";
	write;
	read;
	stloc 0;
	
	// test egal
	#test_egal
	ldarg 0;
	ldloc 0;
	ceq;
	brtrue win;
	
	#test_superieur
	ldarg 0;
	ldloc 0;
	cgt;
	brfalse test_inferieur;
	ldstr "C'est moins !";
	write;
	
	#test_inferieur
	ldarg 0;
	ldloc 0;
	clt;
	brfalse boucle_de_jeu;
	ldstr "C'est plus !";
	write;
	

	#win
}