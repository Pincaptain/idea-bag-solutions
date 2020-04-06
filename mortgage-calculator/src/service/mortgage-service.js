"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var MortgageService = /** @class */ (function () {
    function MortgageService(loan, interest, term) {
        this.loan = loan;
        this.interest = interest;
        this.term = term;
    }
    MortgageService.prototype.calculateMonthly = function (type) {
        // Calculate based on the type selected
        var t = type == MortgageService.type.DAILY ? 365 :
            type == MortgageService.type.MONTHLY ? 12 : 1;
        // Number of periodic payments
        var n = this.term * t;
        // Periodic interest rate
        var i = (this.interest / 100) / t;
        // Discount factor {[(1 + i) ^n] - 1} / [i(1 + i)^n]
        var D = ((Math.pow((1 + i), n) - 1) / (i * Math.pow((1 + i), n)));
        return this.loan / D;
    };
    MortgageService.type = {
        DAILY: 'daily',
        MONTHLY: 'monthly',
        YEARLY: 'yearly'
    };
    return MortgageService;
}());
exports.default = MortgageService;
