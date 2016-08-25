function bang() {
    beat = Math.round((tick / 64) % 4) + 1;
    ntick = (tick % 16) + (32 * beat);
    if ((tick % 8) == 0) {
        ntick = 0;
    }
    if ((tick % 8) == 4) { //       ntick = 0;
    }
    if ((tick % 8) >= 4) {
        ntick = tick;
    }
    dodger();
    ntick = tick % 32;
    ddrum();
}
function dodger() {
    t1n = 30;
    t1v = 90;
    t1l = 910;
    ramp = Math.abs((ntick % 24) - 12);
    ramp2 = Math.abs((ntick % 50) - 25);
    if (beat >= 2) {
        t1n = t1n + 7;
    }
    if (beat <= 3) {
        t1n = t1n - 3;
    }
    if ((ntick % 5) >= 3) { //        t1n += (ntick % 5)
    }
    if ((ntick % 8) >= 6) {
        t1n += (3 * (ntick % 5));
    }
    if ((ntick % 3) == 0) {
        t1n += (12 * (ntick % 3));
    }
    if ((ntick % 2) == 0) {
        t1n += (12 * (ntick % 3));
    }
    if (((ntick % 4) == 0) | ((ntick % 3) == 0)) {
        noteout(t1n, t1v + ramp2, 1, t1l + ramp)
    }
    if (((ntick % 7) == 0)) {
        noteout(t1n + 12, t1v + ramp2, 2, t1l + ramp)
    }
}
function ddrum() {
    if ((ntick % 6) == 0) {
        noteout(36, 90, 10, 100);
    } else if ((ntick % 8) == 4) {
        noteout(37, 90, 10, 100);
    }
}