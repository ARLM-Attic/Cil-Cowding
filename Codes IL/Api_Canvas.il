function void main () {
	locals_init(
		int a
	)
	
	ldstr "Super Canvas OTD !";
	write;
	ldstr "Je dessine un carr� ! Pr�t ?";
	write;
	read;
	stloc 0;
	
	ldc 0;
	ldc 0;
	ldc 50; 
	ldc 50;
	call System.API_Canvas.DrawLine;
	
	ldc 20;
	ldc 20;
	call System.API_Canvas.DrawPixel;
	
	
	
}

function void drawTrait(int x, int y) {
	locals_init(
		
	)
	ldarg 0;
	ldarg 1;
	// don't call this
	ret;
	
}


