function dotted_put(str,val) {
    var oper=str.split('.');
    var p=this;
    for (var i=0;i<oper.length-1;i++) {
        var x=oper[i];
        p[x]=p[x]||{};
        p=p[x];
    }
    p[oper.pop()]=val;
}

function apcnote(pnumber, channel, note) {

    page = JSON.parse(apcpageraw(pnumber));
    if (!page.Mute) {
        if (page.Pattern.Steps[tick % page.Pattern.Length]) {
            noteout(note, page.Vel, channel, 250);
        }
    }
}

function scale(name, root, note) {

    rawscaledata = [];
    rawscaledata['major'] = ('2-2-1-2-2-2-1');
    rawscaledata['natuaral minor'] = ('2-1-2-2-1-2-2');
    rawscaledata['minor pentatonic'] = ('3-2-2-3-2');
    rawscaledata['blues'] = ('3-2-1-1-3-2');
    rawscaledata['major pentatonic'] = ('2-2-3-2-3');
    rawscaledata['harmonic minor'] = ('2-1-2-2-1-3-2');
    rawscaledata['melodic minor'] = ('2-1-2-2-2-2-1');
    rawscaledata['ionian'] = ('2-2-1-2-2-2-1');
    rawscaledata['dorian'] = ('2-1-2-2-2-1-2');
    rawscaledata['phrygian'] = ('1-2-2-2-1-2-2');
    rawscaledata['lydian'] = ('2-2-2-1-2-2-1');
    rawscaledata['mixolydian'] = ('2-2-1-2-2-1-2');
    rawscaledata['aeolian'] = ('2-1-2-2-1-2-2');
    rawscaledata['locrian'] = ('1-2-2-1-2-2-2');
    rawscaledata['whole tone'] = ('2-2-2-2-2-2');
    rawscaledata['whole-half diminished'] = ('2-1-2-1-2-1-2-1');
    rawscaledata['half-whole diminished'] = ('1-2-1-2-1-2-1-2');

    thisnote = (note % 12) + 1
    thisscale = ('0-' + rawscaledata[name]).split('-');

    returnnote = 0;
    i = 0;
    inote = (root % 12) + 1;

    while (i < thisscale.length) {
        inote += parseInt(thisscale[i]);

        if (thisnote == inote) {
            returnnote = thisnote;
            break;
        }
        else if (thisnote <= inote) {
            returnnote = thisnote + 1;
            break;
        }
        i++
    }

    return ((Math.floor((note / 12)) * 12) + returnnote) - 1;
}
