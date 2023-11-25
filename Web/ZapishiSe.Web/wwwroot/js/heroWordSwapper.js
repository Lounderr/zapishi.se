// Hero Word Swapper
var words = ['бръснари', 'козметици', 'фризьори', 'масажисти', 'стилисти', 'маникюристи', 'гримьори'];
var part;
var i = 0;
var offset = 0;
var len = words.length;
var forwards = true;
var skip_count = 0;
var skip_delay = 30;
var speed = 70;

var wordflick = function () {
    setInterval(function () {
        if (forwards) {
            if (offset >= words[i].length) {
                ++skip_count;
                if (skip_count == skip_delay) {
                    forwards = false;
                    skip_count = 0;
                }
            }
        } else {
            if (offset == 0) {
                forwards = true;
                i++;
                offset = 0;
                if (i >= len) {
                    i = 0;
                }
            }
        }
        part = words[i].substr(0, offset);
        if (skip_count == 0) {
            if (forwards) {
                offset++;
            } else {
                offset--;
            }
        }
        document.querySelector('.word-swap').textContent = part;
    }, speed);
};

document.addEventListener('DOMContentLoaded', function () {
    wordflick();
});