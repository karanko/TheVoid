function bang() {
    beat = Math.round((tick / 64) % 4) + 1;
    /*
 ntick = tick;
    if ((tick % 64) == 0) {
        ntick = tick + (beat*16);
        cls();
    }

    if ((tick % 64) >= 60) {
       ntick = (tick % 16) + (32 * beat);
    }
*/
    ntick = tick;;
    perl(); //dodger();
    ntick = tick % 16; //ddrum();
    //ddrum2();
    //ddrum4();
    log(tick + '/' + ntick)
}
function ddrum() {
    if ((ntick % 6) == 4) {
        noteout(38, 90, 10, 100);
    }
    if ((ntick % 12) == 4) {
        noteout(41 + (tick % 2), 90, 10, 100);
    }
    if ((ntick % 8) == 4) {
        noteout(37, 90, 10, 100);
    }
}
function ddrum2() {
    if ((ntick % 5) == 0) {
        noteout(38 + 3, 90, 3, 100);
    } else if ((ntick % 9) == 4) {
        noteout(38, 8 * ((tick % 11) + 12), 3, 100);
    } else if ((ntick % 7) == 0) {
        noteout(38 + 7, 90, 3, 100);
    } else if ((ntick % 3) == beat % 3) {
        noteout(38 + (tick % 5), 90, 3, 100);
    }
    if ((ntick % 12) == 3) {
        noteout(48 + (7 * (tick % 6)), 90 + (tick % 9), 3, 100);
    } else if ((ntick % 9) == 5) {
        noteout(44 + (tick % 6), 9 * (tick % 10), 3, 100);
    }
}
function ddrum4() {
    if ((ntick % 6) == 0) {
        noteout(38, 90, 4, 100);
    }
}
function dodger() {
    t1n = 30 + 12;
    t1v = 70;
    t1l = 110;
    ramp = Math.abs((ntick % 24) - 12);
    ramp2 = Math.abs((ntick % 50) - 25);
    if ((beat % 4) >= 2) {
        t1n = t1n + 7;
    }
    if ((beat % 4) <= 3) {
        t1n = t1n - 3;
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
    if (((ntick % 8) == 0) | ((ntick % 8) == 6)) {
        noteout((t1n % 12) + 36, t1v + ramp2, 1, 1000 + t1l + ramp)
    }
    if (((ntick % 16) == 0)) {
        noteout(t1n, t1v + ramp2, 2, t1l + ramp)
    }
    if (((ntick % 16) == 9)) {
        noteout(t1n, t1v + ramp2, 2, t1l + ramp)
    }
    if (((ntick % 16) == 3)) {
        noteout(t1n, t1v + ramp2, 2, t1l + ramp)
    }
    if (((ntick % 9) == 0)) {
        noteout(t1n + 7, t1v + ramp2, 2, t1l + ramp)
    }
}