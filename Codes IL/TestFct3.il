function void main () {
locals_init(
	string name,
	int age
)

ldstr "Je suis un test";
write;
call fuckApple;

ldstr "FInit :3";
write;
ret;
}

function int fuckApple(string, int) {
locals_init(
	string name,
	int age
)

ldstr "Je suis dans la fct FuckApple !";
write;
call WhostheBest;
ldstr "viens de sortir de WTB.";
write;
ret;
}

function string WhostheBest(int) {
locals_init()

ldstr "Je suis dans Who's The Best.";
write;
ldstr "Et c'est bibi ! :D";
write;
ret;
}