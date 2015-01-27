function void main() {
locals_init()

ldstr "Kevin";
call GiveMeMyName;

}

function void GiveMeMyName(string name) {
locals_init()

ldarg 0;
write;
ret;
}