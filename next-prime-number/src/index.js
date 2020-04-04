"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var next_prime_service_1 = require("./services/next-prime-service");
main(process.argv);
function main(args) {
    if (args.length < 3) {
        console.log("Insufficient amount of parameters!");
        return;
    }
    var num = parseInt(args[2]);
    if (isNaN(num)) {
        console.log("Incorrect parameter type!");
        return;
    }
    num = next_prime_service_1.default(num);
    console.log(num);
}
