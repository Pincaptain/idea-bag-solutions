export default class MortgageService {
    loan: number;
    interest: number;
    term: number;
    static type = {
        DAILY: 'daily',
        MONTHLY: 'monthly',
        YEARLY: 'yearly'
    };

    constructor(loan: number, interest: number, term: number) {
        this.loan = loan;
        this.interest = interest;
        this.term = term;
    }

    calculateMonthly(type) {
        // Calculate based on the type selected
        let t: number = type == MortgageService.type.DAILY ? 365 :
            type == MortgageService.type.MONTHLY ? 12 : 1;
        // Number of periodic payments
        let n: number = this.term * t;
        // Periodic interest rate
        let i: number = (this.interest / 100) / t;
        // Discount factor {[(1 + i) ^n] - 1} / [i(1 + i)^n]
        let D: number = ((Math.pow((1 + i), n) - 1) / (i * Math.pow((1 + i), n)));

        return this.loan / D;
    }
}