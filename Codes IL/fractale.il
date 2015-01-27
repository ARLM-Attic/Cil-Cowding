function void main () {
	locals_init(
		
	)
	
	call Fractale;
	
	
}

function void Fractale() {
	locals_init(
		int x1,					// 0
		int x2,					// 1
		int y1,					// 2
		int y2,					// 3
		int zoom,				// 4
		int iteration_max,		// 5
		int image_x,			// 6
		int image_y,			// 7
		int c_r,				// 8
		int c_i,				// 9
		int z_r,				// 10
		int z_i,				// 11
		int i,					// 12
		int tmp,					// 13
		int x,					// 14
		int y					// 15
	)
	// on définit la zone que l'on dessine. Ici, la fractale en entière
	// X1
	ldc 2;
	ldc 1;
	ldc 10;
	div;
	add;
	neg;
	stloc 0;
	// X2
	ldc 2;
	stloc 1;
	// Y1
	ldc 0;
	stloc 2;
	// Y2
	ldc 2;
	stloc 3;
	// Zoom
	ldc 10;
	stloc 4;
	// iteration_max
	ldc 5;
	stloc 5;
	
	// on calcule la taille de l'image :
	// image_x
	ldloc 1;
	ldloc 0;
	sub;
	ldloc 4;
	mul;
	stloc 6;
	// image_y
	ldloc 3;
	ldloc 2;
	sub;
	ldloc 4;
	mul;
	stloc 7;
	
	// Boucle for
	ldc 0;
	stloc 14;
	#boucle_for_1
	
		// Contenu boucle_for_1
		
		// Boucle FOR numero2
		ldc 0;
		stloc 15;
		#boucle_for_2
		
		
			// Contenu Boucle_for_2
			//définir c_r = x / zoom + x1
			ldloc 14;
			ldloc 4;
			div;
			ldloc 0;
			add;
			stloc 8;
			//définir c_i = y / zoom + y1
			ldloc 15;
			ldloc 4;
			div;
			ldloc 2;
			add;
			stloc 9;
			//définir z_r = 0
			ldc 0;
			stloc 10;
			//définir z_i = 0
			ldc 0;
			stloc 11;
			//définir i = 0
			ldc 0;
			stloc 12;
			
			// Boucle DO WHILE
			#boucle_do_while
				//définir tmp = z_r
				ldloc 10;
				stloc 13;
				//z_r = z_r*z_r - z_i*z_i + c_r
				ldloc 10;
				ldloc 10;
				mul;
				ldloc 11;
				ldloc 11;
				mul;
				sub;
				ldloc 8;
				add;
				stloc 10;
				//z_i = 2*z_i*tmp + c_i
				ldc 2;
				ldloc 11;
				mul;
				ldloc 13;
				mul;
				ldloc 9;
				add;
				stloc 11;
				//i = i+1
				ldloc 12;
				ldc 1;
				add;
				stloc 12;
			// Fin boucle DO WHILE
			//z_r*z_r + z_i*z_i < 4
			ldloc 10;
			ldloc 10;
			mul;
			ldloc 11;
			ldloc 11;
			mul;
			sub;
			ldc 4;
			clt;
			
			// i < iteration_max
			ldloc 12;
			ldloc 5;
			clt;
			// AND !
			and;
			
			brtrue boucle_do_while;
				
			ldloc 12;
			ldloc 5;
			ceq;
			brfalse et_bah_non;
			
			ldstr "Je dois dessiner";
			call System.Console.WriteLine;
			
			ldloc 14;
			ldloc 15;
			call System.API_Canvas.DrawPixel;
			
			#et_bah_non
		
		// Fin boucle_for_2
		// Incremente Y de 1
		ldc 1;
		ldloc 15;
		add;
		stloc 15;
		
		// Compare y < image_y
		ldloc 15;
		ldloc  7;
		clt;
		brtrue boucle_for_2;
		
	
	// Fin boucle_for_1
	ldc 1;
	ldloc 14;
	add;
	stloc 14;
	ldloc 14;
	ldloc  6;
	clt;
	brtrue boucle_for_1;
	
	ret;
}


