function void main () {
locals_init(
	string name,
	int age
)

ldstr "Kevin";
ldc 19;
call test;
}

function void test(int age, string name) {
locals_init ()

ldstr "TEST";
write;
ret;

}
