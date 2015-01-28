function void main () {
locals_init(
	string name,
	int age
)
ldc 2;
call test;
}

function void test(int age, string name) {
ldstr "TEST";
write;
ret;
}
