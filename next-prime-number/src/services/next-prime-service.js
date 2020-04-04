"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function getNextPrime(num) {
    if (num === 0 || num === 1) {
        return 2;
    }
    var current = num + 1;
    while (true) {
        var isPrime = true;
        if (current % 2 == 0) {
            current++;
            continue;
        }
        for (var i = 3; i < Math.sqrt(current) + 1; i += 2) {
            if (current % i == 0) {
                isPrime = false;
                break;
            }
        }
        if (isPrime) {
            return current;
        }
        current++;
    }
}
exports.default = getNextPrime;
