function void main()
{
locals_init
(
int x,
int y
)

// créer un nouveau tableau
ldc 10;
ldc 10;
call Array.API_Array.NewArray;

// Ajouter une valeur à la position donnée
ldc 454; // Valeur à ajouter
ldc 0; // position x
ldc 0; // position y
call Array.API_Array.Add;

// Récupérer la valeur de l'élément à la position donnée
call Array.API_Array.GetElement;
write;


}