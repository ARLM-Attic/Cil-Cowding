function void main () {
	locals_init(
		
	)
	
	call Fractale;
	
	
}

function void Fractale() {
	locals_init(
		double x1,					// 0
		double x2,					// 1
		double y1,					// 2
		double y2,					// 3
		double zoom,				// 4
		double iteration_max,		// 5
		double image_x,			// 6
		double image_y,			// 7
		double c_r,				// 8
		double c_i,				// 9
		double z_r,				// 10
		double z_i,				// 11
		double i,					// 12
		double tmp,					// 13
		double x,					// 14
		double y					// 15
	)
	// on définit la zone que l'on dessine. Ici, la fractale en entière
	// X1
	nop;
	ldd 2,1;
	neg;
	stloc 0;
	// X2
	ldd 0,6;
	stloc 1;
	// Y1
	ldd 1,2;
	neg;
	stloc 2;
	// Y2
	ldd 1,2;
	stloc 3;
	// Zoom
	ldd 100,0;
	stloc 4;
	// iteration_max
	ldd 50,0;
	stloc 5;
	
	// on calcule la taille de l'image :
	// image_x
	ldd 300,0;
	stloc 6;
	// image_y
	ldd 300,0;
	stloc 7;
	
	// Boucle for
	ldd 0,0;
	stloc 14;
	#boucle_for_1
	
		// Contenu boucle_for_1
		
		// Boucle FOR numero2
		ldd 0,0;
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
			ldd 0,0;
			stloc 10;
			//définir z_i = 0
			ldd 0,0;
			stloc 11;
			//définir i = 0
			ldd 0,0;
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
				ldd 2,0;
				ldloc 11;
				mul;
				ldloc 13;
				mul;
				ldloc 9;
				add;
				stloc 11;
				//i = i+1
				ldloc 12;
				ldd 1,0;
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
			add;
			ldd 4,0;
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
			
			ldloc 12;
			ldloc 5;
			ldd 1;
			sub;
			ceq;
			brfalse et_bah_non_2;
			
			ldstr "O";
			call System.Console.Write;
			
			
			br fin;
			#et_bah_non
			ldstr "X";
			call System.Console.Write;
			
			br fin;
			
			#et_bah_non_2
			ldstr "black";
			call System.API_Canvas.ChangeColor;
			ldloc 14;
			ldloc 15;
			call System.API_Canvas.DrawPixel;
			br fin;
			
			#fin
		
		// Fin boucle_for_2
		// Incremente Y de 1
		ldd 1,0;
		ldloc 15;
		add;
		stloc 15;
		
		// Compare y < image_y
		ldloc 15;
		ldloc  7;
		clt;
		brtrue boucle_for_2;
		
	
	// Fin boucle_for_1
	ldd 1,0;
	ldloc 14;
	add;
	stloc 14;
	ldloc 14;
	ldloc  6;
	clt;
	brtrue boucle_for_1;
	
	ret;
}


