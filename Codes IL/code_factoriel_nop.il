function void main () {
	locals_init(
		int fac
	)
	
	ldstr "Super factoriel OTD !";
	write;
	ldstr "Factoriel de ?";
	write;
	read;
	stloc 0;
	
	ldloc 0;
	call fact;
	
	stloc 0;
	ldstr "Resultat : ";
	write;
	ldloc 0;
	write;
	
	ldstr "fin :-)";
	write;
	read;
	
	
}

function int fact(int nb) {
	locals_init(
		int retour_fct
	)
nop;
	ldarg 0;
	ldc 1;
	ceq;
	brfalse recur;
	ldc 1;
	ret;
	
	
	#recur
	ldarg 0;
	ldc 1;
	sub;
	call fact;
	ldarg 0;
	mul;
	ret;
	
}


