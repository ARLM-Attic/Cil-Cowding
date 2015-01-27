function void main () {
locals_init()

ldstr "Hello !";
call Say;

ldstr "J'ai finis la fct :D";
write;

ret;
}

function void Say(string msg) {
locals_init()

ldstr "Hello :)";
starg 0;

ldarg 0;
write;

call Say2;
ret;
}

function void Say2 () {
locals_init(
string coucou,
int hello
)
ldstr "Akekuku :3";
stloc 0;
ldloc 0;
write;
ret;
}