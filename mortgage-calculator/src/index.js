"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var mortgage_service_1 = require("./service/mortgage-service");
main(process.argv);
function main(args) {
    if (args.length < 6) {
        console.log("Invalid number of parameters provided.");
        return;
    }
    var loan = parseInt(args[2]);
    var interest = parseFloat(args[3]);
    var term = parseInt(args[4]);
    var type = parseInt(args[5]);
    if (isNaN(loan) || isNaN(interest) || isNaN(term) || isNaN(type)) {
        console.log("Invalid parameters provided.");
        return;
    }
    var t = type == 1 ? mortgage_service_1.default.type.DAILY :
        type == 2 ? mortgage_service_1.default.type.MONTHLY : mortgage_service_1.default.type.YEARLY;
    var mortgageService = new mortgage_service_1.default(loan, interest, term);
    console.log(mortgageService.calculateMonthly(t));
}
