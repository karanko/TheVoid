function bang() {
    if ((tick % 64) == 0) {
        cls()
    } //log(tick + '/' + tick%32)
    shitbeat = ((Math.round((((tick % 64) - 8) / 64) * 4)) % 4) + 1;
    beat = shitbeat; //log(tick%64 + '/' +beat);
    key1();
    rhy1();
}
function rhy1() {
    if (((tick % 8) == 0)) {
        noteout(36, 90, 10, 10);
    }
    if (((tick % 16) == 12) | ((tick % 8) == 6)) {
        noteout(36 + 6, 90, 10, 10);
    } else if ((((tick & 12) == 0)) & ((tick % 3) == 2)) {
        noteout(36 + 8 + ((tick % 2) * -2), 90, 10, 10);
    }
}
function key1() {
    /*
note1 = 12-2; //10
note1 = 12-6; //6
note1 = 12+5-4; 13
note1 = 12+5-4-4; 9
*/
    note = 4 + 12 + 24;
    if ((beat % 2) == 1) {
        note = note - 4;
    }
    if ((beat % 4) >= 3) {
        note = note + 1;
    }
    if ((tick % 6) == 3) {
        note += 14;
    } //bass
    if ((((tick % 64) % 6) == 0) | ((tick % 24) == 0)) {
        noteout(note, 100, 2, 150);
    } //bass2
    if ((((tick % 64) % 12) == 0) | ((tick % 18) == 0)) {
        noteout(note, 100, 6, 350);
    } //pad1
    if ((tick % 16) == 0) {
        noteout(note, 100, 1, 400);
    } //pad2
    if ((tick % 16) == 6) {
        noteout(note, 100, 3, 300);
    } //pad2
    if ((tick % 16) == 12) {
        noteout(note, 100, 4, 500);
    } ///synth
    if ((((tick % 9) == 2)) | ((tick % 5) == 0)) {
        noteout(note + ((tick % 2) * 12), 90, 5, 50);
    }
}